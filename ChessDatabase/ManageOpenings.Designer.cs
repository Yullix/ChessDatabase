namespace ChessDatabase
{
    partial class ManageOpenings
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
            this.lstOpenings = new System.Windows.Forms.ListBox();
            this.pnlSelectedOpening = new System.Windows.Forms.Panel();
            this.txtOpeningName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstOpeningGames = new System.Windows.Forms.ListBox();
            this.btnExploreOpening = new System.Windows.Forms.Button();
            this.btnOpenGame = new System.Windows.Forms.Button();
            this.btnDeleteGame = new System.Windows.Forms.Button();
            this.pnlSelectedOpening.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstOpenings
            // 
            this.lstOpenings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstOpenings.FormattingEnabled = true;
            this.lstOpenings.Location = new System.Drawing.Point(47, 71);
            this.lstOpenings.Name = "lstOpenings";
            this.lstOpenings.Size = new System.Drawing.Size(137, 329);
            this.lstOpenings.TabIndex = 126;
            this.lstOpenings.SelectedIndexChanged += new System.EventHandler(this.lstOpenings_SelectedIndexChanged);
            // 
            // pnlSelectedOpening
            // 
            this.pnlSelectedOpening.BackColor = System.Drawing.Color.Transparent;
            this.pnlSelectedOpening.Controls.Add(this.btnDeleteGame);
            this.pnlSelectedOpening.Controls.Add(this.btnOpenGame);
            this.pnlSelectedOpening.Controls.Add(this.btnExploreOpening);
            this.pnlSelectedOpening.Controls.Add(this.lstOpeningGames);
            this.pnlSelectedOpening.Controls.Add(this.label2);
            this.pnlSelectedOpening.Controls.Add(this.label1);
            this.pnlSelectedOpening.Controls.Add(this.txtOpeningName);
            this.pnlSelectedOpening.Location = new System.Drawing.Point(190, 71);
            this.pnlSelectedOpening.Name = "pnlSelectedOpening";
            this.pnlSelectedOpening.Size = new System.Drawing.Size(297, 329);
            this.pnlSelectedOpening.TabIndex = 127;
            // 
            // txtOpeningName
            // 
            this.txtOpeningName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOpeningName.Location = new System.Drawing.Point(13, 29);
            this.txtOpeningName.Name = "txtOpeningName";
            this.txtOpeningName.ReadOnly = true;
            this.txtOpeningName.Size = new System.Drawing.Size(159, 20);
            this.txtOpeningName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opening Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(10, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Games With This Opening";
            // 
            // lstOpeningGames
            // 
            this.lstOpeningGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstOpeningGames.FormattingEnabled = true;
            this.lstOpeningGames.Location = new System.Drawing.Point(13, 125);
            this.lstOpeningGames.Name = "lstOpeningGames";
            this.lstOpeningGames.Size = new System.Drawing.Size(159, 199);
            this.lstOpeningGames.TabIndex = 3;
            // 
            // btnExploreOpening
            // 
            this.btnExploreOpening.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExploreOpening.Location = new System.Drawing.Point(178, 29);
            this.btnExploreOpening.Name = "btnExploreOpening";
            this.btnExploreOpening.Size = new System.Drawing.Size(116, 48);
            this.btnExploreOpening.TabIndex = 4;
            this.btnExploreOpening.Text = "Explore Opening";
            this.btnExploreOpening.UseVisualStyleBackColor = false;
            this.btnExploreOpening.Click += new System.EventHandler(this.btnExploreOpening_Click);
            // 
            // btnOpenGame
            // 
            this.btnOpenGame.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnOpenGame.Location = new System.Drawing.Point(178, 222);
            this.btnOpenGame.Name = "btnOpenGame";
            this.btnOpenGame.Size = new System.Drawing.Size(116, 48);
            this.btnOpenGame.TabIndex = 5;
            this.btnOpenGame.Text = "Open Game";
            this.btnOpenGame.UseVisualStyleBackColor = false;
            this.btnOpenGame.Click += new System.EventHandler(this.btnOpenGame_Click);
            // 
            // btnDeleteGame
            // 
            this.btnDeleteGame.BackColor = System.Drawing.Color.Red;
            this.btnDeleteGame.Location = new System.Drawing.Point(178, 276);
            this.btnDeleteGame.Name = "btnDeleteGame";
            this.btnDeleteGame.Size = new System.Drawing.Size(116, 48);
            this.btnDeleteGame.TabIndex = 6;
            this.btnDeleteGame.Text = "Delete Game";
            this.btnDeleteGame.UseVisualStyleBackColor = false;
            // 
            // ManageOpenings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.pnlSelectedOpening);
            this.Controls.Add(this.lstOpenings);
            this.Name = "ManageOpenings";
            this.Text = "ManageOpenings";
            this.Controls.SetChildIndex(this.lstOpenings, 0);
            this.Controls.SetChildIndex(this.pnlSelectedOpening, 0);
            this.pnlSelectedOpening.ResumeLayout(false);
            this.pnlSelectedOpening.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstOpenings;
        private System.Windows.Forms.Panel pnlSelectedOpening;
        private System.Windows.Forms.TextBox txtOpeningName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstOpeningGames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteGame;
        private System.Windows.Forms.Button btnOpenGame;
        private System.Windows.Forms.Button btnExploreOpening;
    }
}