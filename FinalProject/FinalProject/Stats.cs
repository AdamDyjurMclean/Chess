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

namespace FinalProject
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            List<string> data = new List<string>();
            using (StreamReader reader = new StreamReader("Players.csv"))
            {
                do
                {
                    data.Add(reader.ReadLine());
                } while (!reader.EndOfStream);
                for (int i = 0; i < data.Count; i++)
                {
                    string[] dataSplit = data[i].Split(',');
                    dataGrid.Rows.Add(dataSplit[0], dataSplit[1], dataSplit[2], dataSplit[3], dataSplit[4]);
                }
            }
        }
    }
}
