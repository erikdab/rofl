namespace ROFL
{
    partial class Inventory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelPage = new System.Windows.Forms.Panel();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonPageLeft = new System.Windows.Forms.Button();
            this.buttonPageRight = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.panelPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPage
            // 
            this.panelPage.BackgroundImage = global::ROFL.Properties.Resources.background1_Game;
            this.panelPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPage.Controls.Add(this.labelPage);
            this.panelPage.Controls.Add(this.buttonPageLeft);
            this.panelPage.Controls.Add(this.buttonPageRight);
            this.panelPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPage.Location = new System.Drawing.Point(0, 64);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(256, 40);
            this.panelPage.TabIndex = 111;
            // 
            // labelPage
            // 
            this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPage.BackColor = System.Drawing.Color.Transparent;
            this.labelPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPage.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPage.Location = new System.Drawing.Point(36, -1);
            this.labelPage.Margin = new System.Windows.Forms.Padding(0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(180, 40);
            this.labelPage.TabIndex = 154;
            this.labelPage.Text = "Page: 1";
            this.labelPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPageLeft
            // 
            this.buttonPageLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPageLeft.BackColor = System.Drawing.Color.Transparent;
            this.buttonPageLeft.BackgroundImage = global::ROFL.Properties.Resources.left;
            this.buttonPageLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPageLeft.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonPageLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPageLeft.Location = new System.Drawing.Point(-2, -1);
            this.buttonPageLeft.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPageLeft.Name = "buttonPageLeft";
            this.buttonPageLeft.Size = new System.Drawing.Size(40, 40);
            this.buttonPageLeft.TabIndex = 155;
            this.buttonPageLeft.UseVisualStyleBackColor = false;
            this.buttonPageLeft.Click += new System.EventHandler(this.buttonPageLeft_Click);
            // 
            // buttonPageRight
            // 
            this.buttonPageRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPageRight.BackColor = System.Drawing.Color.Transparent;
            this.buttonPageRight.BackgroundImage = global::ROFL.Properties.Resources.right;
            this.buttonPageRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPageRight.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonPageRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPageRight.Location = new System.Drawing.Point(215, -1);
            this.buttonPageRight.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPageRight.Name = "buttonPageRight";
            this.buttonPageRight.Size = new System.Drawing.Size(40, 40);
            this.buttonPageRight.TabIndex = 156;
            this.buttonPageRight.UseVisualStyleBackColor = false;
            this.buttonPageRight.Click += new System.EventHandler(this.buttonPageRight_Click);
            // 
            // toolTipInfo
            // 
            this.toolTipInfo.AutomaticDelay = 100;
            this.toolTipInfo.AutoPopDelay = 5000;
            this.toolTipInfo.InitialDelay = 100;
            this.toolTipInfo.ReshowDelay = 20;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROFL.Properties.Resources.Item_Blank;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelPage);
            this.Name = "Inventory";
            this.Size = new System.Drawing.Size(256, 104);
            this.VisibleChanged += new System.EventHandler(this.Inventory_VisibleChanged);
            this.panelPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPage;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonPageLeft;
        private System.Windows.Forms.Button buttonPageRight;
        private System.Windows.Forms.ToolTip toolTipInfo;
    }
}
