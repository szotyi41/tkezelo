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
using System.Reflection;
using System.Drawing.Printing;

namespace tkezelo
{
    class Print
    {
        static Main main;
        static PrintPageEventArgs draw;

        static PrinterSettings ps = new PrinterSettings();
        static IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
        static PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4);
        static int paperwidth = sizeA4.Width;
        static int paperheight = sizeA4.Height;

        static PrintDocument pd = new PrintDocument();

        static public Font normal = new Font("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point);
        static public Font bold = new Font("Segoe UI", 8, FontStyle.Bold, GraphicsUnit.Point);
        static Color color = Color.Black;

        static int w = (paperheight / 12) - (48 / 12);

        static int[] width = new int[] { 
            Convert.ToInt32(w * 1),
            Convert.ToInt32(w * 2),
            Convert.ToInt32(w * 0.8),
            Convert.ToInt32(w * 0.8),
            Convert.ToInt32(w * 0.8),
        };

        static int maxwidth = width[0] + width[1] + width[2] + width[3] + width[4];


        //Nyomtatás init
        static public void Create(Main m)
        {
            main = m;

            pd.DocumentName = "Könyvelés";
            pd.DefaultPageSettings.PaperSize = sizeA4;
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += Draw;
        }

        static public void Begin()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.Document = pd;
            dialog.ShowDialog();
        }
        static public void Preview()
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        //Nyomtatás
        static int PenX = 16;
        static int PenY = 16;

        static DataView dataview;
        static DataTable datatable;
        static DataRow row;

        static public void Draw(object sender, PrintPageEventArgs e)
        {
            draw = e;

            PenX = 16;
            PenY = 16;

            int Side = 0;

            for (int query = 0; query < main.setPrintList.Items.Count; query++)
            {
                if (main.setPrintList.GetItemChecked(query))
                {

                    //Fejléc
                    PrintCaption(main.setPrintList.GetItemText(main.setPrintList.Items[query]), PenX, PenY);

                    //Tábla elkészítése
                    dataview = new DataView(main.dataset.Tables["konyveles"]);
                    dataview.RowFilter = main.dataset.Tables["nyomtatasok"].Rows[query]["szures"].ToString();

                    datatable = dataview.ToTable();

                    //Sorok
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {

                        #region Pozíció
                        if (PenY <= paperwidth - 64)
                        {
                            PenY += 16;
                        }
                        else
                        {
                            Side = 1;
                            PenY = 16;
                        }

                        PenX = (Side * (paperheight / 2)) + 16;
                        #endregion

                        row = datatable.Rows[i];

                        PrintCell(PenX, PenY, width[0], 16, DateTime.Parse(row["datum"].ToString()).ToString("yyyy. MM. dd."), 1, normal);
                        PrintCell(PenX, PenY, width[1], 16, row["megnevezes"].ToString(), 0, normal);
                        PrintCell(PenX, PenY, width[2], 16, Convert.ToInt32(row["bevetel"].ToString()).ToString(main.format), 2, normal);
                        PrintCell(PenX, PenY, width[3], 16, Convert.ToInt32(row["kiadas"].ToString()).ToString(main.format), 2, normal);
                        PrintCell(PenX, PenY, width[4], 16, Convert.ToInt32(row["egyenleg"].ToString()).ToString(main.format), 2, normal);

                    }

                    //Összesítések
                    #region Pozíció
                    if (PenY <= paperwidth - 64)
                    {
                        PenY += 16;
                    }
                    else
                    {
                        Side = 1;
                        PenY = 16;
                    }

                    PenX = (Side * (paperheight / 2)) + 16 + width[0]+width[1];
                    #endregion

                    int bevetel = 0;
                    int kiadas = 0;
                    int egyenleg = 0;
                    int teljesegyenleg = 0;
                    string teljessql = main.dataset.Tables["nyomtatasok"].Rows[query]["elozo"].ToString();

                    if (dataview.Count > 0)
                    {
                        bevetel = Convert.ToInt32(dataview.Table.Compute("SUM(bevetel)", dataview.RowFilter));
                        kiadas = Convert.ToInt32(dataview.Table.Compute("SUM(kiadas)", dataview.RowFilter));
                        egyenleg = Convert.ToInt32(dataview.Table.Compute("SUM(egyenleg)", dataview.RowFilter));

                        if(teljessql != "") {
                            teljesegyenleg = Convert.ToInt32(dataview.Table.Compute("SUM(egyenleg)", teljessql));
                        }
                    }


                    PrintCell(PenX, PenY, width[2], 16, bevetel.ToString(main.format), 2, bold);
                    PrintCell(PenX, PenY, width[3], 16, kiadas.ToString(main.format), 2, bold);
                    PrintCell(PenX, PenY, width[4], 16, egyenleg.ToString(main.format), 2, bold);

                    if (teljessql != "")
                    {
                        PenX = width[0] + width[1] + 16;
                        PenY += 16;

                        //PrintText(PenX, PenY, "Egyenleg:", bold);
                        PenX += width[2] + width[3];

                        PrintCell(PenX, PenY, width[4], 16, teljesegyenleg.ToString(main.format), 2, bold);
                    }
                    

                    PenY += 32;
                    PenX = 16;
                }
            }
        }

        //Fejléc
        static private void PrintCaption(string caption, int x, int y)
        {
            PrintCell(x, y, maxwidth, 16, caption, 1, bold);
            PrintCell(x, y + 16, width[0], 16, "Dátum", 1, bold);
            PrintCell(x + width[0], y + 16, width[1], 16, "Megnevezés", 1, bold);
            PrintCell(x + width[0] + width[1], y + 16, width[2], 16, "Bevétel", 1, bold);
            PrintCell(x + width[0] + width[1] + width[2], y + 16, width[3], 16, "Kiadás", 1, bold);
            PrintCell(x + width[0] + width[1] + width[2] + width[3], y + 16, width[4], 16, "Egyenleg", 1, bold);

            PenX = 16;
            PenY += 16;
        }

        //Formázások
        static private void PrintCell(int x, int y, int w, int h, string text, int align, Font font)
        {
            Size textsize = TextRenderer.MeasureText(text, font);
            draw.Graphics.DrawRectangle(new Pen(Color.Black, 1), x, y, w, h);

            switch (align)
            {
                case 0:
                    PrintText((int)x, (int)y + (h / 2) - (textsize.Height / 2), text, font);
                    break;
                case 1:
                    PrintText((int)x + (w / 2) - (textsize.Width / 2), (int)y + (h / 2) - (textsize.Height / 2), text, font);
                    break;
                case 2:
                    PrintText((int)x + (w) - (textsize.Width), (int)y + (h / 2) - (textsize.Height / 2), text, font);
                    break;
            }

            PenX += w;
        }

        static private void PrintText(int x, int y, string text, Font font)
        {
            draw.Graphics.DrawString(text, font, new SolidBrush(color), new PointF(x, y));
        }



    }
}
