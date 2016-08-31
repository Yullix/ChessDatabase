namespace ChessDatabase
{
    partial class PromotionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionDialog));
            this.pBoxKnight = new System.Windows.Forms.PictureBox();
            this.pBoxRook = new System.Windows.Forms.PictureBox();
            this.pBoxBishop = new System.Windows.Forms.PictureBox();
            this.pBoxQueen = new System.Windows.Forms.PictureBox();
            this.btnSelectPiece = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxQueen)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxKnight
            // 
            this.pBoxKnight.BackColor = System.Drawing.Color.Transparent;
            this.pBoxKnight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxKnight.BackgroundImage")));
            this.pBoxKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxKnight.Location = new System.Drawing.Point(36, 43);
            this.pBoxKnight.Name = "pBoxKnight";
            this.pBoxKnight.Size = new System.Drawing.Size(60, 60);
            this.pBoxKnight.TabIndex = 0;
            this.pBoxKnight.TabStop = false;
            this.pBoxKnight.Click += new System.EventHandler(this.pBoxKnight_Click);
            // 
            // pBoxRook
            // 
            this.pBoxRook.BackColor = System.Drawing.Color.Transparent;
            this.pBoxRook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxRook.BackgroundImage")));
            this.pBoxRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxRook.Location = new System.Drawing.Point(168, 43);
            this.pBoxRook.Name = "pBoxRook";
            this.pBoxRook.Size = new System.Drawing.Size(60, 60);
            this.pBoxRook.TabIndex = 1;
            this.pBoxRook.TabStop = false;
            this.pBoxRook.Click += new System.EventHandler(this.pBoxRook_Click);
            // 
            // pBoxBishop
            // 
            this.pBoxBishop.BackColor = System.Drawing.Color.Transparent;
            this.pBoxBishop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxBishop.BackgroundImage")));
            this.pBoxBishop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxBishop.Location = new System.Drawing.Point(102, 43);
            this.pBoxBishop.Name = "pBoxBishop";
            this.pBoxBishop.Size = new System.Drawing.Size(60, 60);
            this.pBoxBishop.TabIndex = 2;
            this.pBoxBishop.TabStop = false;
            this.pBoxBishop.Click += new System.EventHandler(this.pBoxBishop_Click);
            // 
            // pBoxQueen
            // 
            this.pBoxQueen.BackColor = System.Drawing.Color.Transparent;
            this.pBoxQueen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxQueen.BackgroundImage")));
            this.pBoxQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxQueen.Location = new System.Drawing.Point(234, 43);
            this.pBoxQueen.Name = "pBoxQueen";
            this.pBoxQueen.Size = new System.Drawing.Size(60, 60);
            this.pBoxQueen.TabIndex = 3;
            this.pBoxQueen.TabStop = false;
            this.pBoxQueen.Click += new System.EventHandler(this.pBoxQueen_Click);
            // 
            // btnSelectPiece
            // 
            this.btnSelectPiece.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSelectPiece.Location = new System.Drawing.Point(102, 124);
            this.btnSelectPiece.Name = "btnSelectPiece";
            this.btnSelectPiece.Size = new System.Drawing.Size(126, 38);
            this.btnSelectPiece.TabIndex = 4;
            this.btnSelectPiece.Text = "Select Piece";
            this.btnSelectPiece.UseVisualStyleBackColor = false;
            this.btnSelectPiece.Click += new System.EventHandler(this.btnSelectPiece_Click);
            // 
            // PromotionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(334, 184);
            this.Controls.Add(this.btnSelectPiece);
            this.Controls.Add(this.pBoxQueen);
            this.Controls.Add(this.pBoxBishop);
            this.Controls.Add(this.pBoxRook);
            this.Controls.Add(this.pBoxKnight);
            this.Name = "PromotionDialog";
            this.Text = "Select Promotion Piece";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxQueen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxKnight;
        private System.Windows.Forms.PictureBox pBoxRook;
        private System.Windows.Forms.PictureBox pBoxBishop;
        private System.Windows.Forms.PictureBox pBoxQueen;
        private System.Windows.Forms.Button btnSelectPiece;
    }
}