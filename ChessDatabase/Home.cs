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
    public partial class Home : MainForm
    {
        private PictureBox _startSq;
        private PictureBox _endSq;
        private int[] _startSqPos;
        private int[] _endSqPos;
        private string[,] _position;
        private static string _selectedPieceAnnotation;
        private string _color;
        private string _capturedPieceAnnotation;
        private string _promotionPiece;
        private int _moveNmbr;
        private bool _whiteCastle;
        private bool _blackCastle;
        private Assembly _currentAssembly;
        private Stream _whitePawnStream;
        private Stream _whiteKnightStream;
        private Stream _whiteBishopStream;
        private Stream _whiteRookStream;
        private Stream _whiteQueenStream;
        private Stream _whiteKingStream;
        private Stream _blackPawnStream;
        private Stream _blackKnightStream;
        private Stream _blackBishopStream;
        private Stream _blackRookStream;
        private Stream _blackQueenStream;
        private Stream _blackKingStream;
        private PlayerService _playerService;
        private MatchService _matchService;
        private OpeningService _openingService;
        private RepositoryFactory _repoFactory;
        private List<Move> _gameMoves;
        private List<Ply> _gamePlies;
        private Move _currentMove;

        public Home()
        {
            InitializeComponent();

            _repoFactory = new RepositoryFactory();
            _matchService = new MatchService(_repoFactory);
            _playerService = new PlayerService(_repoFactory);
            _openingService = new OpeningService(_repoFactory);

            ChessLogic.EnPassant += SetCapturedPiece;
            ChessLogic.PawnPromote += PromotePawn;

            _gameMoves = new List<Move>();
            _gamePlies = new List<Ply>();
            _color = "white";
            _position = ChessLogic.GetStartPosition();
            _moveNmbr = 1;
            _whiteCastle = true;
            _blackCastle = true;

            _startSq = null;
            _endSq = null;
            _startSqPos = new int[2];
            _endSqPos = new int[2];
            _selectedPieceAnnotation = "";
            _capturedPieceAnnotation = "";

            foreach(var p in _playerService.All())
            {
                cboxWhitePlayer.Items.Add(p);
                cboxBlackPlayer.Items.Add(p);
            }

            //var check = this.GetType().Assembly.GetManifestResourceNames();

            _currentAssembly = Assembly.GetExecutingAssembly();

            _whitePawnStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whitePawn.png");
            _whiteKnightStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteKnight.png");
            _whiteBishopStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteBishop.png");
            _whiteRookStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteRook.png");
            _whiteQueenStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteQueen.png");
            _whiteKingStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteKing.png");

            _blackPawnStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackPawn.png");
            _blackKnightStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackKnight.png");
            _blackBishopStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackBishop.png");
            _blackRookStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackRook.png");
            _blackQueenStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackQueen.png");
            _blackKingStream = _currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackKing.png");

            SetPosition();
        }

        // Sets capturedPiece when event en passant is triggered in ChessLogic
        private void SetCapturedPiece(object sender, EventArgs e)
        {
            ChessLogicEventArgs args = (ChessLogicEventArgs)e;

            if (args.color == "white")
                _capturedPieceAnnotation = "w" + "P";
            else
                _capturedPieceAnnotation = "b" + "p";
        }

        // Opens a new form with a dialog to select a promotion piece
        private void PromotePawn(object sender, EventArgs e)
        {
            ChessLogicEventArgs _args = (ChessLogicEventArgs)e;
            using (var form = new PromotionDialog(_args.color))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string _piece;

                    if (_color == "white")
                    {
                        _piece = "w" + form.selectedPromotionPiece;
                        _position[7, _args.column] = _piece;
                    }
                    else
                    {
                        _piece = "b" + form.selectedPromotionPiece;
                        _position[0, _args.column] = _piece;
                    }
                    SetPosition();

                    _promotionPiece = _piece;
                }
                else
                    PromotePawn(this, e);
            }
        }

        // Greates the graphical position from the jagged string array (position)
        public void SetPosition()
        {
            for (int c = 0; c < 8; c++)
            {
                char _row = 'a';
                for (int r = 0; r < 8; r++)
                {
                    PictureBox pSquare = this.Controls.Find("pBox" + _row + (c + 1), true).FirstOrDefault() as PictureBox;
                    switch (_position[c, r])
                    {
                        case "wP":
                            pSquare.Image = new Bitmap(_whitePawnStream);
                            break;
                        case "wN":
                            pSquare.Image = new Bitmap(_whiteKnightStream);
                            break;
                        case "wB":
                            pSquare.Image = new Bitmap(_whiteBishopStream);
                            break;
                        case "wR":
                            pSquare.Image = new Bitmap(_whiteRookStream);
                            break;
                        case "wQ":
                            pSquare.Image = new Bitmap(_whiteQueenStream);
                            break;
                        case "wK":
                            pSquare.Image = new Bitmap(_whiteKingStream);
                            break;
                        case "bP":
                            pSquare.Image = new Bitmap(_blackPawnStream);
                            break;
                        case "bN":
                            pSquare.Image = new Bitmap(_blackKnightStream);
                            break;
                        case "bB":
                            pSquare.Image = new Bitmap(_blackBishopStream);
                            break;
                        case "bR":
                            pSquare.Image = new Bitmap(_blackRookStream);
                            break;
                        case "bQ":
                            pSquare.Image = new Bitmap(_blackQueenStream);
                            break;
                        case "bK":
                            pSquare.Image = new Bitmap(_blackKingStream);
                            break;
                        default:
                            pSquare.Image = null;
                            break;
                    }
                    switch (_row)
                    {
                        case 'a':
                            _row = 'b';
                            break;
                        case 'b':
                            _row = 'c';
                            break;
                        case 'c':
                            _row = 'd';
                            break;
                        case 'd':
                            _row = 'e';
                            break;
                        case 'e':
                            _row = 'f';
                            break;
                        case 'f':
                            _row = 'g';
                            break;
                        case 'g':
                            _row = 'h';
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

            foreach(var m in _gameMoves)
            {
                lstMoves.Items.Add(m);
            }
        }

        //Completes a move after a square with a piece on it and an empty square has been selected
        public void CompleteMove()
        {
            // Changes the color of the starting square back to its original color
            if(_startSqPos[0] % 2 == 1)
            {
                if (_startSqPos[1] % 2 == 1)
                    _startSq.BackColor = Color.Gray;
                else
                    _startSq.BackColor = Color.White;
            }
            else
            {
                if (_startSqPos[1] % 2 == 1)
                    _startSq.BackColor = Color.White;
                else
                    _startSq.BackColor = Color.Gray;
            }

            char _pieceAnnotation = _selectedPieceAnnotation[1];
            
            Ply _lastPly = new Ply() { plyAnnotation = "none" };
            try
            {
                _lastPly = _gamePlies[_gamePlies.Count() - 1];
            }
            catch
            {
            }     
            // Checks if the move is legal
            if (ChessLogic.CheckLegality(_position, _pieceAnnotation, _color, _whiteCastle, _blackCastle, _startSqPos, _endSqPos, _lastPly))
            {
                // Updates white's ability to castle
                if(_pieceAnnotation == 'K' && _whiteCastle)
                    _whiteCastle = false;

                //Updates black's ability to castle
                if (_pieceAnnotation == 'K' && _blackCastle)
                    _blackCastle = false;

                var pBoxNameSplit = _endSq.Name.Split('x');

                string _plyAnnotation = _pieceAnnotation + pBoxNameSplit[1];

                var _newPly = new Ply()
                {
                    color = _color,
                    moveNumber = _moveNmbr,
                    startSqColumn = _startSqPos[1],
                    startSqRow = _startSqPos[0],
                    endSqColumn = _endSqPos[1],
                    endSqRow = _endSqPos[0],
                    plyAnnotation = _plyAnnotation,
                    capturedPieceAnnotation = _position[_endSqPos[0], _endSqPos[1]] ?? this._capturedPieceAnnotation
                };

                _capturedPieceAnnotation = "";

                _gamePlies.Add(_newPly);

                _position = ChessLogic.NextMove(_position, _newPly);

                switch (_color)
                {
                    case "white":
                        _currentMove = new Move()
                        {
                            whitePly = _newPly,
                            moveNumber = _moveNmbr
                        };
                        _gameMoves.Add(_currentMove);
                        _color = "black";
                        break;
                    case "black":
                        _gameMoves.RemoveAt(_gameMoves.Count() - 1);
                        _gameMoves.Add(_currentMove);
                        _currentMove.blackPly = _newPly;
                        _color = "white";
                        _moveNmbr += 1;
                        break;
                }

                UpdateMoveList();
                SetPosition();
            }

            _startSq = null;
            _endSq = null;
        }

        //Selects a square to perform a move
        private void SelectSquare(PictureBox square)
        {
            // checks if there is a start square selected already
            if(_startSq == null)
            {
                // if the square does not hold a piece it cannot be selected as start square.
                if (square.Image != null)
                {
                    _startSq = square;
                    _startSqPos = ChessLogic.GetSquarePos(square.Name);
                    _selectedPieceAnnotation = _position[_startSqPos[0], _startSqPos[1]];

                    if (_color == "white" && _selectedPieceAnnotation[0] == 'w')
                    {
                        square.BackColor = Color.Brown;
                    }
                    else if (_color == "black" && _selectedPieceAnnotation[0] == 'b')
                    {
                        square.BackColor = Color.Brown;
                    }
                    else
                        _startSq = null;
                }
                else
                    return;
            }
            else
            {
                _endSqPos = ChessLogic.GetSquarePos(square.Name);
                _endSq = square;
                CompleteMove();
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            try
            {
                Player whitePlayer = (Player)cboxWhitePlayer.SelectedItem;
                Player blackPlayer = (Player)cboxBlackPlayer.SelectedItem;
                _matchService.Add(_gamePlies, whitePlayer.name + " vs. " + blackPlayer.name + " - " + dateGameDate.Value.ToString("dd/MM/yyyy"), blackPlayer.Id, whitePlayer.Id, dateGameDate.Value, null);
                MessageBox.Show("The game was successfully saved.");
            }
            catch
            {
                MessageBox.Show("You must select a white and a black player.");
            }
        }

        private void btnSaveOpening_Click(object sender, EventArgs e)
        {
            try
            {
                _openingService.Add(_gamePlies, txtOpeningName.Text, _gamePlies[0].plyAnnotation);
            }
            catch(ArgumentException excp)
            {
                MessageBox.Show(excp.Message, "Error");
            }
            catch(DuplicateException excp)
            {
                MessageBox.Show(excp.Message, "Error");
            }
            catch
            {
                MessageBox.Show("Oops! Something went wrong.", "Error");
            }
        }

        private void btnUndoMove_Click(object sender, EventArgs e)
        {
            try
            {
                _position = ChessLogic.UndoMove(_position, _gamePlies.Last());
                _gamePlies.RemoveAt(_gamePlies.Count() - 1);

                switch (_gamePlies.Last().color)
                {
                    case "white":
                        _gameMoves.RemoveAt(_gameMoves.Count() - 1);
                        _color = "black";
                        _moveNmbr -= 1;
                        break;
                    case "black":
                        Move moveHolder = _gameMoves.Last();
                        _gameMoves.RemoveAt(_gameMoves.Count() - 1);
                        moveHolder.blackPly = null;
                        _gameMoves.Add(moveHolder);
                        _color = "white";
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
