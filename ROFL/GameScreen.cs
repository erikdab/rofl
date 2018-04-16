﻿using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Engine;

namespace ROFL
{
    /// <summary>
    /// Game Screen Form.
    /// </summary>
    public partial class GameScreen : TemplateForm
    {
        /// <summary>
        /// Game Information
        /// </summary>
        private Game _game;

        /// <summary>
        /// Current selected item.
        /// </summary>
        private Item _selectedItem;

        /// <summary>
        /// Current Store Page.
        /// </summary>
        private int _storePage = 0;

        /// <summary>
        /// How many Store Items can fit per Page.
        /// </summary>
        private int _storeItemsPerPage = 16;

        /// <summary>
        /// Max Store Pages.
        /// </summary>
        private int MaxStorePage => (int) Math.Floor((double) _game.Seller.InventorySize / _storeItemsPerPage);

        /// <summary>
        /// Game Constructor.
        /// </summary>
        public GameScreen(Game game)
        {
            InitializeComponent();

            _game = game;

            UpdateControls();

            GoFullscreen(true);
        }

        /// <summary>
        /// Check Victory Condition and Close Form if won.
        /// </summary>
        public void CheckVictoryCondition() {
            // Victory Condition must be implemented.
            if (_game.GoalAchieved)
            {
                GameStartStop(false);
                MessageBox.Show($"Congratulations, you have completed the Game in {labelGameTime.Text} hours! Now you will have great fame and renown!", "You won!");
                Close();
            }
        }

        /// <summary>
        /// Update all controls (labels, pictureboxes, etc.)
        /// </summary>
        private void UpdateControls()
        {
            UpdatePlayerPanel();
            UpdateCharacterInventoryPanel();
            UpdateItemPanel();
            UpdateSellerInventoryPanel();
            UpdateLocation();
            UpdateRoom();
        }

        /// <summary>
        /// Update Room Controls.
        /// </summary>
        private void UpdateRoom()
        {
            if (! panelRoom.Visible) return;

            labelRoomEvent.Text = " ..."+_game.RoomDescription;
            labelExperienceGain.Text = _game.ExperienceGained.ToString();

            panelRoomLoot.Visible = false;

            if (_game.Enemy?.Items.Count > 0 || _game.Enemy?.Money > 0)
            {
                panelRoomLoot.Visible = true;
                UpdateEnemyInventoryPanel();
            }
        }

        /// <summary>
        /// Update Location Controls.
        /// </summary>
        private void UpdateLocation()
        {
            labelLocation.Text = _game.GameLocation.ToString();
            labelLocationTitle.Text = _game.GameLocation.ToString();

            switch (_game.GameLocation)
            {
                case GameLocation.Village:
                    labelLocation1.Visible = buttonLocation1.Visible = true;
                    buttonLocation1.BackgroundImage = Properties.Resources.Shop;
                    labelLocation1.Text = "Open Shop";
                    buttonLocation2.BackgroundImage = Properties.Resources.TellTales;
                    labelLocation2.Text = "Tell Tall Tales";
                    labelLocation2.Visible = buttonLocation2.Visible = true;
                    buttonLocation3.BackgroundImage = Properties.Resources.Dungeon;
                    labelLocation3.Text = "Enter Dungeon";
                    buttonLocation4.BackgroundImage = Properties.Resources.Rest;
                    labelLocation4.Text = "Safely Rest and Heal";
                    labelLocation4.Visible = buttonLocation4.Visible = true;
                    break;
                case GameLocation.Dungeon:
                    labelLocationTitle.Text += $" Level {_game.DungeonLevel}, Opened Rooms: {_game.OpenedRooms}";

                    labelLocation1.Visible = buttonLocation1.Visible = _game.CanOpenRoom();
                    buttonLocation1.BackgroundImage = Properties.Resources.NewRoom;
                    labelLocation1.Text = "Explore new Room";
                    labelLocation2.Visible = buttonLocation2.Visible = _game.CanTravelDown();
                    buttonLocation2.BackgroundImage = Properties.Resources.TravelDown;
                    labelLocation2.Text = "Go Down a Level";
                    buttonLocation3.BackgroundImage = Properties.Resources.Village;
                    labelLocation3.Text = "Return to Village";
                    buttonLocation4.BackgroundImage = Properties.Resources.TravelUp;
                    labelLocation4.Text = "Go Up a Level";
                    labelLocation4.Visible = buttonLocation4.Visible = _game.DungeonLevel > 0;
                    break;
            }
            toolTipInfo.SetToolTip(buttonLocation1, labelLocation1.Text);
            toolTipInfo.SetToolTip(buttonLocation2, labelLocation2.Text);
            toolTipInfo.SetToolTip(buttonLocation3, labelLocation3.Text);
            toolTipInfo.SetToolTip(buttonLocation4, labelLocation4.Text);
        }

