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
        private bool whiteCastle;
        private bool blackCastle;
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
        private PlayerService _playerService;
        private MatchService _matchService;
        private RepositoryFactory _repoFactory;
        private List<Move> gameMoves;
        private List<Ply> gamePlies;
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

        public PlayerService playerService
        {
            get
            {
                return _playerService ?? new PlayerService(repoFactory);
            }
            private set
            {
                _playerService = value;
            }
        }

        public MatchService matchService
        {
            get
            {
                return _matchService ?? new MatchService(repoFactory);
            }
            private set
            {
                _matchService = value;
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
            gamePlies = new List<Ply>();
            color = "white";
            position = ChessLogic.GetStartPosition();
            moveNmbr = 1;
            whiteCastle = true;
            blackCastle = true;

            startSq = null;
            endSq = null;
            startSqPos = new int[2];
            endSqPos = new int[2];
            selectedPieceAnnotation = "";

            foreach(var p in playerService.All())
            {
                cboxWhitePlayer.Items.Add(p);
                cboxBlackPlayer.Items.Add(p);
            }

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

        // Greates the graphical position from the jagged string array (position)
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
            lstMoves.Items.Clear();

            foreach(var m in gameMoves)
            {
                lstMoves.Items.Add(m);
            }
        }

        //Completes a move after a square with a piece on it and an empty square has been selected
        public void CompleteMove()
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

            char _pieceAnnotation = selectedPieceAnnotation[1];

            // Checks if the move is legal
            if (ChessLogic.CheckLegality(position, _pieceAnnotation, color, whiteCastle, blackCastle, startSqPos, endSqPos))
            {
                // Updates white's ability to castle
                if(_pieceAnnotation == 'K' && whiteCastle)
                    whiteCastle = false;

                //Updates black's ability to castle
                if (_pieceAnnotation == 'K' && blackCastle)
                    blackCastle = false;

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

                gamePlies.Add(newPly);

                position = ChessLogic.NextMove(position, newPly);

                switch (color)
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
                SetPosition();
            }

            startSq = null;
            endSq = null;
        }

        //Selects a square to perform a move
        private void SelectSquare(PictureBox square)
        {
            // checks if there is a start square selected already
            if(startSq == null)
            {
                // if the square does not hold a piece it cannot be selected as start square.
                if (square.Image != null)
                {
                    startSq = square;
                    startSqPos = ChessLogic.GetSquarePos(square.Name);
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
                endSqPos = ChessLogic.GetSquarePos(square.Name);
                endSq = square;
                CompleteMove();
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            try
            {
                Player whitePlayer = (Player)cboxWhitePlayer.SelectedItem;
                Player blackPlayer = (Player)cboxBlackPlayer.SelectedItem;
                matchService.Add(gamePlies, whitePlayer.name + " vs. " + blackPlayer.name + " - " + dateGameDate.Value.Date, blackPlayer.Id, whitePlayer.Id, dateGameDate.Value, null);
                MessageBox.Show("The game was successfully saved.");
            }
            catch
            {
                MessageBox.Show("You must select a white and a black player.");
            }
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePlayers newForm = new ManagePlayers();
            newForm.Show();
        }

        private void btnUndoMove_Click(object sender, EventArgs e)
        {
            try
            {
                position = ChessLogic.UndoMove(position, gamePlies.Last());
                gamePlies.RemoveAt(gamePlies.Count() - 1);

                switch (gamePlies.Last().color)
                {
                    case "white":
                        gameMoves.RemoveAt(gameMoves.Count() - 1);
                        color = "black";
                        moveNmbr -= 1;
                        break;
                    case "black":
                        Move moveHolder = gameMoves.Last();
                        gameMoves.RemoveAt(gameMoves.Count() - 1);
                        moveHolder.blackPly = null;
                        gameMoves.Add(moveHolder);
                        color = "white";
                        break;
                }

                UpdateMoveList();
                SetPosition();
            }
            catch
            {
                
            }
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
    }
}
