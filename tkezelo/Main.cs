using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace tkezelo
{
    public partial class Main : Form
    {
        public string format = @"### ### ##0 Ft;-### ### ##0 Ft;''";
        public DataSet dataset;

        public Main()
        {

            InitializeComponent();
            setMinYear.Text = DateTime.Now.ToString("yyyy");
            setMinMonth.Text = DateTime.Now.ToString("MMMM");
            setMaxYear.Text = DateTime.Now.ToString("yyyy");
            setMaxMonth.Text = DateTime.Now.ToString("MMMM");

            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "tkezelo";
            const string keyName = userRoot + "\\" + subkey;

            try
            {
                setDatabaseHost.Text = Registry.GetValue(keyName, "host", "winsql.vlszki.dc").ToString();
                setDatabasePort.Text = Registry.GetValue(keyName, "port", "3306").ToString();
                setDatabaseName.Text = Registry.GetValue(keyName, "database", "database").ToString();
                setDatabaseUsername.Text = Registry.GetValue(keyName, "username", "diak6").ToString();
                setDatabasePassword.Text = Registry.GetValue(keyName, "password", "jI50aR").ToString();

                setEpulet.Text = Registry.GetValue(keyName, "lepulet", "").ToString();
                setMinYear.Text = Registry.GetValue(keyName, "lminyear", "").ToString();
                setMinMonth.Text = Registry.GetValue(keyName, "lminmonth", "").ToString();
                setMaxYear.Text = Registry.GetValue(keyName, "lmaxyear", "").ToString();
                setMaxMonth.Text = Registry.GetValue(keyName, "lmaxmonth", "").ToString();

                setMegnevezes.Text = Registry.GetValue(keyName, "lname", "").ToString();
            }
            catch (Exception)
            {

            }
        }

        private void init(object sender, EventArgs e)
        {
            Database.Connect(this);
            Database.Load();
            Database.Filter();
        }


        private void query(object sender, EventArgs e)
        {
            Database.Filter();
        }

        private void btnPreview_click(object sender, EventArgs e)
        {
            Print.Create(this);
            Print.Preview();
        }

        private void btnPreview_checked(object sender, EventArgs e)
        {
            setMaxYear.Visible = !allowDate.Checked;
            setMaxMonth.Visible = !allowDate.Checked;
            label1.Visible = !allowDate.Checked;
        }


        private void dgvData_click(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvData.Columns["mentes"].Index == e.ColumnIndex)
            {
                if (dgvData.Rows[e.RowIndex].Cells["megnevezes"].Value.ToString() == "")
                {
                    MessageBox.Show("Adjon meg megnevezést");
                }
                else 
                {
                    Database.Set(e.RowIndex);
                    dgvData.Rows[e.RowIndex].Cells["mentes"].Style.BackColor = Color.White;
                }

            }

            if (dgvData.Columns["torles"].Index == e.ColumnIndex)
            {
                if (MessageBox.Show("Biztosan törli a tételt? ", "Könyvelési tétel törlése", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Database.Remove(e.RowIndex);
                    Database.Load();
                    Database.Filter();
                }
            }

        }

        private void cell_value_changed(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (dgvData.Rows[e.RowIndex].Cells["bevetel"].Value == DBNull.Value)
                    dgvData.Rows[e.RowIndex].Cells["bevetel"].Value = 0;
                if (dgvData.Rows[e.RowIndex].Cells["kiadas"].Value == DBNull.Value)
                    dgvData.Rows[e.RowIndex].Cells["kiadas"].Value = 0;

                dgvData.Rows[e.RowIndex].Cells["egyenleg"].Value =
                    Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["bevetel"].Value) -
                    Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["kiadas"].Value);
            }
            
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            ExcelBuilder excel = new ExcelBuilder();
            excel.ShowDialog();

            Database.Load();
            Database.Filter();
        }

        private void set_row(object sender, DataGridViewCellCancelEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["mentes"].Style.BackColor = Color.Blue;

            if (dgvData.Rows[e.RowIndex].Cells["datum"].Value.ToString() == "")
            {
                dgvData.Rows[e.RowIndex].Cells["datum"].Value = setMinYear.Text + "." + setMinMonth.Text + ".";
            }
            
        }

        private void btnPrintAdd_Click(object sender, EventArgs e)
        {
            Database.PrintAdd();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print.Begin();
        }

        private void column_resize(object sender, DataGridViewColumnEventArgs e)
        {
            int x;

            x = dgvData.RowHeadersWidth + dgvData.Columns["datum"].Width + dgvData.Columns["megnevezes"].Width;
            getBevetel.Left = x+2;
            getBevetel.Width = dgvData.Columns["bevetel"].Width - 2;

            x = getBevetel.Left + getBevetel.Width;
            getKiadas.Left = x+2;
            getKiadas.Width = dgvData.Columns["kiadas"].Width - 2;

            x = getKiadas.Left + getKiadas.Width;
            getEgyenleg.Left = x+2;
            getEgyenleg.Width = dgvData.Columns["egyenleg"].Width - 2;
            getTeljesEgyenleg.Left = x+2;
            getTeljesEgyenleg.Width = dgvData.Columns["egyenleg"].Width - 2;
        
        }

        private void setProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (setProvider.SelectedIndex == 1)
            {
                setDatabaseHost.Visible = true;
                setDatabasePassword.Visible = true;
                setDatabasePort.Visible = true;
                setDatabaseUsername.Visible = true;
            }
            else
            {
                setDatabaseHost.Visible = false;
                setDatabasePassword.Visible = false;
                setDatabasePort.Visible = false;
                setDatabaseUsername.Visible = false;
            }
        }

        private void setPrintList_remove(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Valóban törli a nyomtatást?", "Nyomtatás törlése", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Database.PrintRemove(setPrintList.SelectedValue.ToString());
                }
            }
        }

        private void remove(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete)&&(dgvData.SelectedRows.Count > 0))
            {
                if (MessageBox.Show("Biztosan törli a tételeket? " + dgvData.SelectedRows.Count+" tétel.", "Könyvelési tételek törlése", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int row = 0; row < dgvData.SelectedRows.Count; row++)
                    {
                        Database.Remove(dgvData.SelectedRows[row].Index);
                        
                    }

                    Database.Load();
                    Database.Filter();
                }
            }
        }

        private void btnEpuletAdd_Click(object sender, EventArgs e)
        {
            Database.EpuletAdd();
        }

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "tkezelo";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, "host", setDatabaseHost.Text);
            Registry.SetValue(keyName, "port", setDatabasePort.Text);
            Registry.SetValue(keyName, "database", setDatabaseName.Text);
            Registry.SetValue(keyName, "username", setDatabaseUsername.Text);
            Registry.SetValue(keyName, "password", setDatabasePassword.Text);

            Database.Connect(this);
            Database.Load();
            Database.Filter();
        }

        private void exit(object sender, FormClosedEventArgs e)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "tkezelo";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, "lepulet", setEpulet.Text);
            Registry.SetValue(keyName, "lminyear", setMinYear.Text);
            Registry.SetValue(keyName, "lminmonth", setMinMonth.Text);
            Registry.SetValue(keyName, "lmaxyear", setMaxYear.Text);
            Registry.SetValue(keyName, "lmaxmonth", setMaxMonth.Text);
            Registry.SetValue(keyName, "lname", setMegnevezes.Text);
        }

        private void format_error(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgvData.Columns["datum"].Index)
            {
                MessageBox.Show("Hibás dátum formátum");
            }

            if (e.ColumnIndex == dgvData.Columns["bevetel"].Index)
            {
                MessageBox.Show("Hibás bevétel formátum");
            }

            if (e.ColumnIndex == dgvData.Columns["kiadas"].Index)
            {
                MessageBox.Show("Hibás kiadás formátum");
            }

            if (e.ColumnIndex == dgvData.Columns["egyenleg"].Index)
            {
                MessageBox.Show("Hibás egyenleg formátum");
            }
        }

        private void closing(object sender, FormClosingEventArgs e)
        {

            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                if (dgvData.Rows[i].Cells["mentes"].Style.BackColor == Color.Blue)
                {
                    MessageBox.Show("Bezárás előtt mentse el az összes sort");
                    e.Cancel = true;
                }
            }

          


        }



    }
}