        /// <summary>
        /// Update Player Panel Controls.
        /// </summary>
        private void UpdatePlayerPanel()
        {
            while (_game.Character.LevelUpRemainingCost == 0)
            {
                _game.Character.LevelUpTry();
            }

            labelCharacterName.Text = _game.Character.Name;

            labelCharacterLevel.Text = _game.Character.Level.ToString();
            labelCharacterMoney.Text = $"{_game.Character.Money:C}";

            progressBarCharacterHealth.Maximum = _game.Character.MaxHealth;
            progressBarCharacterHealth.Value = _game.Character.Health;
            toolTipInfo.SetToolTip(progressBarCharacterHealth, HealthDescriptor());

            progressBarCharacterExperience.Maximum = _game.Character.LevelUpCost;
            progressBarCharacterExperience.Value = _game.Character.Experience;
            toolTipInfo.SetToolTip(progressBarCharacterExperience, $"You still need {_game.Character.LevelUpRemainingCost} Experience to Level Up.");
        }
        
        /// <summary>
        /// Description of Health Status.
        /// </summary>
        /// <returns>Health Descriptor</returns>
        public string HealthDescriptor()
        {
            var percentage = (double)_game.Character.Health / _game.Character.MaxHealth;
            var healthPoints = $" ({_game.Character.Health}/{_game.Character.MaxHealth})";

            if (percentage >= 1.0)
            {
                return $"You are at full Health.{healthPoints}";
            }

            if (percentage >= 0.8)
            {
                return $"You are at good Health.{healthPoints}";
            }

            if (percentage >= 0.6)
            {
                return $"You are wounded.{healthPoints}";
            }

            if (percentage >= 0.4)
            {
                return $"You need healing!{healthPoints}";
            }

            if (percentage >= 0.2)
            {
                return $"You are gravely wounded!{healthPoints}";
            }

            if (percentage > 0.0)
            {
                return $"Get to safety!{healthPoints}";
            }

            return "You are dead!";
        }

        /// <summary>
        /// Update a single Inventory Item belonging to the Player Character or NPC Seller.
        /// </summary>
        private void UpdateInventoryItem(IEntity entity, string inventoryType, int buttonIndex, int itemIndex)
        {
            var inventoryButton = (Button)(Controls.Find($"button{inventoryType}Inventory{buttonIndex}", true)[0]);
            var emptySlot = entity.Items.Count <= itemIndex;
            inventoryButton.Enabled = ! emptySlot;
            if (emptySlot)
            {
                inventoryButton.BackgroundImage = null;
                return;
            }
            var item = entity.Items[itemIndex];
            inventoryButton.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject($"Item_{item.UniqueNameId}");
            toolTipInfo.SetToolTip(inventoryButton, $"{item.Name}{Environment.NewLine}{item.Description}");
        }

        /// <summary>
        /// Update Inventory Panel.
        /// </summary>
        private void UpdateCharacterInventoryPanel()
        {
            for (var index = 0; index < _game.Character.InventorySize; index++)
            {
                UpdateInventoryItem(_game.Character, "Character", index, index);
            }
        }

