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
    public partial class ManagePlayers : MainForm
    {
        private PlayerService _playerService;
        private MatchService _matchService;
        private RepositoryFactory _repoFactory;

        public ManagePlayers()
        {
            InitializeComponent();

            _repoFactory = new RepositoryFactory();
            _matchService = new MatchService(_repoFactory);
            _playerService = new PlayerService(_repoFactory);

            _matchService.Updated += UpdateLstPlayerMatches;
            _playerService.Updated += UpdateLstPlayers;

            UpdateLstPlayers(this, new EventArgs());
        }

        // Updates the items in lstPlayers.
        public void UpdateLstPlayers(object sender, EventArgs e)
        {
            lstPlayers.Items.Clear();

            foreach (var p in _playerService.All())
            {
                lstPlayers.Items.Add(p);
            }
        }

        // Updates the lstPlayerMatches listbox when a new player is selected in lstPlayers
        public void UpdateLstPlayerMatches(object sender, EventArgs e)
        {
            Player player = (Player)lstPlayers.SelectedItem;
            lstPlayerMatches.Items.Clear();

            foreach(var m in _matchService.ByPlayer(player.Id))
            {
                lstPlayerMatches.Items.Add(m);
            }
        }

        // Updates the information in player panel when selecting a player in lstPlayers
        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Player player = (Player)lstPlayers.SelectedItem;

                txtPlayerName.Text = player.name;
                txtPlayerRating.Text = player.rating.ToString();
                UpdateLstPlayerMatches(this, new EventArgs());
            }
            catch
            {
            }
        }

        // Creates a new player with the input values for name and ELO rating.
        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                string _newPlayerName = txtNewPlayerName.Text;
                int _newPlayerRating = Int32.Parse(txtNewPlayerRating.Text);

                _playerService.Add(_newPlayerName, _newPlayerRating);
            }
            catch(ArgumentException excep)
            {
                MessageBox.Show(excep.Message , "Error");
            }
            catch(Exception)
            {
                MessageBox.Show("You must enter a numeric rating value", "Error");
            }
        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            Player player = (Player)lstPlayers.SelectedItem;
        }

        // Opens selected game in a new form
        private void btnOpenGame_Click(object sender, EventArgs e)
        {
            try
            {
                Match viewMatch = (Match)lstPlayerMatches.SelectedItem;
                Form newForm = new ViewMatch(viewMatch);
                newForm.Show();
            }
            catch
            {

            }
        }

        // Opens a messagebox with yes/no option to delete a game
        private void btnDeleteGame_Click(object sender, EventArgs e)
        {
            Match match = (Match)lstPlayerMatches.SelectedItem;

            if (MessageBox.Show("Are you sure you want to delete the game '" + match.name + "'?", "Delete Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _matchService.Remove(match.Id);
            }
        }

        // Opens a messagebox with yes/no option to delete a player
        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            Player deletePlayer = (Player)lstPlayers.SelectedItem;

            if (MessageBox.Show("Are you sure you want to delete the player '" + deletePlayer.name + "' and all associated games?", "Delete Player", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _playerService.Remove(deletePlayer.Id);
            }           
        }
    }
}
