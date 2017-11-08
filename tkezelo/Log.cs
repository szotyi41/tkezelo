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

namespace tkezelo
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            Caption.Text = Text;

            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(DateTime.Now.ToString("yyyy.MM.dd. hh:mm:ss")+" "+Caption.Text);
            sw.WriteLine(Message.Text);
            sw.Close();
        }

        private void show_error(object sender, EventArgs e)
        {
            Message.Visible = !Message.Visible;
        }
    }
}
