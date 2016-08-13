using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessDatabase.Services;
using ChessDatabase.Models;
using ChessDatabase.Repositories;

namespace ChessDatabase
{
    public partial class ManageOpenings : MainForm
    {
        private RepositoryFactory _repoFactory;
        private OpeningService _openingService;

        public ManageOpenings()
        {
            this._repoFactory = new RepositoryFactory();
            this._openingService = new OpeningService(_repoFactory);

            InitializeComponent();

            UpdateLstOpenings();
        }

        private void UpdateLstOpenings()
        {
            lstOpenings.Items.Clear();

            foreach(var o in _openingService.All())
            {
                lstOpenings.Items.Add(o);
            }
        }

        private void lstOpenings_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedOpening = (Opening)lstOpenings.SelectedItem;

                txtOpeningName.Text = selectedOpening.name;
            }
            catch { }
        }

        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedGame = (Match)lstOpeningGames.SelectedItem;

                Form viewMatchForm = new ViewMatch(selectedGame);
                viewMatchForm.Show();
            }
            catch { }
        }

        private void btnExploreOpening_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedOpening = (Opening)lstOpeningGames.SelectedItem;

                Form exploreOpeningForm = new ExploreOpening(selectedOpening);
                exploreOpeningForm.Show();
            }
            catch { }
        }
    }
}
