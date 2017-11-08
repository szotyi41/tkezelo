using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Win32;

namespace tkezelo
{
    public partial class ExcelBuilder : Form
    {
        public ExcelBuilder()
        {
            InitializeComponent();
        }

        public DataSet dataset = new DataSet();

        static MySqlConnection connection;
        static MySqlCommand command;
        static MySqlDataAdapter adapter;

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "tkezelo";
        const string keyName = userRoot + "\\" + subkey;

        static string host = Registry.GetValue(keyName, "host", "").ToString();
        static string port = Registry.GetValue(keyName, "port", "").ToString();
        static string database = Registry.GetValue(keyName, "database", "").ToString();
        static string username = Registry.GetValue(keyName, "username", "").ToString();
        static string password = Registry.GetValue(keyName, "password", "").ToString();

        static string epulet;

        private void Form1_Load(object sender, EventArgs e)
        {


            try {

                file.Filter = "Excel fájlok (*.xls *.xlsx)|*.xls; *.xlsx";
                file.ShowDialog();

                excel = new ExcelData(this, file.FileName);
                excel.LoadWorksheets();

                connection = new MySqlConnection(
                    @"Server=" + host + ";" +
                    @"Port=" + port + ";" +
                    @"Database=" + database + ";" +
                    @"Uid=" + username + ";" +
                    @"Pwd=" + password + ";");

                adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand();
                adapter.SelectCommand.Connection = connection;


                //Épületek betöltése
                adapter.SelectCommand.CommandText = @"SELECT * FROM epuletek";

                adapter.Fill(dataset, "epuletek");

                setEpulet.DataSource = dataset.Tables["epuletek"];
                setEpulet.DisplayMember = dataset.Tables["epuletek"].Columns["epulet"].ToString();
                setEpulet.ValueMember = dataset.Tables["epuletek"].Columns["epuletid"].ToString();
                setEpulet.SelectedIndex = 0;

   
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.ToString());
                this.Close();
            }
        }


        OpenFileDialog file = new OpenFileDialog();
        ExcelData excel;

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void show_table(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvTable.DataSource = excel.Import(e.RowIndex);
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgvColumns.Rows.Count; i++)
            {
                if (dgvColumns.Rows[i].Cells["import"].Value != null)
                {
                    if ((bool)dgvColumns.Rows[i].Cells["import"].Value == true)
                    {
                        Insert(this, excel.Import(i));
                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            excel.LoadDates();
        }

        private void dgvColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        static public void Insert(ExcelBuilder main, DataTable table)
        {

            int updatedrows = 0;

            try
            {

                command = new MySqlCommand();
                command.Connection = connection;
                connection.Open();

                string datum, megnevezes, bevetel, kiadas, egyenleg;

                

                for (int i = 0; i < table.Rows.Count - 1; i++)
                {

                    if (table.Rows[i]["datum"] != null)
                        datum = Convert.ToDateTime(table.Rows[i]["datum"].ToString()).ToString("yyyy-MM-dd");
                    else datum = new DateTime().ToString();

                    if (table.Rows[i]["megnevezes"] != null)
                        megnevezes = table.Rows[i]["megnevezes"].ToString();
                    else megnevezes = "";

                    if (table.Rows[i]["bevetel"].ToString() != "")
                        bevetel = table.Rows[i]["bevetel"].ToString();
                    else bevetel = "0";

                    if (table.Rows[i]["kiadas"].ToString() != "")
                        kiadas = table.Rows[i]["kiadas"].ToString();
                    else kiadas = "0";

                    if (table.Rows[i]["egyenleg"].ToString() != "")
                        egyenleg = table.Rows[i]["egyenleg"].ToString();
                    else egyenleg = "0";

                    command.CommandText = string.Format(
                        @"
                            INSERT 
                            INTO konyveles (epuletid,datum,megnevezes,bevetel,kiadas,egyenleg) 
                            VALUES ({0},'{1}','{2}',{3},{4},{5});
                        ",

                        epulet, datum, megnevezes, bevetel, kiadas, egyenleg);

                    updatedrows += Convert.ToInt32(command.ExecuteNonQuery());


                }

                MessageBox.Show("Hozzáadott sorok: " + updatedrows.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n" + command.CommandText);
            }
            finally
            {
                connection.Close();
            }

        }

        private void setEpulet_SelectedIndexChanged(object sender, EventArgs e)
        {
            epulet = setEpulet.SelectedValue.ToString();
        }
    }
}
