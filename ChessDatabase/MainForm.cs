using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDatabase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form playersForm = new ManagePlayers();
            playersForm.Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form homeForm = new Home();           
            homeForm.Show();
            this.Hide();
        }
    }
}
