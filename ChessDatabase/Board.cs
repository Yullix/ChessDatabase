using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessDatabase.Models;

namespace ChessDatabase
{
    public class Board
    {
        public PictureBox[,] board;

        public Board()
        {
            board = new PictureBox[8, 8];

            for (int row = 0; row < 8; row++)
            {
                for(int column = 0; column < 8; column++)
                {
                    board[row, column] = new PictureBox();
                    board[row, column].Width = 6;
                    board[row, column].Height = 6;
                    board[row, column].BorderStyle = BorderStyle.FixedSingle; 
                }
            }
        }

        public void Move(Ply move)
        {

        }
    }
}
