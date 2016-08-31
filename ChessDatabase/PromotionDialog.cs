using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDatabase
{
    public partial class PromotionDialog : Form
    {
        public char selectedPromotionPiece { get; set; }

        public PromotionDialog()
        {
            InitializeComponent();
        }

        private void pBoxKnight_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'N';
        }

        private void pBoxBishop_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'B';
        }

        private void pBoxRook_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'R';
        }

        private void pBoxQueen_Click(object sender, EventArgs e)
        {
            this.selectedPromotionPiece = 'Q';
        }

        private void btnSelectPiece_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
