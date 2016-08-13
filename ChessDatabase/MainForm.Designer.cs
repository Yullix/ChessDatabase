namespace ChessDatabase
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.homeNavBar = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tournamentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeNavBar
            // 
            this.homeNavBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.playersToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.gamesToolStripMenuItem,
            this.openingsToolStripMenuItem,
            this.tournamentsToolStripMenuItem});
            this.homeNavBar.Location = new System.Drawing.Point(0, 0);
            this.homeNavBar.Name = "homeNavBar";
            this.homeNavBar.Size = new System.Drawing.Size(984, 24);
            this.homeNavBar.TabIndex = 125;
            this.homeNavBar.Text = "NavBar";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.homeToolStripMenuItem.Text = "New Game";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playersToolStripMenuItem.Text = "Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.gamesToolStripMenuItem.Text = "Games";
            // 
            // openingsToolStripMenuItem
            // 
            this.openingsToolStripMenuItem.Name = "openingsToolStripMenuItem";
            this.openingsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.openingsToolStripMenuItem.Text = "Openings";
            this.openingsToolStripMenuItem.Click += new System.EventHandler(this.openingsToolStripMenuItem_Click);
            // 
            // tournamentsToolStripMenuItem
            // 
            this.tournamentsToolStripMenuItem.Name = "tournamentsToolStripMenuItem";
            this.tournamentsToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.tournamentsToolStripMenuItem.Text = "Tournaments";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.homeNavBar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.homeNavBar.ResumeLayout(false);
            this.homeNavBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip homeNavBar;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tournamentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
    }
}