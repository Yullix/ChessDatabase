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
using ChessDatabase.Repositories;
using ChessDatabase.Models;

namespace ChessDatabase
{
    public partial class ManagePlayers : Form
    {
        private PlayerService _playerService;
        private MatchService _matchService;
        private RepositoryFactory _repoFactory;

        public PlayerService playerService
        {
            get
            {
                return _playerService ?? new PlayerService(repoFactory);
            }
            private set
            {
                value = _playerService;
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
                value = _matchService;
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
                value = _repoFactory;
            }
        }

        public ManagePlayers()
        {
            InitializeComponent();
            UpdateLstPlayers();
        }

        public void UpdateLstPlayers()
        {
            lstPlayers.Items.Clear();

            foreach(var p in playerService.All())
            {
                lstPlayers.Items.Add(p);
            }
        }

        public void UpdateLstPlayerMatches()
        {
            Player player = (Player)lstPlayers.SelectedItem;
            lstPlayerMatches.Items.Clear();

            foreach(var m in player.matches)
            {
                lstPlayerMatches.Items.Add(m);
            }
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Player player = (Player)lstPlayers.SelectedItem;

                txtPlayerName.Text = player.name;
                txtPlayerRating.Text = player.rating.ToString();
                UpdateLstPlayerMatches();
            }
            catch
            {
            }
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                string _newPlayerName = txtNewPlayerName.Text;
                int _newPlayerRating = Int32.Parse(txtNewPlayerRating.Text);

                playerService.Add(_newPlayerName, _newPlayerRating);
            }
            catch(Exception)
            {
                MessageBox.Show("You must enter a name and a rating number.");
            }
        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            Player player = (Player)lstPlayers.SelectedItem;
        }

        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            Match match = (Match)lstPlayerMatches.SelectedItem;
        }

        private void btnDeleteGame_Click(object sender, EventArgs e)
        {
            Match match = (Match)lstPlayerMatches.SelectedItem;
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            Player deletePlayer = (Player)lstPlayers.SelectedItem;

            playerService.Remove(deletePlayer.Id);
        }
    }
}
