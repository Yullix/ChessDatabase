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

namespace ChessDatabase
{
    public partial class ExploreOpening : Form
    {
        private Opening _opening;
        private string[,] _position;

        public ExploreOpening(Opening exploreOpening)
        {
            this._opening = exploreOpening;
            this._position = ChessLogic.GetStartPosition();

            InitializeComponent();
        }
    }
}
