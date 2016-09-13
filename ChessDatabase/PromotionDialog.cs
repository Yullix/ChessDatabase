using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDatabase
{
    public partial class PromotionDialog : Form
    {
        public char selectedPromotionPiece { get; set; }
        private PictureBox selectedBox;
        private Assembly currentAssembly;
        private Stream whiteKnightStream;
        private Stream whiteBishopStream;
        private Stream whiteRookStream;
        private Stream whiteQueenStream;
        private Stream blackKnightStream;
        private Stream blackBishopStream;
        private Stream blackRookStream;
        private Stream blackQueenStream;

        public PromotionDialog(string _color)
        {
            currentAssembly = Assembly.GetExecutingAssembly();

            if (_color == "white")
            {
                whiteKnightStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteKnight.png");
                whiteBishopStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteBishop.png");
                whiteRookStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteRook.png");
                whiteQueenStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.whiteQueen.png");

                //pBoxKnight.Image = new Bitmap(whiteKnightStream);
                //pBoxBishop.Image = new Bitmap(whiteBishopStream);
                //pBoxRook.Image = new Bitmap(whiteRookStream);
                //pBoxQueen.Image = new Bitmap(whiteQueenStream);
            }

            else
            {
                blackKnightStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackKnight.png");
                blackBishopStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackBishop.png");
                blackRookStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackRook.png");
                blackQueenStream = currentAssembly.GetManifestResourceStream("ChessDatabase.Resources.blackQueen.png");

                //pBoxKnight.Image = new Bitmap(blackKnightStream);
                //pBoxBishop.Image = new Bitmap(blackBishopStream);
                //pBoxRook.Image = new Bitmap(blackRookStream);
                //pBoxQueen.Image = new Bitmap(blackQueenStream);
            }

            InitializeComponent();
        }

        private void pBoxKnight_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'N';

            if(selectedBox != null)
                selectedBox.BackColor = Color.Transparent;

            pBoxKnight.BackColor = Color.Teal;
            selectedBox = pBoxKnight;
        }

        private void pBoxBishop_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'B';

            if (selectedBox != null)
                selectedBox.BackColor = Color.Transparent;

            pBoxBishop.BackColor = Color.Teal;
            selectedBox = pBoxBishop;
        }

        private void pBoxRook_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'R';

            if (selectedBox != null)
                selectedBox.BackColor = Color.Transparent;

            pBoxRook.BackColor = Color.Teal;
            selectedBox = pBoxRook;
        }

        private void pBoxQueen_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'Q';

            if (selectedBox != null)
                selectedBox.BackColor = Color.Transparent;

            pBoxQueen.BackColor = Color.Teal;
            selectedBox = pBoxQueen;
        }

        private void btnSelectPiece_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
