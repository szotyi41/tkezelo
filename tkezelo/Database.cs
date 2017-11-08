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
using System.Data.OleDb;

namespace tkezelo
{
    class Database
    {
        static Main main;
        static MySqlConnection connection;
        static MySqlCommand command;
        static MySqlDataAdapter adapter;

        static DataView dataview;

        static bool loaded = false;
        static bool connected = false;

        public static void Connect(Main m)
        {
            main = m;
            main.dataset = new DataSet();

            main.setProvider.SelectedIndex = 1;

            try
            {
                connected = true;
                connection = new MySqlConnection(
                    @"Server=" + main.setDatabaseHost.Text + ";" +
                    @"Port=" + main.setDatabasePort.Text + ";" +
                    @"Database=" + main.setDatabaseName.Text + ";" +
                    @"Uid=" + main.setDatabaseUsername.Text + ";" +
                    @"Pwd=" + main.setDatabasePassword.Text + ";");
            }
            catch (Exception e)
            {
                main.tcTabpages.SelectedIndex = 3;
                connected = false;
                Log log = new Log();
                log.Text = "Csatlakozzon adatbázis szerverhez";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
        }

        public static void Load()
        {
            if (connected == false) return;

            try
            {
                main.dataset = new DataSet();


                adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand();
                adapter.SelectCommand.Connection = connection;

                //Adatok betöltése
                adapter.SelectCommand.CommandText = @"
                    SELECT id, epuletek.epulet, datum, megnevezes, bevetel, kiadas, egyenleg 
                    FROM konyveles, epuletek 
                    WHERE epuletek.epuletid = konyveles.epuletid";


                adapter.Fill(main.dataset, "konyveles");
                main.dgvData.DataSource = main.dataset.Tables["konyveles"];

                AutoCompleteStringCollection scsc = new AutoCompleteStringCollection();

                foreach(DataRow row in main.dataset.Tables["konyveles"].Rows) {
                    scsc.Add(row["megnevezes"].ToString());
                }

                main.setMegnevezes.AutoCompleteMode = AutoCompleteMode.Suggest;
                main.setMegnevezes.AutoCompleteSource = AutoCompleteSource.CustomSource;
                main.setMegnevezes.AutoCompleteCustomSource = scsc;

            
                //Épületek betöltése
                adapter.SelectCommand.CommandText = @"SELECT * FROM epuletek";

                adapter.Fill(main.dataset, "epuletek");

                main.setEpulet.DataSource = main.dataset.Tables["epuletek"];
                main.setEpulet.DisplayMember = main.dataset.Tables["epuletek"].Columns["epulet"].ToString();
                main.setEpulet.ValueMember = main.dataset.Tables["epuletek"].Columns["epuletid"].ToString();
                main.setEpulet.SelectedIndex = 0;

                //Nyomtatások betöltése
                adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand();
                adapter.SelectCommand.Connection = connection;

                adapter.SelectCommand.CommandText = @"SELECT * FROM nyomtatasok";

                adapter.Fill(main.dataset, "nyomtatasok");

                main.setPrintList.DataSource = main.dataset.Tables["nyomtatasok"];
                main.setPrintList.DisplayMember = main.dataset.Tables["nyomtatasok"].Columns["megnevezes"].ToString();
                main.setPrintList.ValueMember = main.dataset.Tables["nyomtatasok"].Columns["nyomtatasid"].ToString();

                if (loaded == false)
                {
                    #region Oszlopok formázása

                    main.dgvData.Columns["id"].Visible = false;
                    main.dgvData.Columns["id"].ReadOnly = true;

                    main.dgvData.Columns["epulet"].Visible = false;

                    main.dgvData.Columns["datum"].HeaderText = "Dátum";
                    main.dgvData.Columns["datum"].Width = 96;


                    main.dgvData.Columns["megnevezes"].HeaderText = "Megenevezés";
                    main.dgvData.Columns["megnevezes"].Width = 256;
                    

                    DataGridViewCellStyle numberstlye = new DataGridViewCellStyle();
                  
                    numberstlye.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                    numberstlye.Format = main.format;

                    main.dgvData.Columns["bevetel"].HeaderText = "Bevétel";
                    main.dgvData.Columns["bevetel"].DefaultCellStyle = numberstlye;

                    main.dgvData.Columns["kiadas"].HeaderText = "Kiadás";
                    main.dgvData.Columns["kiadas"].DefaultCellStyle = numberstlye;

                    main.dgvData.Columns["egyenleg"].HeaderText = "Egyenleg";
                    main.dgvData.Columns["egyenleg"].DefaultCellStyle = numberstlye;
                    main.dgvData.Columns["egyenleg"].ReadOnly = true;

                    DataGridViewCellStyle buttonstyle = new DataGridViewCellStyle();
                    buttonstyle.NullValue = "";
                    buttonstyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                    DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                    column.DefaultCellStyle = buttonstyle;
                    column.HeaderText = "Mentés";
                    column.Name = "mentes";
                    column.Text = "Mentés";
                    column.UseColumnTextForButtonValue = true;
                    column.FlatStyle = FlatStyle.Standard;
                    main.dgvData.Columns.Add(column);

                    column = new DataGridViewButtonColumn();
                    column.DefaultCellStyle = buttonstyle;
                    column.HeaderText = "Törlés";
                    column.Name = "torles";
                    column.Text = "Törlés";
                    column.FlatStyle = FlatStyle.Standard;
                    column.UseColumnTextForButtonValue = true;
                    main.dgvData.Columns.Add(column);

                    #endregion
                    loaded = true;
                }
            }
            catch (Exception e)
            {
                main.tcTabpages.SelectedIndex = 3;
                connected = false;
                Log log = new Log();
                log.Text = "Nem sikerült csatlakozni a szerverhez";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
        }

        static string filter;
        static DateTime minDate;
        static DateTime maxDate;

        public static void Filter()
        {
            if (connected == false) return;

            try
            {
                dataview = new DataView(main.dataset.Tables["konyveles"]);
                main.setPrintName.Text = "";

                //Épület szerint
                dataview.RowFilter = string.Format("epulet LIKE '%{0}%' ", main.setEpulet.Text);
                main.setPrintName.Text += main.setEpulet.Text + " ";

                //Megnevezés szerint
                if (main.setMegnevezes.Text != "")
                {
                    dataview.RowFilter += string.Format("AND megnevezes LIKE '%{0}%' ", main.setMegnevezes.Text);
                    main.setPrintName.Text += string.Format(" '{0}' ", main.setMegnevezes.Text);
                }

                filter = dataview.RowFilter.ToString();

                //Dátum szerint

                #region Dátum beállítása

                if (!main.allowDate.Checked)
                {
                    if (main.setMinMonth.SelectedIndex > 0)
                    {
                        minDate = new DateTime(Convert.ToInt32(main.setMinYear.Text), main.setMinMonth.SelectedIndex, 1);
                        main.setPrintName.Text += string.Format("{0}. {1} - ", main.setMinYear.Text, main.setMinMonth.Text);
                    }
                    else
                    {
                        minDate = new DateTime(Convert.ToInt32(main.setMinYear.Text), 1, 1);
                        main.setPrintName.Text += string.Format("{0}. elejétől - ", main.setMinYear.Text);
                    }

                    if (main.setMaxMonth.SelectedIndex > 0)
                    {
                        maxDate = new DateTime(Convert.ToInt32(main.setMaxYear.Text), main.setMaxMonth.SelectedIndex, DateTime.DaysInMonth(Convert.ToInt32(main.setMaxYear.Text), main.setMaxMonth.SelectedIndex) - 1);
                        main.setPrintName.Text += string.Format("{0}. {1} ", main.setMaxYear.Text, main.setMaxMonth.Text);
                    }
                    else
                    {
                        maxDate = new DateTime(Convert.ToInt32(main.setMaxYear.Text), 12, 31);
                        main.setPrintName.Text += string.Format("{0}. végéig ", main.setMaxYear.Text);
                    }
                }
                else
                {
                    if (main.setMinMonth.SelectedIndex > 0)
                    {
                        //Havi lekérdezés
                        minDate = new DateTime(Convert.ToInt32(main.setMinYear.Text), main.setMinMonth.SelectedIndex, 1);
                        maxDate = new DateTime(Convert.ToInt32(main.setMinYear.Text), main.setMinMonth.SelectedIndex, DateTime.DaysInMonth(Convert.ToInt32(main.setMinYear.Text), main.setMinMonth.SelectedIndex) - 1);
                        main.setPrintName.Text += string.Format("{0}. {1} ", main.setMinYear.Text, main.setMinMonth.Text);
                    }
                    else
                    {
                        //Éves lekérdezés
                        minDate = new DateTime(Convert.ToInt32(main.setMinYear.Text), 1, 1);
                        maxDate = new DateTime(Convert.ToInt32(main.setMinYear.Text), 12, 31);
                        main.setPrintName.Text += string.Format("{0}. évi ", main.setMinYear.Text);
                    }
                }


                dataview.RowFilter += string.Format("AND datum >= '{0}' AND datum <= '{1}' ",
                    minDate.ToString("yyyy-MM-dd"),
                    maxDate.ToString("yyyy-MM-dd"));

                #endregion

                main.Text = "Társasházkezelő Szoftver - " + main.setPrintName.Text + "(" + dataview.Table.Rows.Count + " rekord)";
                main.dgvData.DataSource = dataview;

                //Összesítés
                int bevetel = 0;
                int kiadas = 0;
                int egyenleg = 0;
                int teljesegyenleg = 0;

                if (dataview.Count > 0)
                {
                    bevetel = Convert.ToInt32(dataview.Table.Compute("SUM(bevetel)", dataview.RowFilter));
                    kiadas = Convert.ToInt32(dataview.Table.Compute("SUM(kiadas)", dataview.RowFilter));
                    egyenleg = Convert.ToInt32(dataview.Table.Compute("SUM(egyenleg)", dataview.RowFilter));
                    teljesegyenleg = Convert.ToInt32(dataview.Table.Compute("SUM(egyenleg)", filter + string.Format("AND datum <= '{0}'", maxDate.ToString("yyyy-MM-dd"))));
                }

                main.getBevetel.Text = bevetel.ToString(main.format);
                main.getKiadas.Text = kiadas.ToString(main.format);
                main.getEgyenleg.Text = egyenleg.ToString(main.format);

                if ((main.allowDate.Checked) && (main.setMegnevezes.Text == ""))
                {

                    main.getTeljesEgyenleg.Visible = true;
                    main.getTeljesEgyenleg.Text = teljesegyenleg.ToString(main.format);
                }
                else
                {
                    main.getTeljesEgyenleg.Visible = false;
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.Text = "Hiba a szűrés alatt";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
        }


        public static void Set(int row)
        {
            if (connected == false) return;

            try
            {

                command = new MySqlCommand();
                command.Connection = connection;

                if (main.dgvData.Rows[row].Cells["id"].Value.ToString() == "")
                {

                    command.CommandText = @"
                        INSERT 
                        INTO konyveles (megnevezes, epuletid, bevetel, kiadas, egyenleg, datum)
                        VALUES (@megnevezes, @epuletid, @bevetel, @kiadas, @egyenleg, @datum)";

                }
                else
                {

                    command.CommandText = @"
                        UPDATE konyveles
                        SET megnevezes=@megnevezes, bevetel=@bevetel, kiadas=@kiadas, egyenleg=@egyenleg, datum=@datum
                        WHERE id=@id";

                }

                command.Parameters.AddWithValue("@id", main.dgvData.Rows[row].Cells["id"].Value.ToString());
                command.Parameters.AddWithValue("@epuletid", main.setEpulet.SelectedValue);
                command.Parameters.AddWithValue("@megnevezes", main.dgvData.Rows[row].Cells["megnevezes"].Value.ToString());
                command.Parameters.AddWithValue("@bevetel", main.dgvData.Rows[row].Cells["bevetel"].Value.ToString());
                command.Parameters.AddWithValue("@kiadas", main.dgvData.Rows[row].Cells["kiadas"].Value.ToString());
                command.Parameters.AddWithValue("@egyenleg", main.dgvData.Rows[row].Cells["egyenleg"].Value.ToString());
                command.Parameters.AddWithValue("@datum", DateTime.Parse(main.dgvData.Rows[row].Cells["datum"].Value.ToString()).ToString("yyyy-MM-dd"));

                connection.Open();
                command.ExecuteNonQuery();

                if (main.dgvData.Rows[row].Cells["id"].Value.ToString() == "")
                {
                    DataRow newrow = main.dataset.Tables["konyveles"].NewRow();
                    command.CommandText = "SELECT @@IDENTITY";
                    newrow["id"] = command.ExecuteScalar();
                    newrow["epulet"] = main.setEpulet.Text;
                    newrow["datum"] = main.dgvData.Rows[row].Cells["datum"].Value;
                    newrow["megnevezes"] = main.dgvData.Rows[row].Cells["megnevezes"].Value;
                    newrow["bevetel"] = main.dgvData.Rows[row].Cells["bevetel"].Value;
                    newrow["kiadas"] = main.dgvData.Rows[row].Cells["kiadas"].Value;
                    newrow["egyenleg"] = main.dgvData.Rows[row].Cells["egyenleg"].Value;
                    main.dataset.Tables["konyveles"].Rows.Add(newrow);
                }

                Database.Load();
                Database.Filter();

            }
            catch (Exception e)
            {
                connected = false;
                Log log = new Log();
                log.Text = "Írási hiba";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
            finally
            {
                connection.Close();
            }
        }
        public static void Remove(int row)
        {
            if (connected == false) return;

            try
            {
                adapter = new MySqlDataAdapter();
                adapter.DeleteCommand = new MySqlCommand();
                adapter.DeleteCommand.Connection = connection;

                adapter.DeleteCommand.CommandText = @"
                    DELETE FROM konyveles
                    WHERE id=@id";

                adapter.DeleteCommand.Parameters.AddWithValue("@id", main.dgvData.Rows[row].Cells["id"].Value.ToString());

                connection.Open();
                adapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connected = false;
                Log log = new Log();
                log.Text = "Törlési hiba";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void PrintRemove(string print)
        {
            if (connected == false) return;

            try
            {
                adapter = new MySqlDataAdapter();
                adapter.DeleteCommand = new MySqlCommand();
                adapter.DeleteCommand.Connection = connection;
                adapter.DeleteCommand.CommandText = @"
                    DELETE
                    FROM nyomtatasok
                    WHERE nyomtatasid=" + print;

                connection.Open();
                adapter.DeleteCommand.ExecuteNonQuery();

                main.dataset.Tables["nyomtatasok"].Rows.RemoveAt(main.setPrintList.SelectedIndex);
                adapter.Update(main.dataset.Tables["nyomtatasok"]);

            }
            catch (Exception e)
            {
                connected = true;
                Log log = new Log();
                log.Text = "Hiba a nyomtatás törlésekor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void PrintAdd()
        {
            if (connected == false) return;

            try
            {
                adapter = new MySqlDataAdapter();
                adapter.InsertCommand = new MySqlCommand();
                adapter.InsertCommand.Connection = connection;
                adapter.InsertCommand.CommandText =
                @"
                    INSERT
                    INTO nyomtatasok (megnevezes, szures, elozo)
                    VALUES (@megnevezes,@szures,@elozo);
                ";

                connection.Open();
                adapter.InsertCommand.Parameters.AddWithValue("@megnevezes", main.setPrintName.Text);
                adapter.InsertCommand.Parameters.AddWithValue("@szures", dataview.RowFilter);

                if ((main.allowDate.Checked) && (main.setMegnevezes.Text == ""))
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@elozo", filter + string.Format("AND datum <= '{0}'", maxDate.ToString("yyyy-MM-dd")));
                    main.dataset.Tables["nyomtatasok"].Rows.Add(0, main.setPrintName.Text, dataview.RowFilter, filter + string.Format("AND datum <= '{0}'", maxDate.ToString("yyyy-MM-dd")));
                }
                else
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@elozo", DBNull.Value);
                    main.dataset.Tables["nyomtatasok"].Rows.Add(0, main.setPrintName.Text, dataview.RowFilter, null);
                }

                
                adapter.Update(main.dataset.Tables["nyomtatasok"]);
                
            }
            catch (Exception e)
            {
                connected = false;
                Log log = new Log();
                log.Text = "Hiba a nyomtatás hozzáadásakor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void EpuletAdd()
        {
            try
            {
                adapter = new MySqlDataAdapter();
                adapter.InsertCommand = new MySqlCommand();
                adapter.InsertCommand.Connection = connection;
                adapter.InsertCommand.CommandText =
                @"
                    INSERT 
                    INTO epuletek (epulet)
                    VALUES (@epulet);
                ";

                connection.Open();
                adapter.InsertCommand.Parameters.AddWithValue("@epulet", main.tbEpuletAdd.Text);

                main.dataset.Tables["epuletek"].Rows.Add(0,main.tbEpuletAdd.Text);
                adapter.Update(main.dataset.Tables["epuletek"]);


            }
            catch (Exception e)
            {
                Log log = new Log();
                log.Text = "Hiba az épület hozzáadásakor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
            finally
            {
                connection.Close();
            }

        }

    }
}