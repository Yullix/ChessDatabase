using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

//Ted Torkkeli
// 2016-08-01

namespace ChessDatabase
{
    public class ChessLogicEventArgs : EventArgs
    {
        public string color;
        public int column;

        public ChessLogicEventArgs(string color, int column)
        {
            this.color = color;
            this.column = column;
        }
    }

    public static class ChessLogic
    {

        public static event EventHandler PawnPromote;
        public static event EventHandler EnPassant;

        /// <summary>
        /// Returns 2 int values that represents the position of a square in a 8x8 jagged array
        /// </summary>
        /// <param name="pBoxName"></param>
        /// <returns>int[2] [0] = row [1] = column</returns>
        public static int[] GetSquarePos(string pBoxName)
        {
            string[] _squareString = pBoxName.Split('x');

            int[] _squarePos = new int[2];
            _squarePos[0] = Int32.Parse(_squareString[1][1].ToString()) - 1;

            switch (_squareString[1][0])
            {
                case 'a':
                    _squarePos[1] = 0;
                    break;
                case 'b':
                    _squarePos[1] = 1;
                    break;
                case 'c':
                    _squarePos[1] = 2;
                    break;
                case 'd':
                    _squarePos[1] = 3;
                    break;
                case 'e':
                    _squarePos[1] = 4;
                    break;
                case 'f':
                    _squarePos[1] = 5;
                    break;
                case 'g':
                    _squarePos[1] = 6;
                    break;
                case 'h':
                    _squarePos[1] = 7;
                    break;
            }

            return _squarePos;
        }

        /// <summary>
        /// returns a 8x8 jagged array of strings that represents the board in the starting position
        /// </summary>
        /// <returns>string[8,8]</returns>
        public static string[,] GetStartPosition()
        {
            string[,] _startPosition = new string[8, 8];

            // White starting position
            _startPosition[0, 0] = "wR";
            _startPosition[0, 1] = "wN";
            _startPosition[0, 2] = "wB";
            _startPosition[0, 3] = "wQ";
            _startPosition[0, 4] = "wK";
            _startPosition[0, 5] = "wB";
            _startPosition[0, 6] = "wN";
            _startPosition[0, 7] = "wR";
            _startPosition[1, 0] = "wP";
            _startPosition[1, 1] = "wP";
            _startPosition[1, 2] = "wP";
            _startPosition[1, 3] = "wP";
            _startPosition[1, 4] = "wP";
            _startPosition[1, 5] = "wP";
            _startPosition[1, 6] = "wP";
            _startPosition[1, 7] = "wP";

            //Black starting position
            _startPosition[7, 0] = "bR";
            _startPosition[7, 1] = "bN";
            _startPosition[7, 2] = "bB";
            _startPosition[7, 3] = "bQ";
            _startPosition[7, 4] = "bK";
            _startPosition[7, 5] = "bB";
            _startPosition[7, 6] = "bN";
            _startPosition[7, 7] = "bR";
            _startPosition[6, 0] = "bP";
            _startPosition[6, 1] = "bP";
            _startPosition[6, 2] = "bP";
            _startPosition[6, 3] = "bP";
            _startPosition[6, 4] = "bP";
            _startPosition[6, 5] = "bP";
            _startPosition[6, 6] = "bP";
            _startPosition[6, 7] = "bP";

            return _startPosition;
        }

