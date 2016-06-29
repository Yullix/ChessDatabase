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
        private PictureBox startSq;
        private PictureBox endSq;
        private string selectedPieceAnnotation;
        private Game currentGame;
        private Assembly currentAssembly;
        private Stream whitePawnStream;
        private Stream whiteKnightStream;
        private Stream whiteBishopStream;
        private Stream whiteRookStream;
        private Stream whiteQueenStream;
        private Stream whiteKingStream;
        private Stream blackPawnStream;
        private Stream blackKnightStream;
        private Stream blackBishopStream;
        private Stream blackRookStream;
        private Stream blackQueenStream;
        private Stream blackKingStream;

        public Home(Game gameArgument)
        {
            InitializeComponent();

            currentGame = gameArgument;

            SetPosition(currentGame);

            startSq = null;
            endSq = null;
            selectedPieceAnnotation = "";

            var check = this.GetType().Assembly.GetManifestResourceNames();

            currentAssembly = Assembly.GetExecutingAssembly();

            for(int c = 0; c < 8; c++)
            {
                char row = 'a';
                for (int r = 0; r < 8; r++)
                {
                    
                    switch(currentGame.position[c,r])
                    {
                        case "wP":
                            break;
                        case "wN":
                            break;
                        case "wB":
                            break;
                        case "wR":
                            break;
                        case "wQ":
                            break;
                        case "wK":
                            break;
                        case "bP":
                            break;
                        case "bN":
                            break;
                        case "bB":
                            break;
                        case "bR":
                            break;
                        case "bQ":
                            break;
                        case "bK":
                            break;
                    }
                    switch(row)
                    {

                    }

                }
            }
            whitePawnStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whitePawn.png");
            whiteKnightStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteKnight.png");
            whiteBishopStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteBishop.png");
            whiteRookStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteRook.png");
            whiteQueenStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteQueen.png");
            whiteKingStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteKing.png");

            blackPawnStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackPawn.png");
            blackKnightStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackKnight.png");
            blackBishopStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackBishop.png");
            blackRookStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackRook.png");
            blackQueenStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackQueen.png");
            blackKingStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackKing.png");

            //Drawing whites pawns
            pBoxa2.Image = new Bitmap(whitePawnStream);
            pBoxb2.Image = new Bitmap(whitePawnStream);
            pBoxc2.Image = new Bitmap(whitePawnStream);
            pBoxd2.Image = new Bitmap(whitePawnStream);
            pBoxe2.Image = new Bitmap(whitePawnStream);
            pBoxf2.Image = new Bitmap(whitePawnStream);
            pBoxg2.Image = new Bitmap(whitePawnStream);
            pBoxh2.Image = new Bitmap(whitePawnStream);

            //Drawing rest of whites pieces
            pBoxa1.Image = new Bitmap(whiteRookStream);
            pBoxb1.Image = new Bitmap(whiteKnightStream);
            pBoxc1.Image = new Bitmap(whiteBishopStream);
            pBoxd1.Image = new Bitmap(whiteQueenStream);
            pBoxe1.Image = new Bitmap(whiteKingStream);
            pBoxf1.Image = new Bitmap(whiteBishopStream);
            pBoxg1.Image = new Bitmap(whiteKnightStream);
            pBoxh1.Image = new Bitmap(whiteRookStream);

            //Drawing blacks pawns
            pBoxa7.Image = new Bitmap(blackPawnStream);
            pBoxb7.Image = new Bitmap(blackPawnStream);
            pBoxc7.Image = new Bitmap(blackPawnStream);
            pBoxd7.Image = new Bitmap(blackPawnStream);
            pBoxe7.Image = new Bitmap(blackPawnStream);
            pBoxf7.Image = new Bitmap(blackPawnStream);
            pBoxg7.Image = new Bitmap(blackPawnStream);
            pBoxh7.Image = new Bitmap(blackPawnStream);

            //Drawing rest of blacks pieces
            pBoxa8.Image = new Bitmap(blackRookStream);
            pBoxb8.Image = new Bitmap(blackKnightStream);
            pBoxc8.Image = new Bitmap(blackBishopStream);
            pBoxd8.Image = new Bitmap(blackQueenStream);
            pBoxe8.Image = new Bitmap(blackKingStream);
            pBoxf8.Image = new Bitmap(blackBishopStream);
            pBoxg8.Image = new Bitmap(blackKnightStream);
            pBoxh8.Image = new Bitmap(blackRookStream);

            //pBoxa1.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images/whitePawn.png"));
            //pBoxa1.Image = Image.FromFile("Images/whitePawn.png");
        }

        public void SetPosition(Game game)
        {

        }

        public bool CompleteMove()
        {
            new Move()
            {
                startSq = startSq.Name,
                endSq = endSq.Name,
                GameID = currentGame.GameID
            };
            startSq = null;
            endSq = null;
            return false;
        }

        private void SelectSquare(PictureBox square)
        {
            if(startSq == null)
            {
                if (square.Image != null)
                {
                    startSq = square;
                    square.BackColor = Color.Brown;
                }
                else
                    return;
            }
            else
            {
                endSq = square;
                CompleteMove();
            }
        }

        private void pBoxe2_Click(object sender, EventArgs e)
        {
            PictureBox e2 = (PictureBox)sender;

            SelectSquare(e2); 
        }
    }
}
