namespace ChessDatabase
{
    partial class ManagePlayers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.btnCreatePlayer = new System.Windows.Forms.Button();
            this.btnOpenGame = new System.Windows.Forms.Button();
            this.btnEditPlayer = new System.Windows.Forms.Button();
            this.btnDeleteGame = new System.Windows.Forms.Button();
            this.txtNewPlayerRating = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPlayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeletePlayer = new System.Windows.Forms.Button();
            this.grpCreatePlayer = new System.Windows.Forms.GroupBox();
            this.grpPlayerInformation = new System.Windows.Forms.GroupBox();
            this.lstPlayerMatches = new System.Windows.Forms.ListBox();
            this.lblPlayerMatches = new System.Windows.Forms.Label();
            this.txtPlayerRating = new System.Windows.Forms.TextBox();
            this.lblPlayerRating = new System.Windows.Forms.Label();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.grpCreatePlayer.SuspendLayout();
            this.grpPlayerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPlayers
            // 
            this.lstPlayers.BackColor = System.Drawing.Color.White;
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(47, 84);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(190, 472);
            this.lstPlayers.TabIndex = 0;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // btnCreatePlayer
            // 
            this.btnCreatePlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCreatePlayer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreatePlayer.Location = new System.Drawing.Point(15, 102);
            this.btnCreatePlayer.Name = "btnCreatePlayer";
            this.btnCreatePlayer.Size = new System.Drawing.Size(173, 37);
            this.btnCreatePlayer.TabIndex = 5;
            this.btnCreatePlayer.Text = "Create New Player";
            this.btnCreatePlayer.UseVisualStyleBackColor = false;
            this.btnCreatePlayer.Click += new System.EventHandler(this.btnCreatePlayer_Click);
            // 
            // btnOpenGame
            // 
            this.btnOpenGame.BackColor = System.Drawing.Color.White;
            this.btnOpenGame.ForeColor = System.Drawing.Color.Black;
            this.btnOpenGame.Location = new System.Drawing.Point(201, 383);
            this.btnOpenGame.Name = "btnOpenGame";
            this.btnOpenGame.Size = new System.Drawing.Size(118, 37);
            this.btnOpenGame.TabIndex = 6;
            this.btnOpenGame.Text = "Open Game";
            this.btnOpenGame.UseVisualStyleBackColor = false;
            this.btnOpenGame.Click += new System.EventHandler(this.btnOpenGame_Click);
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.BackColor = System.Drawing.Color.White;
            this.btnEditPlayer.ForeColor = System.Drawing.Color.Black;
            this.btnEditPlayer.Location = new System.Drawing.Point(201, 26);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(118, 37);
            this.btnEditPlayer.TabIndex = 7;
            this.btnEditPlayer.Text = "Edit Player";
            this.btnEditPlayer.UseVisualStyleBackColor = false;
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
            // 
            // btnDeleteGame
            // 
            this.btnDeleteGame.BackColor = System.Drawing.Color.Red;
            this.btnDeleteGame.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteGame.Location = new System.Drawing.Point(201, 426);
            this.btnDeleteGame.Name = "btnDeleteGame";
            this.btnDeleteGame.Size = new System.Drawing.Size(118, 37);
            this.btnDeleteGame.TabIndex = 8;
            this.btnDeleteGame.Text = "Delete Game";
            this.btnDeleteGame.UseVisualStyleBackColor = false;
            this.btnDeleteGame.Click += new System.EventHandler(this.btnDeleteGame_Click);
            // 
            // txtNewPlayerRating
            // 
            this.txtNewPlayerRating.Location = new System.Drawing.Point(15, 76);
            this.txtNewPlayerRating.Name = "txtNewPlayerRating";
            this.txtNewPlayerRating.Size = new System.Drawing.Size(85, 20);
            this.txtNewPlayerRating.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ELO Rating";
            // 
            // txtNewPlayerName
            // 
            this.txtNewPlayerName.Location = new System.Drawing.Point(15, 33);
            this.txtNewPlayerName.Name = "txtNewPlayerName";
            this.txtNewPlayerName.Size = new System.Drawing.Size(173, 20);
            this.txtNewPlayerName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.BackColor = System.Drawing.Color.Red;
            this.btnDeletePlayer.ForeColor = System.Drawing.Color.Black;
            this.btnDeletePlayer.Location = new System.Drawing.Point(201, 75);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(118, 37);
            this.btnDeletePlayer.TabIndex = 9;
            this.btnDeletePlayer.Text = "Delete Player";
            this.btnDeletePlayer.UseVisualStyleBackColor = false;
            this.btnDeletePlayer.Click += new System.EventHandler(this.btnDeletePlayer_Click);
            // 
            // grpCreatePlayer
            // 
            this.grpCreatePlayer.BackColor = System.Drawing.Color.Transparent;
            this.grpCreatePlayer.Controls.Add(this.btnCreatePlayer);
            this.grpCreatePlayer.Controls.Add(this.txtNewPlayerRating);
            this.grpCreatePlayer.Controls.Add(this.label3);
            this.grpCreatePlayer.Controls.Add(this.label2);
            this.grpCreatePlayer.Controls.Add(this.txtNewPlayerName);
            this.grpCreatePlayer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.grpCreatePlayer.Location = new System.Drawing.Point(588, 84);
            this.grpCreatePlayer.Name = "grpCreatePlayer";
            this.grpCreatePlayer.Size = new System.Drawing.Size(200, 153);
            this.grpCreatePlayer.TabIndex = 10;
            this.grpCreatePlayer.TabStop = false;
            this.grpCreatePlayer.Text = "New Player";
            // 
            // grpPlayerInformation
            // 
            this.grpPlayerInformation.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayerInformation.Controls.Add(this.lstPlayerMatches);
            this.grpPlayerInformation.Controls.Add(this.lblPlayerMatches);
            this.grpPlayerInformation.Controls.Add(this.btnEditPlayer);
            this.grpPlayerInformation.Controls.Add(this.txtPlayerRating);
            this.grpPlayerInformation.Controls.Add(this.btnDeleteGame);
            this.grpPlayerInformation.Controls.Add(this.lblPlayerRating);
            this.grpPlayerInformation.Controls.Add(this.btnDeletePlayer);
            this.grpPlayerInformation.Controls.Add(this.txtPlayerName);
            this.grpPlayerInformation.Controls.Add(this.btnOpenGame);
            this.grpPlayerInformation.Controls.Add(this.lblPlayerName);
            this.grpPlayerInformation.ForeColor = System.Drawing.Color.Lime;
            this.grpPlayerInformation.Location = new System.Drawing.Point(244, 84);
            this.grpPlayerInformation.Name = "grpPlayerInformation";
            this.grpPlayerInformation.Size = new System.Drawing.Size(327, 472);
            this.grpPlayerInformation.TabIndex = 11;
            this.grpPlayerInformation.TabStop = false;
            this.grpPlayerInformation.Text = "Player Information";
            // 
            // lstPlayerMatches
            // 
            this.lstPlayerMatches.FormattingEnabled = true;
            this.lstPlayerMatches.Location = new System.Drawing.Point(6, 134);
            this.lstPlayerMatches.Name = "lstPlayerMatches";
            this.lstPlayerMatches.Size = new System.Drawing.Size(183, 329);
            this.lstPlayerMatches.TabIndex = 6;
            // 
            // lblPlayerMatches
            // 
            this.lblPlayerMatches.AutoSize = true;
            this.lblPlayerMatches.ForeColor = System.Drawing.Color.Lime;
            this.lblPlayerMatches.Location = new System.Drawing.Point(6, 109);
            this.lblPlayerMatches.Name = "lblPlayerMatches";
            this.lblPlayerMatches.Size = new System.Drawing.Size(75, 13);
            this.lblPlayerMatches.TabIndex = 7;
            this.lblPlayerMatches.Text = "Games Played";
            // 
            // txtPlayerRating
            // 
            this.txtPlayerRating.Location = new System.Drawing.Point(6, 75);
            this.txtPlayerRating.Name = "txtPlayerRating";
            this.txtPlayerRating.ReadOnly = true;
            this.txtPlayerRating.Size = new System.Drawing.Size(85, 20);
            this.txtPlayerRating.TabIndex = 5;
            // 
            // lblPlayerRating
            // 
            this.lblPlayerRating.AutoSize = true;
            this.lblPlayerRating.ForeColor = System.Drawing.Color.Lime;
            this.lblPlayerRating.Location = new System.Drawing.Point(6, 58);
            this.lblPlayerRating.Name = "lblPlayerRating";
            this.lblPlayerRating.Size = new System.Drawing.Size(62, 13);
            this.lblPlayerRating.TabIndex = 4;
            this.lblPlayerRating.Text = "ELO Rating";
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(6, 35);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.ReadOnly = true;
            this.txtPlayerName.Size = new System.Drawing.Size(173, 20);
            this.txtPlayerName.TabIndex = 1;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.ForeColor = System.Drawing.Color.Lime;
            this.lblPlayerName.Location = new System.Drawing.Point(9, 16);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerName.TabIndex = 3;
            this.lblPlayerName.Text = "Name";
            // 
            // ManagePlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.grpPlayerInformation);
            this.Controls.Add(this.grpCreatePlayer);
            this.Controls.Add(this.lstPlayers);
            this.Name = "ManagePlayers";
            this.Text = "ManagePlayers";
            this.Controls.SetChildIndex(this.lstPlayers, 0);
            this.Controls.SetChildIndex(this.grpCreatePlayer, 0);
            this.Controls.SetChildIndex(this.grpPlayerInformation, 0);
            this.grpCreatePlayer.ResumeLayout(false);
            this.grpCreatePlayer.PerformLayout();
            this.grpPlayerInformation.ResumeLayout(false);
            this.grpPlayerInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Button btnCreatePlayer;
        private System.Windows.Forms.Button btnOpenGame;
        private System.Windows.Forms.Button btnEditPlayer;
        private System.Windows.Forms.Button btnDeleteGame;
        private System.Windows.Forms.TextBox txtNewPlayerRating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPlayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeletePlayer;
        private System.Windows.Forms.GroupBox grpCreatePlayer;
        private System.Windows.Forms.GroupBox grpPlayerInformation;
        private System.Windows.Forms.ListBox lstPlayerMatches;
        private System.Windows.Forms.Label lblPlayerMatches;
        private System.Windows.Forms.TextBox txtPlayerRating;
        private System.Windows.Forms.Label lblPlayerRating;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblPlayerName;
    }
}