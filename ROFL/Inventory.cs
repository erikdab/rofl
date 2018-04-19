using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Engine;
using ROFL.Properties;

namespace ROFL
{
    public partial class Inventory : UserControl
    {
        /// <summary>
        /// Size of inventory management controls.
        /// </summary>
        public const int ManagementControlSize = 30;

        /// <summary>
        /// Size (width/height) of item.
        /// </summary>
        public const int ItemSize = 64;

        /// <summary>
        /// Items per row.
        /// </summary>
        public const int ItemsPerRow = 4;

        /// <summary>
        /// Inventory User Control Padding.
        /// </summary>
        public const int Padding = 2;

        /// <summary>
        /// Owner entity.
        /// </summary>
        public IEntity Entity { get; private set; }

        /// <summary>
        /// Current page.
        /// </summary>
        public int Page { get; private set; } = 0;

        /// <summary>
        /// Page size.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Item row count.
        /// </summary>
        public int ItemRows => (int) ((double)PageSize / ItemsPerRow);

        /// <summary>
        /// Last page number.
        /// </summary>
        public int LastPage => Math.Max(1, (int)Math.Ceiling((double)Entity.Items.Count / PageSize));

        /// <summary>
        /// Check if split into pages.
        /// </summary>
        public bool IsPaged => Entity.Items.Count > PageSize;

        /// <summary>
        /// Item buttons.
        /// </summary>
        private Button[] _itemButtons;

        /// <summary>
        /// Current selected item.
        /// </summary>
        public Item SelectedItem { get; set; }

        /// <summary>
        /// Function to run when updated selected item.
        /// </summary>
        public Func<Item, Item> UpdateSelectedItem { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Inventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize Inventory Items for Entity.
        /// </summary>
        /// <param name="entity">Inventory Entity owner.</param>
        /// <param name="pageSize">Size of Inventory Page.</param>
        /// <param name="updateSelection">Method to update selected item for all panels.</param>
        public void InitializeInventory(IEntity entity, int pageSize, Func<Item, Item> updateSelection)
        {
            Entity = entity;
            PageSize = pageSize;
            UpdateSelectedItem = updateSelection;

            UpdateManagementControls();

            _itemButtons = new Button[PageSize];

            for (var index = 0; index < PageSize; index++)
            {
                var button = _itemButtons[index] = new Button();
                var x = index % ItemsPerRow;
                var y = (int)((double)index / ItemsPerRow);

                button.Location = new Point(x*ItemSize, y*ItemSize);
                UpdateItem(index);

                button.BackColor = Color.Transparent;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;
                button.Margin = new Padding(0);
                button.Name = $"button{Entity.Type}Inventory{index}";
                button.Size = new Size(ItemSize, ItemSize);
                button.TabIndex = index;
                button.UseVisualStyleBackColor = false;
                button.Click += buttonItem_Click;
                Controls.Add(button);
            }
        }

        /// <summary>
        /// Update Management Controls.
        /// </summary>
        private void UpdateManagementControls()
        {
            UpdatePageControls();
            UpdateSortControls();
        }

        private Size InventoryItemsSize()
        {
            var width = ItemSize * ItemsPerRow + Padding;
            var height = ItemRows * ItemSize + Padding;

            return new Size(width, height);
        }

        /// <summary>
        /// Update Page Controls, hiding them if not IsPaged.
        /// </summary>
        private void UpdatePageControls()
        {
            var itemsSize = InventoryItemsSize();
            var width = itemsSize.Width;
            var height = itemsSize.Height;

            panelPage.Visible = IsPaged;
            if (IsPaged)
            {
                height += ManagementControlSize;
                labelPage.Text = $"Page: {Page + 1}";
            }
            Size = new Size(width, height);
        }

        /// <summary>
        /// Update Sort Controls, placing them appropriately.
        /// </summary>
        private void UpdateSortControls()
        {
            var itemsSize = InventoryItemsSize();

            var x = itemsSize.Width - ManagementControlSize - Padding;
            var y = itemsSize.Height - Padding;
            
            if (! IsPaged)
            {
                y -= ManagementControlSize;
            }
            panelSort.Location = new Point(x, y);
        }

        /// <summary>
        /// Update all items.
        /// </summary>
        public void UpdateAllItems()
        {
            for (var index = 0; index < PageSize; index++)
            {
                UpdateItem(index);
            }

            UpdateManagementControls();

            if (Entity.Type == EntityType.Character)
            {
                labelSlots.Text = $"{Entity.Items.Count}/{Entity.InventorySize}";
            }
            else
            {
                labelSlots.Text = $"{Entity.Items.Count}";
            }
        }
        
        /// <summary>
        /// Update a single item.
        /// </summary>
        /// <param name="buttonIndex">Index of button to update</param>
        private void UpdateItem(int buttonIndex)
        {
            // Handle change of IsPaged to false.
            if (Page >= LastPage)
            {
                Page--;
            }
            var itemIndex = buttonIndex + Page * PageSize;

            var button = _itemButtons[buttonIndex];
            var emptySlot = Entity.Items.Count <= itemIndex;
            button.Enabled = !emptySlot;
            button.FlatAppearance.BorderSize = 0;
            if (emptySlot)
            {
                button.BackgroundImage = null;
                return;
            }

            var item = Entity.Items[itemIndex];
            button.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject($"Item_{item.UniqueNameId}");
            toolTipInfo.SetToolTip(button, $"{item.Name}{Environment.NewLine}{Environment.NewLine}{item.Description}");

            if (item == SelectedItem)
            {
                button.FlatAppearance.BorderColor = Color.Black;
                button.FlatAppearance.BorderSize = 5;
            }
        }

        /// <summary>
        /// Select item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem_Click(object sender, EventArgs e)
        {
            var controlName = ((Control)sender).Name;
            var itemIndex = int.Parse(new string(controlName.Where(char.IsDigit).ToArray()));

            if (IsPaged)
            {
                itemIndex += PageSize * Page;
            }

            UpdateSelectedItem(Entity.Items[itemIndex]);
        }

        /// <summary>
        /// Move to previous Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPageLeft_Click(object sender, EventArgs e)
        {
            Page--;
            if (Page < 0)
            {
                Page = LastPage - 1;
            }
            UpdateAllItems();
        }

        /// <summary>
        /// Move to next Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPageRight_Click(object sender, EventArgs e)
        {
            Page++;
            if (Page >= LastPage)
            {
                Page = 0;
            }
            UpdateAllItems();
        }

        /// <summary>
        /// Unselect item if hiding Inventory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inventory_VisibleChanged(object sender, EventArgs e)
        {
            if (! Visible && Entity != null && Entity.OwnsItem(SelectedItem))
            {
                UpdateSelectedItem(null);
            }
        }

        /// <summary>
        /// Sort Items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            Entity.SortItems();
            UpdateAllItems();
        }
    }
}