        /// <summary>
        /// Returns a boolean value that represents wether the input move is legal or not
        /// </summary>
        /// <param name="_position"></param>
        /// <param name="_pieceAnnotation"></param>
        /// <param name="_color"></param>
        /// <param name="_whiteCastle"></param>
        /// <param name="_blackCastle"></param>
        /// <param name="_startSq"></param>
        /// <param name="_endSq"></param>
        /// <returns>bool</returns>
        public static bool CheckLegality(string[,] position, char pieceAnnotation, string color, bool whiteCastle, bool blackCastle, int[] startSq, int[] endSq, Ply lastPly)
        {
            string _capturedPiece = position[endSq[0], endSq[1]];

            if(color == "white")
            {
                switch (pieceAnnotation)
                {
                    case 'P':
                        if (_capturedPiece != null)
                        {
                            // If a piece was captured that wasnt diagonally straight infront of the pawn return false
                            if (endSq[0] - startSq[0] != 1 || (Math.Abs(endSq[1] - startSq[1]) != 1))
                                return false;
                            // else the move is legal and return true
                            else
                                return true;
                        }
                        else
                        {
                            // If a pawn is taken en passant return true
                            if (startSq[0] == 4 && lastPly.plyAnnotation[0] == 'P' && lastPly.startSqRow == 6 && lastPly.endSqRow == 4 && (lastPly.endSqColumn - startSq[1] == 1 || startSq[1] - lastPly.endSqColumn == 1) && lastPly.endSqColumn == endSq[1])
                                return true;
                            // If pawn tries to move sideways without capturing a piece return false
                            if (startSq[1] - endSq[1] != 0)
                                return false;
                            // If the pawn moves further than 1 square and is not on the 2nd row return false
                            if (endSq[0] - startSq[0] > 1 && startSq[0] != 1)
                                return false;
                            // If the pawn moves further than 2 squares and is on the 2nd row return false
                            if (endSq[0] - startSq[0] > 2 && startSq[0] == 1)
                                return false;
                            // If the pawn moves past another piece return false
                            if (endSq[0] - startSq[0] > 1 && position[endSq[0] - 1, endSq[1]] != null)
                                return false;
                            // If the pawn tried to move backwards return false
                            if (endSq[0] - startSq[0] < 1)
                                return false;
                        }
                        break;
                    case 'N':                     
                        // If the knight lands on a square containing a same colored piece return false
                        if (position[endSq[0], endSq[1]] != null && position[endSq[0], endSq[1]][0] == 'w')
                            return false;
                        // If the knight makes an 'L' shaped move return true
                        if ((Math.Abs(endSq[0] - startSq[0]) == 2 && Math.Abs(endSq[1] - startSq[1]) == 1) || (Math.Abs(endSq[0] - startSq[0]) == 1 && Math.Abs(endSq[1] - startSq[1]) == 2))
                            return true;
                        else
                            return false;
                    case 'B':
                        // If the bishop doesn't move in a diagonal line return false
                        if(Math.Abs(endSq[0] - startSq[0]) != Math.Abs(endSq[1] - startSq[1]))
                            return false;
                        // If there is a piece between the start square and the end square return false
                        for(int i = 1; i > 0; i++)
                        {

                        }
                        break;
                    case 'R':
                        // If the rook doesn't move in a straight line return false
                        if (Math.Abs(endSq[0] - startSq[0]) != 0 && Math.Abs(endSq[1] - startSq[1]) != 0)
                            return false;
                        // If there is a piece between the start square and the end square return false
                        break;
                    case 'Q':
                        // If the queen doesn't move in a straight/diagonal line return false
                        // If there is a piece between the start square and the end square return false
                        break;
                    case 'K':
                        // If the king can castle and moves 2 steps to either direction and no piece blocking and no piece attacking the squares the king moves over, return true
                        // If the king moves 1 square either direction and does not collide with an allied piece return true
                        // Else return false
                        break;
                    default:
                        return false;
                }
            }
            else
            {
                switch(pieceAnnotation)
                {
                    case 'P':
                        if (_capturedPiece != null)
                        {
                            // If a piece was captured that wasnt diagonally straight infront of the pawn return false
                            if (startSq[0] - endSq[0] != 1 || (endSq[1] - startSq[1] != 1 && startSq[1] - endSq[1] != 1))
                                return false;
                            // else the move is legal and return true
                            else
                                return true;
                        }
                        else
                        {
                            // If a pawn is taken en passant return true
                            if (startSq[0] == 3 && lastPly.plyAnnotation[0] == 'P' && lastPly.startSqRow == 1 && lastPly.endSqRow == 3 && (lastPly.endSqColumn - startSq[1] == 1 || startSq[1] - lastPly.endSqColumn == 1) && lastPly.endSqColumn == endSq[1])
                                return true;
                            // If pawn tries to move sideways without capturing a piece return false
                            if (startSq[1] - endSq[1] != 0)
                                return false;
                            // If the pawn moves further than 1 square and is not on the 2nd row return false
                            if (startSq[0] - endSq[0] > 1 && startSq[0] != 6)
                                return false;
                            // If the pawn moves further than 2 squares and is on the 2nd row return false
                            if (startSq[0] - endSq[0] > 2 && startSq[0] == 6)
                                return false;
                            // If the pawn moves past another piece return false
                            if (startSq[0] - endSq[0] > 1 && position[endSq[0] + 1, endSq[1]] != null)
                                return false;
                            // If the pawn tries to move backwards return false
                            if (startSq[0] - endSq[0] < 0)
                                return false;
                        }
                        break;
                    case 'N':
                        break;
                    case 'B':
                        break;
                    case 'R':
                        break;
                    case 'Q':
                        break;
                    case 'K':
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the position after making the ply in the argument position
        /// </summary>
        /// <param name="_position"></param>
        /// <param name="_nextPly"></param>
        /// <returns>string[8,8]</returns>
        public static string[,] NextMove(string[,] position, Ply nextPly)
        {
            string[,] _position = position;
            char _pieceAnnotation = nextPly.plyAnnotation[0];

            // If en passant
            if (nextPly.plyAnnotation[0] == 'P' && nextPly.startSqColumn != nextPly.endSqColumn && nextPly.capturedPieceAnnotation == "")
            {
                _position[nextPly.startSqRow, nextPly.startSqColumn] = null;
                
                if (nextPly.color == "white")
                {
                    _position[nextPly.endSqRow, nextPly.endSqColumn] = "w" + _pieceAnnotation.ToString();
                    _position[nextPly.endSqRow - 1, nextPly.endSqColumn] = null;
                }

                OnEnPassant(new ChessLogicEventArgs(nextPly.color, nextPly.endSqColumn));

                return _position;
            }

            switch (nextPly.color)
            {
                case "white":
                    _position[nextPly.startSqRow, nextPly.startSqColumn] = null;
                    _position[nextPly.endSqRow, nextPly.endSqColumn] = "w" + _pieceAnnotation.ToString();
                    break;
                case "black":
                    _position[nextPly.startSqRow, nextPly.startSqColumn] = null;
                    _position[nextPly.endSqRow, nextPly.endSqColumn] = "b" + _pieceAnnotation.ToString();
                    break;
            }

            // If a pawn reaches the 8th rank
            if (nextPly.plyAnnotation[0] == 'P' && (nextPly.endSqRow == 7 || nextPly.endSqRow == 0))
            {
                OnPawnPromote(new ChessLogicEventArgs(nextPly.color, nextPly.endSqColumn));
            }

            return _position;
        }

        /// <summary>
        /// Returns a position after undoing the ply in the argument position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="lastPly"></param>
        /// <returns>string[8,8]</returns>
        public static string[,] UndoMove(string[,] position, Ply lastPly)
        {
            string[,] _position = position;
            char _pieceAnnotation = lastPly.plyAnnotation[0];

            switch (lastPly.color)
            {
                case "white":
                    _position[lastPly.startSqRow, lastPly.startSqColumn] = "w" + _pieceAnnotation.ToString();
                    _position[lastPly.endSqRow, lastPly.endSqColumn] = lastPly.capturedPieceAnnotation;
                    break;
                case "black":
                    _position[lastPly.startSqRow, lastPly.startSqColumn] = "b" + _pieceAnnotation.ToString();
                    _position[lastPly.endSqRow, lastPly.endSqColumn] = lastPly.capturedPieceAnnotation;
                    break;
            }

            return _position;
        }

        public static void OnPawnPromote(ChessLogicEventArgs e)
        {
            PawnPromote?.Invoke(new object(), e);
        }

        public static void OnEnPassant(ChessLogicEventArgs e)
        {
            EnPassant?.Invoke(new object(), e);
        }
    }
}
