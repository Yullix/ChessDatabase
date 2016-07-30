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
using ChessDatabase.Services;
using ChessDatabase.Repositories;
using System.IO;
using System.Reflection;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase
{
    public partial class Home : Form
    {
        private PictureBox startSq;
        private PictureBox endSq;
        private int[] startSqPos;
        private int[] endSqPos;
        private string[,] position;
        private static string selectedPieceAnnotation;
        private string color;
        private int moveNmbr;
        private string plyAnnotation;
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
        private MoveService _moveService;
        private RepositoryFactory _repoFactory;
        private List<Move> gameMoves;
        private Move currentMove;

        public MoveService moveService
        {
            get
            {
                return _moveService ?? new MoveService(repoFactory);
            }
            private set
            {
                _moveService = value;
            }
        }

        public RepositoryFactory repoFactory
        {
            get
            {
                return _repoFactory ?? new RepositoryFactory();
            }
            private set
            {
                _repoFactory = value;
            }
        }

        public Home()
        {
            InitializeComponent();

            gameMoves = new List<Move>();
            color = "white";
            position = ChessLogic.GetStartPosition();
            moveNmbr = 1;

            startSq = null;
            endSq = null;
            startSqPos = new int[2];
            endSqPos = new int[2];
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

        // Greates the graphical position from currentGame.position
        public void SetPosition()
        {
            for (int c = 0; c < 8; c++)
            {
                char row = 'a';
                for (int r = 0; r < 8; r++)
                {
                    PictureBox pSquare = this.Controls.Find("pBox" + row + (c + 1), true).FirstOrDefault() as PictureBox;
                    switch (position[c, r])
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

        public void UpdateMoveList()
        {
            if(color == "white")
            {
                int lastIndex = lstMoves.Items.Count - 1;

                lstMoves.Items.RemoveAt(lstMoves.Items.Count - 1);
                lstMoves.Items.Add(currentMove);
            }
            else
            {
                lstMoves.Items.Add(currentMove);
            }
        }

        //Completes a move after a square with a piece on it and an empty square has been selected
        public bool CompleteMove()
        {

            // Changes the color of the starting square back to its original color
            if(startSqPos[0] % 2 == 1)
            {
                if (startSqPos[1] % 2 == 1)
                    startSq.BackColor = Color.Gray;
                else
                    startSq.BackColor = Color.White;
            }
            else
            {
                if (startSqPos[1] % 2 == 1)
                    startSq.BackColor = Color.White;
                else
                    startSq.BackColor = Color.Gray;
            }
            // Removes the piece from the starting square and puts it on the end square
            position[startSqPos[0], startSqPos[1]] = "";
            position[endSqPos[0], endSqPos[1]] = selectedPieceAnnotation;

            char _pieceAnnotation = selectedPieceAnnotation[1];

            if(_pieceAnnotation == 'P')
            {
                _pieceAnnotation = ' ';
            }

            var pBoxNameSplit = endSq.Name.Split('x');

            string _plyAnnotation = _pieceAnnotation + pBoxNameSplit[1];

            var newPly = new Ply()
            {
                color = color,
                moveNumber = moveNmbr,
                pieceAnnotation = _pieceAnnotation,
                startSqColumn = startSqPos[1],
                startSqRow = startSqPos[0],
                endSqColumn = endSqPos[1],
                endSqRow = endSqPos[0],
                plyAnnotation = _plyAnnotation
            };

            switch(color)
            {
                case "white":
                    currentMove = new Move()
                    {
                        whitePly = newPly,
                        moveNumber = moveNmbr
                    };
                    gameMoves.Add(currentMove);
                    color = "black";
                    break;
                case "black":
                    gameMoves.RemoveAt(gameMoves.Count() - 1);
                    gameMoves.Add(currentMove);
                    currentMove.blackPly = newPly;
                    color = "white";
                    moveNmbr += 1;
                    break;
            }

            UpdateMoveList();

            startSq = null;
            endSq = null;
            SetPosition();
            return false;
        }

        //Selects a square to perform a move
        private void SelectSquare(PictureBox square)
        {
            //´
            if(startSq == null)
            {
                if (square.Image != null)
                {
                    startSq = square;
                    startSqPos = GetSquarePos(square.Name);
                    selectedPieceAnnotation = position[startSqPos[0], startSqPos[1]];

                    if (color == "white" && selectedPieceAnnotation[0] == 'w')
                    {
                        square.BackColor = Color.Brown;
                    }
                    else if (color == "black" && selectedPieceAnnotation[0] == 'b')
                    {
                        square.BackColor = Color.Brown;
                    }
                    else
                        startSq = null;
                }
                else
                    return;
            }
            else
            {
                endSqPos = GetSquarePos(square.Name);
                endSq = square;
                CompleteMove();
            }
        }

        // Returns two int values that represents the position of the square in currentGame.position
        private int[] GetSquarePos(string pBoxName)
        {
            string[] squareString = pBoxName.Split('x');

            int[] squarePos = new int[2];
            squarePos[0] = Int32.Parse(squareString[1][1].ToString()) - 1;

            switch (squareString[1][0])
            {
                case 'a':
                    squarePos[1] = 0;
                    break;
                case 'b':
                    squarePos[1] = 1;
                    break;
                case 'c':
                    squarePos[1] = 2;
                    break;
                case 'd':
                    squarePos[1] = 3;
                    break;
                case 'e':
                    squarePos[1] = 4;
                    break;
                case 'f':
                    squarePos[1] = 5;
                    break;
                case 'g':
                    squarePos[1] = 6;
                    break;
                case 'h':
                    squarePos[1] = 7;
                    break;
            }

            return squarePos;
        }


        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            //gameService.Add(gameMoves, txtBlackPlayer.Text, txtWhitePlayer.Text, dateGameDate.Value);
        }

        private void pBoxa1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh1_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh2_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh3_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh4_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh5_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh6_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh7_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxa8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxb8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxc8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxd8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxe8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxf8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxg8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void pBoxh8_Click(object sender, EventArgs e)
        {
            PictureBox square = (PictureBox)sender;

            SelectSquare(square);
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            ManagePlayers newForm = new ManagePlayers();
            newForm.Show();
        }
    }
}
