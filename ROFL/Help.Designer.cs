namespace ROFL
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.labelStory = new System.Windows.Forms.Label();
            this.pictureBoxScenario = new System.Windows.Forms.PictureBox();
            this.labelStoryTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelHelp = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScenario)).BeginInit();
            this.panelHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStory
            // 
            this.labelStory.BackColor = System.Drawing.Color.Transparent;
            this.labelStory.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStory.Location = new System.Drawing.Point(0, 0);
            this.labelStory.Name = "labelStory";
            this.labelStory.Size = new System.Drawing.Size(659, 400);
            this.labelStory.TabIndex = 1;
            this.labelStory.Text = resources.GetString("labelStory.Text");
            // 
            // pictureBoxScenario
            // 
            this.pictureBoxScenario.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxScenario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScenario.Image = global::ROFL.Properties.Resources.flag;
            this.pictureBoxScenario.Location = new System.Drawing.Point(78, 33);
            this.pictureBoxScenario.Name = "pictureBoxScenario";
            this.pictureBoxScenario.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxScenario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScenario.TabIndex = 0;
            this.pictureBoxScenario.TabStop = false;
            // 
            // labelStoryTitle
            // 
            this.labelStoryTitle.AutoSize = true;
            this.labelStoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelStoryTitle.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoryTitle.Location = new System.Drawing.Point(17, 13);
            this.labelStoryTitle.Name = "labelStoryTitle";
            this.labelStoryTitle.Size = new System.Drawing.Size(83, 44);
            this.labelStoryTitle.TabIndex = 3;
            this.labelStoryTitle.Text = "Help";
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
            this.buttonClose.TabIndex = 14;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelHelp
            // 
            this.panelHelp.AutoScroll = true;
            this.panelHelp.BackColor = System.Drawing.Color.Transparent;
            this.panelHelp.Controls.Add(this.pictureBoxScenario);
            this.panelHelp.Controls.Add(this.labelStory);
            this.panelHelp.Location = new System.Drawing.Point(12, 81);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Size = new System.Drawing.Size(679, 401);
            this.panelHelp.TabIndex = 15;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROFL.Properties.Resources.background2_Scenario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(703, 494);
            this.Controls.Add(this.panelHelp);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelStoryTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Help";
            this.Text = "Help";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScenario)).EndInit();
            this.panelHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxScenario;
        private System.Windows.Forms.Label labelStory;
        private System.Windows.Forms.Label labelStoryTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelHelp;
    }
}