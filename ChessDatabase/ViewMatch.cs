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
using System.Reflection;
using System.IO;

namespace ChessDatabase
{
    public partial class ViewMatch : Form
    {
        public Match match;
        public string[,] position;
        public List<Move> gameMoves;
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
        private int currentPlyIndex;

        public ViewMatch(Match _match)
        {
            InitializeComponent();
            this.match = _match;
            txtWhitePlayer.Text = _match.whitePlayer.ToString();
            txtBlackPlayer.Text = _match.blackPlayer.ToString();
            txtDate.Text = _match.date.ToString("dd/MM/yyyy");
            position = ChessLogic.GetStartPosition();
            gameMoves = new List<Move>();
            currentPlyIndex = 0;

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

            Move moveHolder = new Move();
            foreach(var p in _match.plies)
            {
                if (p.color == "white")
                {
                    moveHolder = new Move();
                    moveHolder.whitePly = p;
                }
                else
                {
                    moveHolder.moveNumber = p.moveNumber;
                    moveHolder.game = match;
                    moveHolder.blackPly = p;
                    gameMoves.Add(moveHolder);
                }
            }

            gameMoves.ForEach(m => lstMoves.Items.Add(m));
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

        private void btnNextMove_Click(object sender, EventArgs e)
        {
            try
            {
                position = ChessLogic.NextMove(position, match.plies.ElementAt(currentPlyIndex));
                currentPlyIndex += 1;
                SetPosition();
            }
            catch
            { }
        }

        private void btnLastMove_Click(object sender, EventArgs e)
        {
            try
            {
                position = ChessLogic.UndoMove(position, match.plies.ElementAt(currentPlyIndex - 1));
                currentPlyIndex -= 1;
                SetPosition();
            }
            catch
            { }
        }
    }
}
