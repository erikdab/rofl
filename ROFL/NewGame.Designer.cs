namespace ROFL
{
    partial class NewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGame));
            this.labelNewGameHelp = new System.Windows.Forms.Label();
            this.pictureBoxGoal = new System.Windows.Forms.PictureBox();
            this.labelNewGame = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.labelCharacterName = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNewGameHelp
            // 
            this.labelNewGameHelp.BackColor = System.Drawing.Color.Transparent;
            this.labelNewGameHelp.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewGameHelp.Location = new System.Drawing.Point(0, 88);
            this.labelNewGameHelp.Name = "labelNewGameHelp";
            this.labelNewGameHelp.Size = new System.Drawing.Size(703, 76);
            this.labelNewGameHelp.TabIndex = 1;
            this.labelNewGameHelp.Text = "Fill in the following information\r\nand press start to begin the game!";
            this.labelNewGameHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelNewGame.Font = new System.Drawing.Font("Segoe Script", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewGame.Location = new System.Drawing.Point(0, 0);
            this.labelNewGame.Name = "labelNewGame";
            this.labelNewGame.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelNewGame.Size = new System.Drawing.Size(703, 88);
            this.labelNewGame.TabIndex = 3;
            this.labelNewGame.Text = "New Game";
            this.labelNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPlayerName.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(318, 230);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(181, 36);
            this.textBoxPlayerName.TabIndex = 6;
            this.textBoxPlayerName.Text = "Joan de Arc";
            // 
            // labelCharacterName
            // 
            this.labelCharacterName.AutoSize = true;
            this.labelCharacterName.BackColor = System.Drawing.Color.Transparent;
            this.labelCharacterName.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharacterName.Location = new System.Drawing.Point(193, 232);
            this.labelCharacterName.Name = "labelCharacterName";
            this.labelCharacterName.Size = new System.Drawing.Size(119, 28);
            this.labelCharacterName.TabIndex = 7;
            this.labelCharacterName.Text = "Player Name:";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.FlatAppearance.BorderSize = 0;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(268, 362);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(157, 64);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::ROFL.Properties.Resources.cross;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(627, 29);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(50, 50);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROFL.Properties.Resources.background2_Scenario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 494);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.pictureBoxGoal);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelCharacterName);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.labelNewGame);
            this.Controls.Add(this.labelNewGameHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGame";
            this.Text = "New Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGoal;
        private System.Windows.Forms.Label labelNewGameHelp;
        private System.Windows.Forms.Label labelNewGame;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Label labelCharacterName;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonClose;
    }
}