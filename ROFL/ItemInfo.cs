using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace ROFL
{
    public partial class ItemInfo : UserControl
    {
        /// <summary>
        /// Previous selected item Owner.
        /// </summary>
        private EntityType _previousReceiverType;

        /// <summary>
        /// Previous Inventory Holder opened.
        /// </summary>
        private EntityType _previousGiverType;

        /// <summary>
        /// Previous selected item.
        /// </summary>
        private Item _previousSelectedItem;

        /// <summary>
        /// Player Character.
        /// </summary>
        public Character Player { get; private set; }
        
        /// <summary>
        /// Current Selected Item.
        /// </summary>
        public Item SelectedItem { get; set; }

        /// <summary>
        /// Next item to select.
        /// </summary>
        public Item NextItem { get; private set; }

        /// <summary>
        /// Item Giver (Owner) in transfers.
        /// </summary>
        public IEntity Giver { get; set; }

        /// <summary>
        /// Item Receiver in transfers.
        /// </summary>
        public IEntity Receiver { get; set; }

        /// <summary>
        /// Function to run when updated selected item.
        /// </summary>
        public Func<Item, Item> UpdateSelectedItem { get; private set; }

        /// <summary>
        /// Action to invoke to update all controls.
        /// </summary>
        public Action UpdateControls { get; private set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ItemInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize Item Info for Player.
        /// </summary>
        /// <param name="player">Game Player Character</param>
        /// <param name="updateSelection"></param>
        /// <param name="updateControls"></param>
        public void InitializeItemInfo(Character player, Func<Item, Item> updateSelection, Action updateControls)
        {
            Player = player;
            UpdateSelectedItem = updateSelection;
            UpdateControls = updateControls;
        }

        /// <summary> 
		/// Update Item Panel.
		/// </summary>
		public void UpdateItemInfo(bool inventoryVisible)
        {
            if (SelectedItem == null)
            {
                Visible = false;
                return;
            }

            // Item Panel is only visible if its owner inventory items panel stays visible.
            Visible = inventoryVisible;
            if (!Visible) return;

            // Draw rest if owner, item or transfer owner changed
            if (_previousSelectedItem == SelectedItem &&
                _previousReceiverType == Receiver?.Type &&
                _previousGiverType == Giver.Type) return;
            _previousReceiverType = Receiver?.Type ?? EntityType.None;

            // Item Transfer
            var transferType = SelectedItem.TransferTypeFromTo(Giver, Receiver);

            buttonItemTrade.Visible = transferType != TransferType.None;
            var tradePriceMessage = "";

            // Item ITradeable
            var tradeableItem = (SelectedItem as ITradeable);
            panelItemCost.Visible = tradeableItem != null;
            if (tradeableItem != null)
            {
                var price = SelectedItem.TradePrice(tradeableItem, transferType);

                // Item Cost Panel
                toolTipInfo.SetToolTip(labelItemCost, $"{transferType}ing Price");
                labelItemCost.Text = $"{price:C}";

                if (transferType == TransferType.Sell || transferType == TransferType.Buy)
                {
                    tradePriceMessage = $" for {price:C}";
                }
            }
            // Transfer Action:
            buttonItemTrade.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject($"Action_{transferType}");
            toolTipInfo.SetToolTip(buttonItemTrade, $"You can {transferType} this {SelectedItem.Name}{tradePriceMessage}.");

            // Draw rest if owner or item changed
            if (_previousSelectedItem == SelectedItem &&
                _previousGiverType == Giver.Type) return;
            _previousGiverType = Giver.Type;

            // Owner Image
            pictureBoxItemOwner.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject($"Inventory_{Giver.Type}");
            toolTipInfo.SetToolTip(pictureBoxItemOwner, $"Located in {Giver.Type} Inventory.");

            // Item Trashing
            buttonTrash.Visible = SelectedItem.CanTrash(Player);
            toolTipInfo.SetToolTip(buttonTrash, $"Trash {SelectedItem.Name}.");

            // Draw rest if item changed
            if (_previousSelectedItem == SelectedItem) return;
            _previousSelectedItem = SelectedItem;

            // Item Info
            labelItemName.Text = SelectedItem.Name;
            labelItemInfo.Text = "Info: " + SelectedItem.Description;
            buttonItem.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject($"Item_{SelectedItem.UniqueNameId}");

            // Item IUsable
            var usableItem = (SelectedItem as IUsable);
            if (usableItem != null)
            {
                toolTipInfo.SetToolTip(buttonItemUse, usableItem.UseDescription());
            }
            buttonItemUse.Visible = usableItem != null;
        }
        
        /// <summary>
        /// Get next item to select.
        /// </summary>
        public void SetNextItem()
        {
            if (SelectedItem == null || Giver == null || Giver.Items.Count == 1)
            {
                NextItem = null;
                return;
            }

            var itemIndex = Giver.Items.FindIndex(a => a == SelectedItem);
            NextItem = itemIndex < Giver.Items.Count - 1 ? Giver.Items[itemIndex + 1] : Giver.Items[itemIndex - 1];
        }

        /// <summary>
        /// Try to perform an Action and print exception message if failed.
        /// </summary>
        /// <param name="action">Action to perform.</param>
        /// <param name="item">Item, which action's we are performing</param>
        /// <param name="verbName">Action in verb form</param>
        /// <param name="nounName">Action in noun form</param>
        /// <param name="selectNext"></param>
        private void DoItemActionTry(Action action, Item item, string verbName, string nounName, Item selectNext = null)
        {
            try
            {
                action.Invoke();
                if (selectNext != null)
                {
                    UpdateSelectedItem(selectNext);
                }
                UpdateControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot {verbName} {item.Name}, because {ex.Message}", $"{nounName} Failed");
            }
        }

        /// <summary>
        /// Use Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItemUse_Click(object sender, EventArgs e)
        {
            if (SelectedItem != null && SelectedItem is IUsable usableItem)
            {
                DoItemActionTry(() => usableItem.UseTry(Player),
                    SelectedItem,
                    usableItem.UseVerbName().ToLower(),
                    usableItem.UseNounName(),
                    NextItem);
            }
        }

        /// <summary>
        /// Trade Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItemTrade_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null) return;

            DoItemActionTry(() => SelectedItem.TransferTry(Giver, Receiver),
                SelectedItem,
                "trade",
                "Trading",
                NextItem);
        }

        /// <summary>
        /// Trash Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTrash_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null) return;

            if (SelectedItem is ITradeable tradeableItem && tradeableItem.SellPrice > 0)
            {
                if (MessageBox.Show(
                        $"Are you sure you want to trash {SelectedItem.Name}? It can be sold for {tradeableItem.SellPrice:C} in the store!",
                        "Are you sure?",
                        MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            DoItemActionTry(() => SelectedItem.TrashTry(Player),
                SelectedItem,
                "trash",
                "Trashing",
                NextItem);
        }
    }
}
