using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace tkezelo
{
    class ExcelData
    {
        ExcelBuilder main;

        static Excel.Application excel = null; 
        static Excel.Worksheet worksheet = null;
        static Excel.Workbook workbook = null;

        public ExcelData(ExcelBuilder f, string filepath)
        {
            main = f;

            try
            {
                if (File.Exists(filepath))
                {
                    excel = new Excel.Application();
                    workbook = excel.Workbooks.Open(filepath);
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.Text = "Hiba az Excel fájl betöltésekor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
                main.Close();
            }
        }

        public void LoadWorksheets()
        {
            try
            {
                foreach (Excel.Worksheet worksheet in workbook.Worksheets)
                {
                    main.setColumn.Items.Add(worksheet.Name);
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.Text = "Hiba a munkalapok betöltésekor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
                main.Close();
            }
        }

        public void LoadDates()
        {
            try
            {
                worksheet = (Excel.Worksheet)workbook.Worksheets[main.setColumn.SelectedItem.ToString()];

                DataTable table = new DataTable();

                DataColumn column;
                column = table.Columns.Add();
                column.ColumnName = "oszlop";
                column.ReadOnly = true;
                column = table.Columns.Add();
                column.ColumnName = "datum";
                column.DataType = System.Type.GetType("System.DateTime");
                column = table.Columns.Add();
                column.ColumnName = "kezdooszlop";

                DataRow row;

                for (int i = 1; i < worksheet.Columns.Count; i++)
                {
                    if (worksheet.Cells[1, i].Value2 != null)
                    {
                        row = table.NewRow();
                        row["oszlop"] = Convert.ToString(worksheet.Cells[1, i].Value2);
                        
                        try
                        {
                            row["datum"] = Convert.ToDateTime(Convert.ToString(worksheet.Cells[1, i].Value2));
                        }
                        catch (Exception)
                        {
                            row["datum"] = new DateTime();
                        }

                        row["kezdooszlop"] = Math.Max(i,2);
                        table.Rows.Add(row);
                    }
                }

                main.dgvColumns.DataSource = table;
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.Text = "Hiba az oszlopok betöltésekor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
            }
        }

        public DataTable Import(int index)
        {
            DataTable table = new DataTable();

            DateTime date = Convert.ToDateTime(main.dgvColumns.Rows[index].Cells["datum"].Value);
            int startcolumn = Convert.ToInt32(main.dgvColumns.Rows[index].Cells["kezdooszlop"].Value);

            try
            {

                DataColumn column;
                column = table.Columns.Add();
                column.ColumnName = "megnevezes";
                column = table.Columns.Add();
                column.ColumnName = "bevetel";
                column = table.Columns.Add();
                column.ColumnName = "kiadas";
                column = table.Columns.Add();
                column.ColumnName = "egyenleg";
                column = table.Columns.Add();
                column.ColumnName = "datum";
                column.DataType = System.Type.GetType("System.DateTime");

                int i = 4;

                while (worksheet.Cells[i, 1].Value2 != null)
                {

                    DataRow row = table.NewRow();
                    if (worksheet.Cells[i, 1].Value2 != null) row["megnevezes"] = Convert.ToString(worksheet.Cells[i, 1].Value2);

                    if (worksheet.Cells[i, startcolumn + 0].Value2 != null) row["bevetel"] = Convert.ToString(worksheet.Cells[i, startcolumn + 0].Value2); else row["bevetel"] = "0";
                    if (worksheet.Cells[i, startcolumn + 1].Value2 != null) row["kiadas"] = Convert.ToString(worksheet.Cells[i, startcolumn + 1].Value2); else row["kiadas"] = "0";
                    if (worksheet.Cells[i, startcolumn + 2].Value2 != null) row["egyenleg"] = Convert.ToString(worksheet.Cells[i, startcolumn + 2].Value2); else row["egyenleg"] = "0";
                    

                    row["datum"] = date;
                    
                    table.Rows.Add(row);
                    i++;
                }
                

            }
            catch (Exception e)
            {
                Log log = new Log();
                log.Text = "Hiba a tábla elkészítésekor";
                log.Message.Text = e.ToString();
                log.ShowDialog();
                main.Close();
            }

            return table;
        }

        public void Export()
        {
            
        }
    }
}
