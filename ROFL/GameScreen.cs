using System;
using System.Collections.Generic;
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
	    public Item SelectedItem { get; set; }

        /// <summary>
        /// Game Constructor.
        /// </summary>
        public GameScreen(Game game)
		{
			InitializeComponent();

			_game = game;

			GoFullscreen(true);
            
            inventoryCharacter.InitializeInventory(_game.Player, 12, UpdateSelectedItem);
		    inventorySeller.InitializeInventory(_game.Seller, 16, UpdateSelectedItem);
		    inventoryEnemy.InitializeInventory(_game.Enemy, 8, UpdateSelectedItem);
		    itemInfo.InitializeItemInfo(_game.Player, UpdateSelectedItem, UpdateControls);
            characterInfo.InitializeCharacterInfo(_game.Player);
		}

        /// <summary>
        /// Check Victory Condition and Close Form if won.
        /// </summary>
        public void CheckVictoryCondition()
		{
			// Victory Condition must be implemented.
			if (_game.GoalAchieved)
			{
				GameStartStop(false);
				MessageBox.Show($"Congratulations, you have completed the Game in {labelGameTime.Text} hours! Now you will have great fame and renown!", "You won!");
				Close();
			}
	    }

	    /// <summary>
	    /// On Form Show, update all controls.
	    /// </summary>
	    /// <param name="sender"></param>
	    /// <param name="e"></param>
	    private void GameScreen_Shown(object sender, EventArgs e)
	    {
	        UpdateControls();
	    }

	    private void UpdatePlayerPanel()
	    {
	        characterInfo.UpdateInfo();
        }

        /// <summary>
        /// Update all controls (labels, pictureboxes, etc.)
        /// </summary>
        private void UpdateControls()
	    {
	        UpdatePlayerPanel();
	        UpdateInventoryPanels();
	        UpdateItemInfo();
	        UpdateLocation();
	        UpdateRoom();
	    }

        /// <summary>
        /// Update selected item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Item UpdateSelectedItem(Item item)
	    {
	        SelectedItem = item;
            inventoryEnemy.SelectedItem = SelectedItem;
            inventoryCharacter.SelectedItem = SelectedItem;
            inventorySeller.SelectedItem = SelectedItem;
            itemInfo.SelectedItem = SelectedItem;

	        UpdateInventoryPanels();
	        UpdateItemInfo();
            
	        return item;
	    }
	    
	    /// <summary>
	    /// Update all Inventory Panels
	    /// </summary>
	    private void UpdateInventoryPanels()
	    {
	        UpdateCharacterPanel();
	        UpdateSellerPanel();
	        UpdateEnemyPanel();
	    }

	    /// <summary>
	    /// Update Inventory Panel.
	    /// </summary>
	    private void UpdateCharacterPanel()
	    {
	        inventoryCharacter.UpdateAllItems();
	    }

	    /// <summary>
	    /// Update Store Panel.
	    /// </summary>
	    private void UpdateSellerPanel()
	    {
	        inventorySeller.UpdateAllItems();
	    }

	    /// <summary>
	    /// Update Room Loot Controls
	    /// </summary>
	    private void UpdateEnemyPanel()
	    {
	        if (!inventoryEnemy.Visible) return;

	        labelRoomLootMoney.Text = $"{_game.Enemy.Money:C}";
	        inventoryEnemy.UpdateAllItems();
	    }

	    /// <summary>
	    /// Entites between which item can be transferred.
	    /// </summary>
	    /// <returns>Tuple of giver and receiver</returns>
	    private Tuple<IEntity, IEntity> ItemTransferEntities()
	    {
	        var giver = _game.GetEntity(_game.GetItemOwnerEnum(SelectedItem));
	        IEntity receiver = giver != null ? _game.Player : null;
	        if (giver == _game.Player)
	        {
	            receiver = inventorySeller.Visible ? _game.Seller :
	                inventoryEnemy.Visible ? _game.Enemy : null;
	        }
	        return new Tuple<IEntity, IEntity>(giver, receiver);
	    }
        
        /// <summary>
        /// Update Item Info.
        /// </summary>
        private void UpdateItemInfo()
	    {
	        // Update Item Info
	        var result = ItemTransferEntities();
	        var giver = result.Item1;
	        var receiver = result.Item2;

	        // Item Info is only visible if its owner inventory items panel stays visible.
	        var inventoryVisible = giver != null && ((Inventory)Controls.Find($"inventory{giver.Type}", true)[0]).Visible;

            itemInfo.Giver = giver;
	        itemInfo.Receiver = receiver;
            itemInfo.SetNextItem();
	        itemInfo.UpdateItemInfo(inventoryVisible);
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
		/// Description of Health Status.
		/// </summary>
		/// <returns>Health Descriptor</returns>
		public string HealthDescriptor()
		{
			var percentage = (double)_game.Player.Health / _game.Player.MaxHealth;
			var healthPoints = $" ({_game.Player.Health}/{_game.Player.MaxHealth})";

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
                    if(panelSeller.Visible)
					    UpdateSellerPanel();
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
				    _game.Player.Health = _game.Player.MaxHealth;
				    UpdatePlayerPanel();
                    if (_game.Player.Health == _game.Player.MaxHealth)
					{
						MessageBox.Show(
							"You are already rested and at full strength!",
							"Already Rested");
					}
					else
					{
						MessageBox.Show(
							"You have rested and are now at full strength!",
							"Rested");
					}
					break;
				case GameLocation.Dungeon:
					_game.DungeonLevel--;
					UpdateLocation();
					break;
			}
	    }

	    /// <summary>
	    /// Update Room Controls.
	    /// </summary>
	    private void UpdateRoom()
	    {
	        if (!panelRoom.Visible) return;

	        labelRoomEvent.Text = " ..." + _game.RoomDescription;
	        labelExperienceGain.Text = _game.ExperienceGained.ToString();

	        if (_game.Enemy?.Items.Count > 0 || _game.Enemy?.Money > 0)
	        {
	            panelRoomLoot.Visible = true;
	            UpdateEnemyPanel();
	        }
	        else
	        {
	            panelRoomLoot.Visible = false;
	        }
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
        /// Take Loot Money from the Current Room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRoomLootTakeMoney_Click(object sender, EventArgs e)
		{
			_game.Player.Money += _game.Enemy.Money;
			_game.Enemy.Money = 0;

			UpdatePlayerPanel();
			UpdateEnemyPanel();
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
            GameStartStop(!timerSecond.Enabled);
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
        /// Update Item Info when other inventories change visibility.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inventory_VisibleChanged(object sender, EventArgs e)
        {
            UpdateItemInfo();
        }
    }
}
