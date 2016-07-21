﻿namespace ChessDatabase
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
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.panelPlayerInfo = new System.Windows.Forms.Panel();
            this.lblPlayerMatches = new System.Windows.Forms.Label();
            this.lstPlayerMatches = new System.Windows.Forms.ListBox();
            this.txtPlayerRating = new System.Windows.Forms.TextBox();
            this.lblPlayerRating = new System.Windows.Forms.Label();
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
            this.panelPlayerInfo.SuspendLayout();
            this.grpCreatePlayer.SuspendLayout();
            this.grpPlayerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(12, 12);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(190, 329);
            this.lstPlayers.TabIndex = 0;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(3, 16);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.ReadOnly = true;
            this.txtPlayerName.Size = new System.Drawing.Size(173, 20);
            this.txtPlayerName.TabIndex = 1;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(3, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerName.TabIndex = 3;
            this.lblPlayerName.Text = "Name";
            // 
            // panelPlayerInfo
            // 
            this.panelPlayerInfo.Controls.Add(this.lblPlayerMatches);
            this.panelPlayerInfo.Controls.Add(this.lstPlayerMatches);
            this.panelPlayerInfo.Controls.Add(this.txtPlayerRating);
            this.panelPlayerInfo.Controls.Add(this.lblPlayerRating);
            this.panelPlayerInfo.Controls.Add(this.txtPlayerName);
            this.panelPlayerInfo.Controls.Add(this.lblPlayerName);
            this.panelPlayerInfo.Location = new System.Drawing.Point(6, 19);
            this.panelPlayerInfo.Name = "panelPlayerInfo";
            this.panelPlayerInfo.Size = new System.Drawing.Size(189, 310);
            this.panelPlayerInfo.TabIndex = 4;
            // 
            // lblPlayerMatches
            // 
            this.lblPlayerMatches.AutoSize = true;
            this.lblPlayerMatches.Location = new System.Drawing.Point(3, 99);
            this.lblPlayerMatches.Name = "lblPlayerMatches";
            this.lblPlayerMatches.Size = new System.Drawing.Size(75, 13);
            this.lblPlayerMatches.TabIndex = 7;
            this.lblPlayerMatches.Text = "Games Played";
            // 
            // lstPlayerMatches
            // 
            this.lstPlayerMatches.FormattingEnabled = true;
            this.lstPlayerMatches.Location = new System.Drawing.Point(3, 115);
            this.lstPlayerMatches.Name = "lstPlayerMatches";
            this.lstPlayerMatches.Size = new System.Drawing.Size(183, 186);
            this.lstPlayerMatches.TabIndex = 6;
            // 
            // txtPlayerRating
            // 
            this.txtPlayerRating.Location = new System.Drawing.Point(3, 65);
            this.txtPlayerRating.Name = "txtPlayerRating";
            this.txtPlayerRating.ReadOnly = true;
            this.txtPlayerRating.Size = new System.Drawing.Size(85, 20);
            this.txtPlayerRating.TabIndex = 5;
            // 
            // lblPlayerRating
            // 
            this.lblPlayerRating.AutoSize = true;
            this.lblPlayerRating.Location = new System.Drawing.Point(3, 49);
            this.lblPlayerRating.Name = "lblPlayerRating";
            this.lblPlayerRating.Size = new System.Drawing.Size(62, 13);
            this.lblPlayerRating.TabIndex = 4;
            this.lblPlayerRating.Text = "ELO Rating";
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
            this.btnOpenGame.Location = new System.Drawing.Point(201, 240);
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
            this.btnDeleteGame.Location = new System.Drawing.Point(201, 283);
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
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.BackColor = System.Drawing.Color.Red;
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
            this.grpCreatePlayer.Controls.Add(this.btnCreatePlayer);
            this.grpCreatePlayer.Controls.Add(this.txtNewPlayerRating);
            this.grpCreatePlayer.Controls.Add(this.label3);
            this.grpCreatePlayer.Controls.Add(this.label2);
            this.grpCreatePlayer.Controls.Add(this.txtNewPlayerName);
            this.grpCreatePlayer.Location = new System.Drawing.Point(542, 193);
            this.grpCreatePlayer.Name = "grpCreatePlayer";
            this.grpCreatePlayer.Size = new System.Drawing.Size(200, 153);
            this.grpCreatePlayer.TabIndex = 10;
            this.grpCreatePlayer.TabStop = false;
            this.grpCreatePlayer.Text = "Create New Player";
            // 
            // grpPlayerInformation
            // 
            this.grpPlayerInformation.Controls.Add(this.panelPlayerInfo);
            this.grpPlayerInformation.Controls.Add(this.btnEditPlayer);
            this.grpPlayerInformation.Controls.Add(this.btnDeleteGame);
            this.grpPlayerInformation.Controls.Add(this.btnDeletePlayer);
            this.grpPlayerInformation.Controls.Add(this.btnOpenGame);
            this.grpPlayerInformation.Location = new System.Drawing.Point(209, 12);
            this.grpPlayerInformation.Name = "grpPlayerInformation";
            this.grpPlayerInformation.Size = new System.Drawing.Size(327, 334);
            this.grpPlayerInformation.TabIndex = 11;
            this.grpPlayerInformation.TabStop = false;
            this.grpPlayerInformation.Text = "Player Information";
            // 
            // ManagePlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 425);
            this.Controls.Add(this.grpPlayerInformation);
            this.Controls.Add(this.grpCreatePlayer);
            this.Controls.Add(this.lstPlayers);
            this.Name = "ManagePlayers";
            this.Text = "ManagePlayers";
            this.panelPlayerInfo.ResumeLayout(false);
            this.panelPlayerInfo.PerformLayout();
            this.grpCreatePlayer.ResumeLayout(false);
            this.grpCreatePlayer.PerformLayout();
            this.grpPlayerInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Panel panelPlayerInfo;
        private System.Windows.Forms.Label lblPlayerMatches;
        private System.Windows.Forms.ListBox lstPlayerMatches;
        private System.Windows.Forms.TextBox txtPlayerRating;
        private System.Windows.Forms.Label lblPlayerRating;
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
    }
}