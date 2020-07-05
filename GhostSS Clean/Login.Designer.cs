namespace GhostSS_Clean
{
    partial class Login
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filsdepute = new Bunifu.Framework.UI.BunifuTextbox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BoutonLogin = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(220, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Sayness Industries @ Copyright 2020";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(215, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "____________________________________";
            // 
            // filsdepute
            // 
            this.filsdepute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(8)))), ((int)(((byte)(15)))));
            this.filsdepute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("filsdepute.BackgroundImage")));
            this.filsdepute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.filsdepute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(183)))));
            this.filsdepute.Icon = ((System.Drawing.Image)(resources.GetObject("filsdepute.Icon")));
            this.filsdepute.Location = new System.Drawing.Point(177, 212);
            this.filsdepute.Name = "filsdepute";
            this.filsdepute.Size = new System.Drawing.Size(294, 38);
            this.filsdepute.TabIndex = 37;
            this.filsdepute.text = "";
  
            this.filsdepute.KeyPress += new System.EventHandler(this.filsdepute_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(213, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // BoutonLogin
            // 
            this.BoutonLogin.ActiveBorderThickness = 1;
            this.BoutonLogin.ActiveCornerRadius = 20;
            this.BoutonLogin.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(183)))));
            this.BoutonLogin.ActiveForecolor = System.Drawing.Color.White;
            this.BoutonLogin.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(183)))));
            this.BoutonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(8)))), ((int)(((byte)(15)))));
            this.BoutonLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BoutonLogin.BackgroundImage")));
            this.BoutonLogin.ButtonText = "Login";
            this.BoutonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoutonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoutonLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(183)))));
            this.BoutonLogin.IdleBorderThickness = 1;
            this.BoutonLogin.IdleCornerRadius = 20;
            this.BoutonLogin.IdleFillColor = System.Drawing.Color.Transparent;
            this.BoutonLogin.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(183)))));
            this.BoutonLogin.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(183)))));
            this.BoutonLogin.Location = new System.Drawing.Point(208, 255);
            this.BoutonLogin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.BoutonLogin.Name = "BoutonLogin";
            this.BoutonLogin.Size = new System.Drawing.Size(236, 53);
            this.BoutonLogin.TabIndex = 38;
            this.BoutonLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BoutonLogin.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(8)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(651, 365);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filsdepute);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BoutonLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GhostSS - ScreenShare Tools v2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public Bunifu.Framework.UI.BunifuTextbox filsdepute;
        public System.Windows.Forms.PictureBox pictureBox1;
        public Bunifu.Framework.UI.BunifuThinButton2 BoutonLogin;
    }
}

