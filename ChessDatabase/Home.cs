using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessDatabase.Models;

namespace ChessDatabase
{
    public partial class Home : Form
    {
        public string startSq;
        public string endSq;
        public Piece selectedPiece;
        public Game currentGame;

        public Home()
        {
            InitializeComponent();

            currentGame = new Game();

            SetPosition(currentGame);
        }

        public void SetPosition(Game game)
        {

        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {

        }
    }
}
