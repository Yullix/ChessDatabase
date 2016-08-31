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
    public static class ChessLogic
    {
        /// <summary>
        /// Returns 2 int values that represents the position of the square in a 8x8 jagged array
        /// </summary>
        /// <param name="pBoxName"></param>
        /// <returns>int[2]</returns>
        public static int[] GetSquarePos(string pBoxName)
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

        /// <summary>
        /// returns a 8x8 jagged array of strings that represents the board in the starting position
        /// </summary>
        /// <returns>string[8,8]</returns>
        public static string[,] GetStartPosition()
        {
            string[,] startPosition = new string[8, 8];

            // White starting position
            startPosition[0, 0] = "wR";
            startPosition[0, 1] = "wN";
            startPosition[0, 2] = "wB";
            startPosition[0, 3] = "wQ";
            startPosition[0, 4] = "wK";
            startPosition[0, 5] = "wB";
            startPosition[0, 6] = "wN";
            startPosition[0, 7] = "wR";
            startPosition[1, 0] = "wP";
            startPosition[1, 1] = "wP";
            startPosition[1, 2] = "wP";
            startPosition[1, 3] = "wP";
            startPosition[1, 4] = "wP";
            startPosition[1, 5] = "wP";
            startPosition[1, 6] = "wP";
            startPosition[1, 7] = "wP";

            //Black starting position
            startPosition[7, 0] = "bR";
            startPosition[7, 1] = "bN";
            startPosition[7, 2] = "bB";
            startPosition[7, 3] = "bQ";
            startPosition[7, 4] = "bK";
            startPosition[7, 5] = "bB";
            startPosition[7, 6] = "bN";
            startPosition[7, 7] = "bR";
            startPosition[6, 0] = "bP";
            startPosition[6, 1] = "bP";
            startPosition[6, 2] = "bP";
            startPosition[6, 3] = "bP";
            startPosition[6, 4] = "bP";
            startPosition[6, 5] = "bP";
            startPosition[6, 6] = "bP";
            startPosition[6, 7] = "bP";

            return startPosition;
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
        public static bool CheckLegality(string[,] _position, char _pieceAnnotation, string _color, bool _whiteCastle, bool _blackCastle, int[] _startSq, int[] _endSq, Ply _lastPly)
        {
            string capturedPiece = _position[_endSq[0], _endSq[1]];

            if(_color == "white")
            {
                switch (_pieceAnnotation)
                {
                    case 'P':
                        if (capturedPiece != null)
                        {
                            // If a piece was captured that wasnt diagonally straight infront of the pawn return false
                            if (_endSq[0] - _startSq[0] != 1 || (_startSq[1] - _endSq[1] != 1 && _endSq[1] - _startSq[1] != 1))
                                return false;
                            // else the move is legal and return true
                            else
                                return true;
                        }
                        else
                        {
                            // If a pawn is taken en passant return true
                            if (_startSq[0] == 4 && _lastPly.plyAnnotation[0] == 'P' && _lastPly.startSqRow == 6 && _lastPly.endSqRow == 4 && (_lastPly.endSqColumn - _startSq[1] == 1 || _startSq[1] - _lastPly.endSqColumn == 1) && _lastPly.endSqColumn == _endSq[1])
                                return true;
                            // If pawn tries to move sideways without capturing a piece return false
                            if (_startSq[1] - _endSq[1] != 0)
                                return false;
                            // If the pawn moves further than 1 square and is not on the 2nd row return false
                            if (_endSq[0] - _startSq[0] > 1 && _startSq[0] != 1)
                                return false;
                            // If the pawn moves further than 2 squares and is on the 2nd row return false
                            if (_endSq[0] - _startSq[0] > 2 && _startSq[0] == 1)
                                return false;
                            // If the pawn moves past another piece return false
                            if (_endSq[0] - _startSq[0] > 1 && _position[_endSq[0] - 1, _endSq[1]] != null)
                                return false;
                        }
                        break;
                    case 'N':
                        // If the knight doesnt make an 'L' move return false
                        // If the knight lands on a square containing a same colored piece return false
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
            else
            {
                switch(_pieceAnnotation)
                {
                    case 'P':
                        if (capturedPiece != null)
                        {
                            // If a piece was captured that wasnt diagonally straight infront of the pawn return false
                            if (_startSq[0] - _endSq[0] != 1 || (_endSq[1] - _startSq[1] != 1 && _startSq[1] - _endSq[1] != 1))
                                return false;
                            // else the move is legal and return true
                            else
                                return true;
                        }
                        else
                        {
                            // If a pawn is taken en passant return true
                            if (_startSq[0] == 3 && _lastPly.plyAnnotation[0] == 'P' && _lastPly.startSqRow == 1 && _lastPly.endSqRow == 3 && (_lastPly.endSqColumn - _startSq[1] == 1 || _startSq[1] - _lastPly.endSqColumn == 1) && _lastPly.endSqColumn == _endSq[1])
                                return true;
                            // If pawn tries to move sideways without capturing a piece return false
                            if (_startSq[1] - _endSq[1] != 0)
                                return false;
                            // If the pawn moves further than 1 square and is not on the 2nd row return false
                            if (_startSq[0] - _endSq[0] > 1 && _startSq[0] != 6)
                                return false;
                            // If the pawn moves further than 2 squares and is on the 2nd row return false
                            if (_startSq[0] - _endSq[0] > 2 && _startSq[0] == 6)
                                return false;
                            // If the pawn moves past another piece return false
                            if (_startSq[0] - _endSq[0] > 1 && _position[_endSq[0] + 1, _endSq[1]] != null)
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
        /// <returns></returns>
        public static string[,] NextMove(string[,] _position, Ply _nextPly)
        {
            string[,] position = _position;
            char pieceAnnotation = _nextPly.plyAnnotation[0];

            switch(_nextPly.color)
            {
                case "white":
                    position[_nextPly.startSqRow, _nextPly.startSqColumn] = null;
                    position[_nextPly.endSqRow, _nextPly.endSqColumn] = "w" + pieceAnnotation.ToString();
                    break;
                case "black":
                    position[_nextPly.startSqRow, _nextPly.startSqColumn] = null;
                    position[_nextPly.endSqRow, _nextPly.endSqColumn] = "b" + pieceAnnotation.ToString();
                    break;
            }            

            return position;
        }

        /// <summary>
        /// Returns a position after undoing the ply the argument position
        /// </summary>
        /// <param name="_position"></param>
        /// <param name="_lastPly"></param>
        /// <returns>string[8,8]</returns>
        public static string[,] UndoMove(string[,] _position, Ply _lastPly)
        {
            string[,] position = _position;
            char pieceAnnotation = _lastPly.plyAnnotation[0];

            switch (_lastPly.color)
            {
                case "white":
                    position[_lastPly.startSqRow, _lastPly.startSqColumn] = "w" + pieceAnnotation.ToString();
                    position[_lastPly.endSqRow, _lastPly.endSqColumn] = _lastPly.capturedPieceAnnotation;
                    break;
                case "black":
                    position[_lastPly.startSqRow, _lastPly.startSqColumn] = "b" + pieceAnnotation.ToString();
                    position[_lastPly.endSqRow, _lastPly.endSqColumn] = _lastPly.capturedPieceAnnotation;
                    break;
            }

            return position;
        }
    }
}
