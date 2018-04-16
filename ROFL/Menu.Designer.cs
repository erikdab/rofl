namespace ROFL
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.labelStory = new System.Windows.Forms.Label();
            this.pictureBoxGoal = new System.Windows.Forms.PictureBox();
            this.labelNewGame = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStory
            // 
            this.labelStory.BackColor = System.Drawing.Color.Transparent;
            this.labelStory.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStory.Location = new System.Drawing.Point(0, 136);
            this.labelStory.Name = "labelStory";
            this.labelStory.Size = new System.Drawing.Size(703, 102);
            this.labelStory.TabIndex = 1;
            this.labelStory.Text = "Welcome to ROFL\r\nReal or Forged Legends!";
            this.labelStory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxGoal
            // 
            this.pictureBoxGoal.BackgroundImage = global::ROFL.Properties.Resources.Icon256;
            this.pictureBoxGoal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGoal.Location = new System.Drawing.Point(26, 29);
            this.pictureBoxGoal.Name = "pictureBoxGoal";
            this.pictureBoxGoal.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxGoal.TabIndex = 0;
            this.pictureBoxGoal.TabStop = false;
            // 
            // labelNewGame
            // 
            this.labelNewGame.BackColor = System.Drawing.Color.Transparent;
            this.labelNewGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNewGame.Font = new System.Drawing.Font("Segoe Script", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewGame.Location = new System.Drawing.Point(0, 0);
            this.labelNewGame.Name = "labelNewGame";
            this.labelNewGame.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelNewGame.Size = new System.Drawing.Size(703, 104);
            this.labelNewGame.TabIndex = 3;
            this.labelNewGame.Text = "Main Menu";
            this.labelNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.FlatAppearance.BorderSize = 0;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGame.Location = new System.Drawing.Point(248, 275);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(196, 64);
            this.buttonNewGame.TabIndex = 10;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(248, 345);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(196, 64);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::ROFL.Properties.Resources.cross;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(627, 29);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(50, 50);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROFL.Properties.Resources.background2_Scenario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 494);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.pictureBoxGoal);
            this.Controls.Add(this.labelNewGame);
            this.Controls.Add(this.labelStory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGoal;
        private System.Windows.Forms.Label labelStory;
        private System.Windows.Forms.Label labelNewGame;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClose;
    }
}