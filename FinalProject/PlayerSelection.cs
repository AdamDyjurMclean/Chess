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
    public partial class PlayerSelection : Form
    {
        public PlayerSelection()
        {
            InitializeComponent();
            ComboBoxNames();
        }
        private void ComboBoxNames()
        {
            List<string> fileNames = new List<string>();
            using (StreamReader reader = new StreamReader("Players.csv"))
            {
                do
                {
                    fileNames.Add(reader.ReadLine());
                } while (!reader.EndOfStream);
                for (int i = 0; i < fileNames.Count; i++)
                {
                    cb1.Items.Add(fileNames[i].Split(',')[0]);
                    cb2.Items.Add(fileNames[i].Split(',')[0]);
                }
            }
        }
        private void txtAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Don't want the ding sound.
                e.SuppressKeyPress = true;
                btnAdd_Click(sender, e);
            }
        }
        //To add new player names.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Don't want to add nothing.
            if (txtAdd.Text == "")
                return;
            List<string> data = new List<string>();
            //First make sure the name does not already exist.
            using (StreamReader reader = new StreamReader("Players.csv"))
            {
                do
                {
                  data.Add(reader.ReadLine());
                } while (!reader.EndOfStream);
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Split(',')[0] == txtAdd.Text)
                    {
                        MessageBox.Show("This name is already in use");
                        return;
                    }
                }
            }
            //Then add it.
            using (StreamWriter writer = new StreamWriter("Players.csv", true))
            {
                writer.WriteLine($"{txtAdd.Text},0,0,0,0");
            }
            //Redo the combo box options so the new will show up.
            cb1.Items.Add(txtAdd.Text);
            cb2.Items.Add(txtAdd.Text);
            txtAdd.Text = "";
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            Stats stats = new Stats();
            stats.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cb1.Text == "" | cb2.Text == "" | cb1.Text == cb2.Text)
                MessageBox.Show("Needs to be two different players");
            else
            {
                Chess chess = new Chess(cb1.Text, cb2.Text);
                chess.FormClosing += delegate { this.Show(); };
                chess.Show();
                this.Hide();
            }
        }
    }
}