        /// <summary>
        /// Update Store Panel.
        /// </summary>
        private void UpdateSellerInventoryPanel()
        {
            if (!panelSeller.Visible) return;

            for (var buttonIndex = 0; buttonIndex < _storeItemsPerPage; buttonIndex++)
            {
                var itemIndex = _storeItemsPerPage * _storePage + buttonIndex;
                UpdateInventoryItem(_game.Seller, "Seller", buttonIndex, itemIndex);
            }

            labelStorePage.Text = $"Page: {_storePage + 1}";
        }

        /// <summary>
        /// Update Room Loot Controls
        /// </summary>
        private void UpdateEnemyInventoryPanel()
        {
            if (!panelRoomLoot.Visible) return;

            labelRoomLootMoney.Text = $"{_game.Enemy.Money:C}";

            for (var index = 0; index < _game.Enemy.InventorySize; index++)
            {
                UpdateInventoryItem(_game.Enemy, "Enemy", index, index);
            }
        }

        /// <summary>
        /// Update Item Panel.
        /// </summary>
        private void UpdateItemPanel()
        {
            var playerOwned = _game.Character.OwnsItem(_selectedItem);
            var sellerOwned = _game.Seller.OwnsItem(_selectedItem);
            labelItemPanelTitle.Text = playerOwned ? "Player Item" : sellerOwned ? "Seller Item" : $"{_game.Enemy.Name} Item";

            panelItem.Visible = panelCharacterInventory.Visible && _selectedItem != null;

            if (_selectedItem == null) return;

            labelItemName.Text = _selectedItem.Name;
            labelItemInfo.Text = "Info: " + _selectedItem.Description;
            buttonItem.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject($"Item_{_selectedItem.UniqueNameId}");
            
            var usableItem = (_selectedItem as IUsable);
            if (usableItem != null)
            {
                toolTipInfo.SetToolTip(buttonItemUse, usableItem.UseDescription());
            }
            buttonItemUse.Visible = usableItem != null;

            var sellableItem = (_selectedItem as ITradeable);
            panelItemCost.Visible = sellableItem != null;
            buttonItemTrade.Visible = sellableItem != null;
            if (sellableItem != null)
            {
                if (playerOwned)
                {
                    labelItemCost.Text = $"{sellableItem.SellCost:C}";
                    if (panelSeller.Visible)
                    {
                        buttonItemTrade.BackgroundImage = Properties.Resources.Action_Sell;
                        toolTipInfo.SetToolTip(buttonItemTrade, $"Selling this {_selectedItem.Name} will cash in {sellableItem.SellCost:C}.");
                    }
                    else
                    {
                        buttonItemTrade.Visible = false;
                    }
                }
                else if(sellerOwned)
                {
                    labelItemCost.Text = $"{sellableItem.BuyCost:C}";
                    buttonItemTrade.BackgroundImage = Properties.Resources.Action_Buy;
                    toolTipInfo.SetToolTip(buttonItemTrade, $"Buying this {_selectedItem.Name} will cost {sellableItem.BuyCost:C}.");
                }
                else
                {
                    labelItemCost.Text = $"{sellableItem.SellCost:C}";
                    buttonItemTrade.BackgroundImage = Properties.Resources.Action_Take;
                    toolTipInfo.SetToolTip(buttonItemTrade, $"You may take this {_selectedItem.Name} for free!");
                }
            }

            buttonTrash.Visible = _selectedItem.CanTrash(_game.Character);
        }

        /// <summary>
        /// Play or pause game and toggle the start pause icon.
        /// </summary>
        /// <param name="start">If Game Should be running</param>
        private void GameStartStop(bool start)
        {
            if (start)
            {
                timerSecond.Start();
                buttonPlayPause.BackgroundImage = Properties.Resources.right;
            }
            else
            {
                timerSecond.Stop();
                buttonPlayPause.BackgroundImage = Properties.Resources.pause;
            }
        }

        /// <summary>
        /// Close Form Button handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to exit the game? You will have to start a new game!", "Exit?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Minimize Form Button handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Toggle between Game Play/Pause.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            GameStartStop(! timerSecond.Enabled);
        }

