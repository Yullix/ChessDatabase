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
using System.IO;
using System.Reflection;

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

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Stream pawnStream = currentAssembly.GetManifestResourceStream("ChessDatabase.whitePawn.png");
            pBoxa1.Image = new Bitmap(pawnStream);

            //pBoxa1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images/whitePawn.png"));
            //pBoxa1.Image = Image.FromFile("Images/whitePawn.png");
        }

        public void SetPosition(Game game)
        {

        }

        public Piece returnPiece(string imageName)
        {
            throw new NotImplementedException();
        }
    }
}
