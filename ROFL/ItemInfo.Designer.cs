namespace ROFL
{
    partial class ItemInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemInfo));
            this.pictureBoxItemOwner = new System.Windows.Forms.PictureBox();
            this.panelItemImage = new System.Windows.Forms.Panel();
            this.buttonItem = new System.Windows.Forms.Button();
            this.labelItemPanelTitle = new System.Windows.Forms.Label();
            this.labelItemInfo = new System.Windows.Forms.Label();
            this.panelItemActions = new System.Windows.Forms.Panel();
            this.buttonItemUse = new System.Windows.Forms.Button();
            this.buttonTrash = new System.Windows.Forms.Button();
            this.buttonItemTrade = new System.Windows.Forms.Button();
            this.panelItemCost = new System.Windows.Forms.Panel();
            this.labelItemCost = new System.Windows.Forms.Label();
            this.pictureBoxItemCost = new System.Windows.Forms.PictureBox();
            this.labelItemName = new System.Windows.Forms.Label();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemOwner)).BeginInit();
            this.panelItemImage.SuspendLayout();
            this.panelItemActions.SuspendLayout();
            this.panelItemCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemCost)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxItemOwner
            // 
            this.pictureBoxItemOwner.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItemOwner.BackgroundImage = global::ROFL.Properties.Resources.Inventory_Character;
            this.pictureBoxItemOwner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItemOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxItemOwner.Location = new System.Drawing.Point(-1, -1);
            this.pictureBoxItemOwner.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxItemOwner.Name = "pictureBoxItemOwner";
            this.pictureBoxItemOwner.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxItemOwner.TabIndex = 155;
            this.pictureBoxItemOwner.TabStop = false;
            // 
            // panelItemImage
            // 
            this.panelItemImage.BackgroundImage = global::ROFL.Properties.Resources.Item_Blank;
            this.panelItemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemImage.Controls.Add(this.buttonItem);
            this.panelItemImage.Enabled = false;
            this.panelItemImage.Location = new System.Drawing.Point(16, 44);
            this.panelItemImage.Name = "panelItemImage";
            this.panelItemImage.Size = new System.Drawing.Size(66, 66);
            this.panelItemImage.TabIndex = 158;
            // 
            // buttonItem
            // 
            this.buttonItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItem.BackColor = System.Drawing.Color.Transparent;
            this.buttonItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonItem.FlatAppearance.BorderSize = 0;
            this.buttonItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItem.Location = new System.Drawing.Point(0, 0);
            this.buttonItem.Margin = new System.Windows.Forms.Padding(0);
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Size = new System.Drawing.Size(64, 64);
            this.buttonItem.TabIndex = 101;
            this.buttonItem.UseVisualStyleBackColor = false;
            // 
            // labelItemPanelTitle
            // 
            this.labelItemPanelTitle.AutoSize = true;
            this.labelItemPanelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelItemPanelTitle.Font = new System.Drawing.Font("Segoe Print", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemPanelTitle.Location = new System.Drawing.Point(42, -1);
            this.labelItemPanelTitle.Name = "labelItemPanelTitle";
            this.labelItemPanelTitle.Size = new System.Drawing.Size(83, 47);
            this.labelItemPanelTitle.TabIndex = 153;
            this.labelItemPanelTitle.Text = "Item";
            // 
            // labelItemInfo
            // 
            this.labelItemInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelItemInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelItemInfo.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemInfo.Image = global::ROFL.Properties.Resources.background1_Game;
            this.labelItemInfo.Location = new System.Drawing.Point(16, 156);
            this.labelItemInfo.Name = "labelItemInfo";
            this.labelItemInfo.Size = new System.Drawing.Size(277, 115);
            this.labelItemInfo.TabIndex = 157;
            this.labelItemInfo.Text = "Info Text";
            // 
            // panelItemActions
            // 
            this.panelItemActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItemActions.BackgroundImage = global::ROFL.Properties.Resources.background1_Game;
            this.panelItemActions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelItemActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemActions.Controls.Add(this.buttonItemUse);
            this.panelItemActions.Controls.Add(this.buttonTrash);
            this.panelItemActions.Controls.Add(this.buttonItemTrade);
            this.panelItemActions.Location = new System.Drawing.Point(16, 113);
            this.panelItemActions.Name = "panelItemActions";
            this.panelItemActions.Size = new System.Drawing.Size(277, 40);
            this.panelItemActions.TabIndex = 156;
            // 
            // buttonItemUse
            // 
            this.buttonItemUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemUse.BackColor = System.Drawing.Color.Transparent;
            this.buttonItemUse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonItemUse.BackgroundImage")));
            this.buttonItemUse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonItemUse.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonItemUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemUse.Location = new System.Drawing.Point(-1, -1);
            this.buttonItemUse.Margin = new System.Windows.Forms.Padding(0);
            this.buttonItemUse.Name = "buttonItemUse";
            this.buttonItemUse.Size = new System.Drawing.Size(40, 40);
            this.buttonItemUse.TabIndex = 107;
            this.buttonItemUse.UseVisualStyleBackColor = false;
            this.buttonItemUse.Click += new System.EventHandler(this.buttonItemUse_Click);
            // 
            // buttonTrash
            // 
            this.buttonTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrash.BackColor = System.Drawing.Color.Transparent;
            this.buttonTrash.BackgroundImage = global::ROFL.Properties.Resources.Action_Trash;
            this.buttonTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTrash.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrash.Location = new System.Drawing.Point(77, -1);
            this.buttonTrash.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTrash.Name = "buttonTrash";
            this.buttonTrash.Size = new System.Drawing.Size(40, 40);
            this.buttonTrash.TabIndex = 109;
            this.buttonTrash.UseVisualStyleBackColor = false;
            this.buttonTrash.Click += new System.EventHandler(this.buttonTrash_Click);
            // 
            // buttonItemTrade
            // 
            this.buttonItemTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemTrade.BackColor = System.Drawing.Color.Transparent;
            this.buttonItemTrade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonItemTrade.BackgroundImage")));
            this.buttonItemTrade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonItemTrade.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.buttonItemTrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemTrade.Location = new System.Drawing.Point(38, -1);
            this.buttonItemTrade.Margin = new System.Windows.Forms.Padding(0);
            this.buttonItemTrade.Name = "buttonItemTrade";
            this.buttonItemTrade.Size = new System.Drawing.Size(40, 40);
            this.buttonItemTrade.TabIndex = 108;
            this.buttonItemTrade.UseVisualStyleBackColor = false;
            this.buttonItemTrade.Click += new System.EventHandler(this.buttonItemTrade_Click);
            // 
            // panelItemCost
            // 
            this.panelItemCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItemCost.BackgroundImage = global::ROFL.Properties.Resources.background1_Game;
            this.panelItemCost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelItemCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemCost.Controls.Add(this.labelItemCost);
            this.panelItemCost.Controls.Add(this.pictureBoxItemCost);
            this.panelItemCost.Location = new System.Drawing.Point(85, 78);
            this.panelItemCost.Name = "panelItemCost";
            this.panelItemCost.Size = new System.Drawing.Size(208, 32);
            this.panelItemCost.TabIndex = 154;
            // 
            // labelItemCost
            // 
            this.labelItemCost.AutoSize = true;
            this.labelItemCost.BackColor = System.Drawing.Color.Transparent;
            this.labelItemCost.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemCost.Location = new System.Drawing.Point(32, 1);
            this.labelItemCost.Name = "labelItemCost";
            this.labelItemCost.Size = new System.Drawing.Size(89, 28);
            this.labelItemCost.TabIndex = 104;
            this.labelItemCost.Text = "Sell Value";
            // 
            // pictureBoxItemCost
            // 
            this.pictureBoxItemCost.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItemCost.BackgroundImage = global::ROFL.Properties.Resources.Item_Money;
            this.pictureBoxItemCost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItemCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxItemCost.Location = new System.Drawing.Point(-1, -1);
            this.pictureBoxItemCost.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxItemCost.Name = "pictureBoxItemCost";
            this.pictureBoxItemCost.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxItemCost.TabIndex = 103;
            this.pictureBoxItemCost.TabStop = false;
            // 
            // labelItemName
            // 
            this.labelItemName.AutoSize = true;
            this.labelItemName.BackColor = System.Drawing.Color.Transparent;
            this.labelItemName.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemName.Location = new System.Drawing.Point(83, 46);
            this.labelItemName.Name = "labelItemName";
            this.labelItemName.Size = new System.Drawing.Size(101, 28);
            this.labelItemName.TabIndex = 152;
            this.labelItemName.Text = "Item Name";
            // 
            // toolTipInfo
            // 
            this.toolTipInfo.AutomaticDelay = 100;
            this.toolTipInfo.AutoPopDelay = 5000;
            this.toolTipInfo.InitialDelay = 100;
            this.toolTipInfo.ReshowDelay = 20;
            // 
            // ItemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROFL.Properties.Resources.background1_Game;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBoxItemOwner);
            this.Controls.Add(this.panelItemImage);
            this.Controls.Add(this.labelItemPanelTitle);
            this.Controls.Add(this.labelItemInfo);
            this.Controls.Add(this.panelItemActions);
            this.Controls.Add(this.panelItemCost);
            this.Controls.Add(this.labelItemName);
            this.Name = "ItemInfo";
            this.Size = new System.Drawing.Size(311, 290);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemOwner)).EndInit();
            this.panelItemImage.ResumeLayout(false);
            this.panelItemActions.ResumeLayout(false);
            this.panelItemCost.ResumeLayout(false);
            this.panelItemCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxItemOwner;
        private System.Windows.Forms.Panel panelItemImage;
        private System.Windows.Forms.Button buttonItem;
        private System.Windows.Forms.Label labelItemPanelTitle;
        private System.Windows.Forms.Label labelItemInfo;
        private System.Windows.Forms.Panel panelItemActions;
        private System.Windows.Forms.Button buttonItemUse;
        private System.Windows.Forms.Button buttonTrash;
        private System.Windows.Forms.Button buttonItemTrade;
        private System.Windows.Forms.Panel panelItemCost;
        private System.Windows.Forms.Label labelItemCost;
        private System.Windows.Forms.PictureBox pictureBoxItemCost;
        private System.Windows.Forms.Label labelItemName;
        private System.Windows.Forms.ToolTip toolTipInfo;
    }
}