        /// <summary>
        /// Show the Help Screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            GameStartStop(false);
            var form = new Help();
            form.ShowDialog();
            GameStartStop(true);
        }

        /// <summary>
        /// Open Scenario Information Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonScenario_Click(object sender, EventArgs e)
        {
            GameStartStop(false);
            var form = new Scenario();
            form.ShowDialog();
            GameStartStop(true);
        }

        /// <summary>
        /// Update and display Game time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSecond_Tick(object sender, EventArgs e)
        {
            _game.UpdateTime();
            labelGameTime.Text = _game.GameTime;
        }

        /// <summary>
        /// Maximize / Minimize screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMaximizeMinimize_Click(object sender, EventArgs e)
        {
            ToggleFullscreen();
            buttonMaximizeMinimize.BackgroundImage = IsFullscreen() ? Properties.Resources.smaller : Properties.Resources.larger;
        }

        /// <summary>
        /// Toggle Inventory Panel visibility and hide Item Panel.
        /// </summary>
        private void ToggleInventory()
        {
            panelCharacterInventory.Visible = !panelCharacterInventory.Visible;
            buttonCharacterInventoryToggle.BackgroundImage =
                panelCharacterInventory.Visible ? Properties.Resources.down : Properties.Resources.up;

            UpdateItemPanel();
        }

        /// <summary>
        /// Button to toggle Inventory Panel visibility and hide Item Panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCharacterInventoryToggle_Click(object sender, EventArgs e)
        {
            ToggleInventory();
        }

        /// <summary>
        /// Click Inventory Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInventoryItem_Click(object sender, EventArgs e)
        {
            // Get Inventory Number of current button.
            var buttonSender = (Button) sender;
            var buttonNameNumeric = new string(buttonSender.Name.Where(char.IsDigit).ToArray());
            var inventoryNumber = int.Parse(buttonNameNumeric);
            IEntity entity;
            if (buttonSender.Name.Contains("Enemy"))
            {
                entity = _game.Enemy;
            }
            else if (buttonSender.Name.Contains("Character"))
            {
                entity = _game.Character;
            }
            else
            {
                entity = _game.Seller;
                inventoryNumber += _storeItemsPerPage * _storePage;
            }

            var newSelection = entity.Items[inventoryNumber];

            // Select only if it is a new item, otherwise unselect.
            _selectedItem = _selectedItem != newSelection ? entity.Items[inventoryNumber] : null;

            UpdateItemPanel();
        }

        /// <summary>
        /// Try to perform an Action and print exception message if failed.
        /// </summary>
        /// <param name="action">Action to perform.</param>
        /// <param name="item">Item, which action's we are performing</param>
        /// <param name="verbName">Action in verb form</param>
        /// <param name="nounName">Action in noun form</param>
        private void DoItemActionTry(Action action, Item item, string verbName, string nounName)
        {
            try
            {
                action.Invoke();
                _selectedItem = null;
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
            if (_selectedItem != null && _selectedItem is IUsable usableItem)
            {
                DoItemActionTry(() => usableItem.UseTry(_game.Character), 
                    _selectedItem,
                    usableItem.UseVerbName().ToLower(),
                    usableItem.UseNounName());
            }
        }

        /// <summary>
        /// Trade Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItemTrade_Click(object sender, EventArgs e)
        {
            if (_selectedItem != null && _selectedItem is ITradeable tradeableItem)
            {
                Action action;
                if (_game.Character.OwnsItem(_selectedItem))
                {
                    action = () => tradeableItem.SellTry(_game.Character, _game.Seller);
                }
                else if(_game.Seller.OwnsItem(_selectedItem))
                {
                    action = () => tradeableItem.BuyTry(_game.Character, _game.Seller);
                }
                else
                {
                    action = () =>
                    {
                        _game.Character.Items.Add(_selectedItem);
                        _game.Enemy.Items.Remove(_selectedItem);
                    };
                }
                DoItemActionTry(action,
                    _selectedItem,
                    "trade",
                    "Trading");
            }
        }

        /// <summary>
        /// Trash Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTrash_Click(object sender, EventArgs e)
        {
            if (_selectedItem == null) return;

            if (_selectedItem is ITradeable tradeableItem && tradeableItem.SellCost > 0)
            {
                if (MessageBox.Show(
                        $"Are you sure you want to trash {_selectedItem.Name}? It can be sold for {tradeableItem.SellCost} in the store!",
                        "Are you sure?",
                        MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            DoItemActionTry(() => _selectedItem.TrashTry(_game.Character),
                _selectedItem,
                "trash",
                "Trashing");
        }

        /// <summary>
        /// Move to Previous Page in Store.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStorePageLeft_Click(object sender, EventArgs e)
        {
            _storePage--;
            if (_storePage < 0)
            {
                _storePage = MaxStorePage-1;
            }
            UpdateSellerInventoryPanel();
        }

        /// <summary>
        /// Move to Next Page in Store.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStorePageRight_Click(object sender, EventArgs e)
        {
            _storePage++;
            if (_storePage >= MaxStorePage)
            {
                _storePage = 0;
            }
            UpdateSellerInventoryPanel();
        }

        /// <summary>
        /// Enter New Room.
        /// </summary>
        private void EnterNewRoom()
        {
            panelRoom.Visible = true;
            try
            {
                _game.OpenRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Event");
            }

            if (_game.GameLocation != GameLocation.Dungeon)
            {
                panelRoom.Visible = false;
            }
            UpdateRoom();
            UpdateLocation();
            UpdatePlayerPanel();
            CheckVictoryCondition();
        }

        /// <summary>
        /// Perform Action 1 For Current Location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLocation1_Click(object sender, EventArgs e)
        {
            switch (_game.GameLocation)
            {
                case GameLocation.Village:
                    panelSeller.Visible = !panelSeller.Visible;
                    UpdateSellerInventoryPanel();
                    UpdateItemPanel();
                    break;
                case GameLocation.Dungeon:
                    EnterNewRoom();
                    break;
            }
        }

        /// <summary>
        /// Perform Action 2 For Current Location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLocation2_Click(object sender, EventArgs e)
        {
            switch (_game.GameLocation)
            {
                case GameLocation.Village:
                    MessageBox.Show(
                        "You enjoyed a jolly time telling of your Real or Fake Legends to the admiration of many.",
                        "Events");
                    break;
                case GameLocation.Dungeon:
                    _game.DungeonLevel++;
                    UpdateLocation();
                    break;
            }
        }

        /// <summary>
        /// Perform Action 3 For Current Location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLocation3_Click(object sender, EventArgs e)
        {

            switch (_game.GameLocation)
            {
                case GameLocation.Village:
                    _game.ChangeLocation(GameLocation.Dungeon);
                    break;
                case GameLocation.Dungeon:
                    _game.ChangeLocation(GameLocation.Village);
                    break;
            }
            UpdateLocation();
            panelSeller.Visible = false;
            if (! _game.Character.OwnsItem(_selectedItem))
            {
                _selectedItem = null;
            }
            UpdateItemPanel();
        }

        /// <summary>
        /// Perform Action 4 For Current Location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLocation4_Click(object sender, EventArgs e)
        {
            switch (_game.GameLocation)
            {
                case GameLocation.Village:
                    _game.Character.Health = _game.Character.MaxHealth;
                    UpdatePlayerPanel();
                    break;
                case GameLocation.Dungeon:
                    _game.DungeonLevel--;
                    UpdateLocation();
                    break;
            }
        }

        /// <summary>
        /// Take Loot Money from the Current Room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRoomLootTakeMoney_Click(object sender, EventArgs e)
        {
            _game.Character.Money += _game.Enemy.Money;
            _game.Enemy.Money = 0;

            UpdatePlayerPanel();
            UpdateEnemyInventoryPanel();
        }

        /// <summary>
        /// Close the Room Panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRoomClose_Click(object sender, EventArgs e)
        {
            panelRoom.Visible = false;
        }
    }
}
