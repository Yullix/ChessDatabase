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
        private static string selectedPieceAnnotation;
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

            startSq = null;
            endSq = null;
            selectedPieceAnnotation = "";

            var check = this.GetType().Assembly.GetManifestResourceNames();

            currentAssembly = Assembly.GetExecutingAssembly();

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

            SetPosition();
        }

        public void SetPosition()
        {
            for (int c = 0; c < 8; c++)
            {
                char row = 'a';
                for (int r = 0; r < 8; r++)
                {
                    PictureBox pSquare = this.Controls.Find("pBox" + row + (c + 1), true).FirstOrDefault() as PictureBox;
                    switch (currentGame.position[c, r])
                    {
                        case "wP":
                            pSquare.Image = new Bitmap(whitePawnStream);
                            break;
                        case "wN":
                            pSquare.Image = new Bitmap(whiteKnightStream);
                            break;
                        case "wB":
                            pSquare.Image = new Bitmap(whiteBishopStream);
                            break;
                        case "wR":
                            pSquare.Image = new Bitmap(whiteRookStream);
                            break;
                        case "wQ":
                            pSquare.Image = new Bitmap(whiteQueenStream);
                            break;
                        case "wK":
                            pSquare.Image = new Bitmap(whiteKingStream);
                            break;
                        case "bP":
                            pSquare.Image = new Bitmap(blackPawnStream);
                            break;
                        case "bN":
                            pSquare.Image = new Bitmap(blackKnightStream);
                            break;
                        case "bB":
                            pSquare.Image = new Bitmap(blackBishopStream);
                            break;
                        case "bR":
                            pSquare.Image = new Bitmap(blackRookStream);
                            break;
                        case "bQ":
                            pSquare.Image = new Bitmap(blackQueenStream);
                            break;
                        case "bK":
                            pSquare.Image = new Bitmap(blackKingStream);
                            break;
                        default:
                            pSquare.Image = null;
                            break;
                    }
                    switch (row)
                    {
                        case 'a':
                            row = 'b';
                            break;
                        case 'b':
                            row = 'c';
                            break;
                        case 'c':
                            row = 'd';
                            break;
                        case 'd':
                            row = 'e';
                            break;
                        case 'e':
                            row = 'f';
                            break;
                        case 'f':
                            row = 'g';
                            break;
                        case 'g':
                            row = 'h';
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public bool CompleteMove()
        {
            new Move()
            {
                startSq = startSq.Name,
                endSq = endSq.Name,
                GameID = currentGame.GameID
            };

            startSq.Image = null;

            switch(selectedPieceAnnotation)
            {
                case "wP":
                    endSq.Image = new Bitmap(whitePawnStream);
                    break;
                case "wN":
                    endSq.Image = new Bitmap(whiteKnightStream);
                    break;
                case "wB":
                    endSq.Image = new Bitmap(whiteBishopStream);
                    break;
                case "wR":
                    endSq.Image = new Bitmap(whiteRookStream);
                    break;
                case "wQ":
                    endSq.Image = new Bitmap(whiteQueenStream);
                    break;
                case "wK":
                    endSq.Image = new Bitmap(whiteKingStream);
                    break;
                case "bP":
                    endSq.Image = new Bitmap(blackPawnStream);
                    break;
                case "bN":
                    endSq.Image = new Bitmap(blackKnightStream);
                    break;
                case "bB":
                    endSq.Image = new Bitmap(blackBishopStream);
                    break;
                case "bR":
                    endSq.Image = new Bitmap(blackRookStream);
                    break;
                case "bQ":
                    endSq.Image = new Bitmap(blackQueenStream);
                    break;
                case "bK":
                    endSq.Image = new Bitmap(blackKingStream);
                    break;
                default:
                    endSq.Image = null;
                    break;
            }
            startSq = null;
            endSq = null;
            //SetPosition();
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
                    string[] squareString = square.Name.Split('x');

                    int[] squarePosition = new int[2];

                    switch (squareString[1][0])
                    {
                        case 'a':
                            squarePosition[1] = 0;
                            break;
                        case 'b':
                            squarePosition[1] = 1;
                            break;
                        case 'c':
                            squarePosition[1] = 2;
                            break;
                        case 'd':
                            squarePosition[1] = 3;
                            break;
                        case 'e':
                            squarePosition[1] = 4;
                            break;
                        case 'f':
                            squarePosition[1] = 5;
                            break;
                        case 'g':
                            squarePosition[1] = 6;
                            break;
                        case 'h':
                            squarePosition[1] = 7;
                            break;
                    }

                    squarePosition[0] = Int32.Parse(squareString[1][1].ToString()) - 1;

                    selectedPieceAnnotation = currentGame.position[squarePosition[0], squarePosition[1]];
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

        private void pBoxe4_Click(object sender, EventArgs e)
        {
            PictureBox e4 = (PictureBox)sender;

            SelectSquare(e4);
        }
    }
}
