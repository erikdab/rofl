namespace ROFL
{
    partial class Scenario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scenario));
            this.labelStory = new System.Windows.Forms.Label();
            this.labelGoal = new System.Windows.Forms.Label();
            this.labelStoryTitle = new System.Windows.Forms.Label();
            this.labelGoalTitle = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.pictureBoxGoal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStory
            // 
            this.labelStory.BackColor = System.Drawing.Color.Transparent;
            this.labelStory.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStory.Location = new System.Drawing.Point(12, 50);
            this.labelStory.Name = "labelStory";
            this.labelStory.Size = new System.Drawing.Size(679, 248);
            this.labelStory.TabIndex = 1;
            this.labelStory.Text = resources.GetString("labelStory.Text");
            // 
            // labelGoal
            // 
            this.labelGoal.BackColor = System.Drawing.Color.Transparent;
            this.labelGoal.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoal.Location = new System.Drawing.Point(20, 340);
            this.labelGoal.Name = "labelGoal";
            this.labelGoal.Size = new System.Drawing.Size(418, 114);
            this.labelGoal.TabIndex = 2;
            this.labelGoal.Text = "There is also hear of a great monster, a Dragon, deep in the dungeon, residing be" +
    "low the 5th floor of the dungeon! If you defeat him, you will surely gain great " +
    "fame and renown!";
            // 
            // labelStoryTitle
            // 
            this.labelStoryTitle.AutoSize = true;
            this.labelStoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelStoryTitle.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoryTitle.Location = new System.Drawing.Point(17, 13);
            this.labelStoryTitle.Name = "labelStoryTitle";
            this.labelStoryTitle.Size = new System.Drawing.Size(256, 44);
            this.labelStoryTitle.TabIndex = 3;
            this.labelStoryTitle.Text = "The Story so far:";
            // 
            // labelGoalTitle
            // 
            this.labelGoalTitle.AutoSize = true;
            this.labelGoalTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelGoalTitle.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoalTitle.Location = new System.Drawing.Point(17, 300);
            this.labelGoalTitle.Name = "labelGoalTitle";
            this.labelGoalTitle.Size = new System.Drawing.Size(173, 44);
            this.labelGoalTitle.TabIndex = 4;
            this.labelGoalTitle.Text = "Your Task:";
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewGame.FlatAppearance.BorderSize = 0;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGame.Location = new System.Drawing.Point(594, 403);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(84, 65);
            this.buttonNewGame.TabIndex = 15;
            this.buttonNewGame.Text = "OK";
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBoxGoal
            // 
            this.pictureBoxGoal.BackgroundImage = global::ROFL.Properties.Resources.Icon256;
            this.pictureBoxGoal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGoal.Location = new System.Drawing.Point(444, 340);
            this.pictureBoxGoal.Name = "pictureBoxGoal";
            this.pictureBoxGoal.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxGoal.TabIndex = 16;
            this.pictureBoxGoal.TabStop = false;
            // 
            // Scenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROFL.Properties.Resources.background2_Scenario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(703, 494);
            this.Controls.Add(this.pictureBoxGoal);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.labelGoal);
            this.Controls.Add(this.labelGoalTitle);
            this.Controls.Add(this.labelStoryTitle);
            this.Controls.Add(this.labelStory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Scenario";
            this.Text = "Scenario Info";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGoal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStory;
        private System.Windows.Forms.Label labelGoal;
        private System.Windows.Forms.Label labelStoryTitle;
        private System.Windows.Forms.Label labelGoalTitle;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.PictureBox pictureBoxGoal;
    }
}