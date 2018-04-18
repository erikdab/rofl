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
        /// Game Constructor.
        /// </summary>
        public GameScreen(Game game)
		{
			InitializeComponent();

			_game = game;

			GoFullscreen(true);
            
            inventoryCharacter.InitializeInventory(_game.Character, 12, UpdateSelection);
		    inventorySeller.InitializeInventory(_game.Seller, 16, UpdateSelection);
		    inventoryEnemy.InitializeInventory(_game.Enemy, 8, UpdateSelection);
        }

        /// <summary>
        /// Update selected item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
	    public Item UpdateSelection(Item item)
	    {
	        SelectedItem = item;
            UpdateInventoryPanels();
            UpdateItemPanel();
	        return item;
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
		/// Update all controls (labels, pictureboxes, etc.)
		/// </summary>
		private void UpdateControls()
		{
			UpdatePlayerPanel();
			UpdateInventoryPanels();
			UpdateItemPanel();
			UpdateLocation();
			UpdateRoom();
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
			// If received experience for more than 1 level, upgrade multiple times.
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
			toolTipInfo.SetToolTip(progressBarCharacterExperience,
				$"You still need {_game.Character.LevelUpRemainingCost} Experience to Level Up.");
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
            inventoryCharacter.UpdateAllItems(SelectedItem);
        }

		/// <summary>
		/// Update Store Panel.
		/// </summary>
		private void UpdateSellerPanel()
		{
		    inventorySeller.UpdateAllItems(SelectedItem);
        }

		/// <summary>
		/// Update Room Loot Controls
		/// </summary>
		private void UpdateEnemyPanel()
		{
            if (! inventoryEnemy.Visible) return;

            labelRoomLootMoney.Text = $"{_game.Enemy.Money:C}";
		    inventoryEnemy.UpdateAllItems(SelectedItem);
		}

		/// <summary>
		/// Update Item Panel.
		/// </summary>
		private void UpdateItemPanel()
		{
			if (SelectedItem == null)
			{
				panelItem.Visible = false;
				return;
			}

		    var result = ItemTransferEntities();
		    var giver = result.Item1;
		    var receiver = result.Item2;

			// Item Panel is only visible if its owner inventory items panel stays visible.
			panelItem.Visible = giver != null && ((Inventory)Controls.Find($"inventory{giver.Type}", true)[0]).Visible;
			if (giver == null || ! panelItem.Visible) return;
            
			// Draw rest if owner, item or transfer owner changed
			if (_previousSelectedItem == SelectedItem &&
				_previousReceiverType == receiver?.Type &&
				_previousGiverType == giver.Type) return;
			_previousGiverType = giver.Type;

            // Item Transfer
		    var transferType = SelectedItem.TransferTypeFromTo(giver, receiver);
            
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
				_previousReceiverType == giver.Type) return;
			_previousReceiverType = giver.Type;

			// Owner Image
			pictureBoxItemOwner.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject($"Inventory_{giver.Type}");
			toolTipInfo.SetToolTip(pictureBoxItemOwner, $"Located in {giver.Type} Inventory.");

			// Item Trashing
			buttonTrash.Visible = SelectedItem.CanTrash(_game.Character);
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
        /// Get Owner of ownerString.
        /// </summary>
        /// <param name="ownerString">Control to search for owner.</param>
        /// <returns>Owner of ownerString</returns>
	    private EntityType GetOwnerFromString(string ownerString)
	    {
	        EntityType entityType;
	        if (ownerString.Contains("Enemy"))
	        {
	            entityType = EntityType.Enemy;
	        }
	        else if (ownerString.Contains("Character"))
	        {
	            entityType = EntityType.Character;
	        }
	        else if (ownerString.Contains("Seller"))
	        {
	            entityType = EntityType.Seller;
	        }
	        else
	        {
	            throw new Exception("Control not owned by a EntityType!");
            }

	        return entityType;

        }

        /// <summary>
        /// Entites between which item can be transferred.
        /// </summary>
        /// <returns>Tuple of giver and receiver</returns>
	    private Tuple<IEntity, IEntity> ItemTransferEntities()
	    {
	        var giver = _game.GetEntity(_game.GetItemOwnerEnum(SelectedItem));
	        IEntity receiver = _game.Character;
	        if (giver == _game.Character)
	        {
	            receiver = inventorySeller.Visible ? _game.Seller : 
	                inventoryEnemy.Visible ? _game.Enemy : null;
	        }
            return new Tuple<IEntity, IEntity>(giver, receiver);
        }

        /// <summary>
        /// Get next item to select.
        /// </summary>
        /// <returns></returns>
	    private Item GetNextItem()
        {
            var entity = _game.GetEntity(_game.GetItemOwnerEnum(SelectedItem));
            if (entity.Items.Count == 1) return null;

            var itemIndex = entity.Items.FindIndex(a => a == SelectedItem);
            return itemIndex < entity.Items.Count - 1 ? entity.Items[itemIndex + 1] : entity.Items[itemIndex - 1];
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
			        SelectedItem = selectNext;
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
				DoItemActionTry(() => usableItem.UseTry(_game.Character),
					SelectedItem,
					usableItem.UseVerbName().ToLower(),
					usableItem.UseNounName(),
				    GetNextItem());
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

		    var result = ItemTransferEntities();
		    var giver = result.Item1;
		    var receiver = result.Item2;

            DoItemActionTry(() => SelectedItem.TransferTry(giver, receiver),
		        SelectedItem,
		        "trade",
		        "Trading",
                GetNextItem());
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
			DoItemActionTry(() => SelectedItem.TrashTry(_game.Character),
				SelectedItem,
				"trash",
				"Trashing",
			    GetNextItem());
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
            if(inventoryEnemy.Visible)
                UpdateItemPanel();
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
					UpdateSellerPanel();
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
			if (!_game.Character.OwnsItem(SelectedItem))
			{
				SelectedItem = null;
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
					if (_game.Character.Health == _game.Character.MaxHealth)
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
			UpdateItemPanel();
		}
	}
}
