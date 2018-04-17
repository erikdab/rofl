using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    /// <summary>
    /// Possible Game Locations.
    /// </summary>
    public enum GameLocation
    {
        Village, Dungeon
    }

    /// <summary>
    /// Possible Room Types.
    /// </summary>
    public enum RoomType
    {
        Loot, Dragon, Trap, Empty
    }

    /// <summary>
    /// Possible Game GameEntity
    /// </summary>
    public enum GameEntity
    {
        Character, Seller, Enemy, None
    }

    /// <summary>
    /// Class holding the Game State.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        public Random  Random { get; protected set; } = new Random();

        /// <summary>
        /// Player Character.
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// Room Loot Character.
        /// </summary>
        public Character Enemy { get; set; } = new Character("Loot", 8);

        /// <summary>
        /// NPC Seller Character.
        /// </summary>
        public Character Seller { get; set; } = new Character("Store Seller", 64);

        /// <summary>
        /// Game Time Second
        /// </summary>
        private int _gameSecond;

        /// <summary>
        /// Game Time Minute
        /// </summary>
        private int _gameMinute;

        /// <summary>
        /// Game Time Hour
        /// </summary>
        private int _gameHour;

        /// <summary>
        /// Random Loot Generator.
        /// </summary>
        public LootGenerator LootGenerator { get; protected set; }

        /// <summary>
        /// Current Game Time.
        /// </summary>
        public string GameTime => $"{_gameHour}:{_gameMinute:00}:{_gameSecond:00}";

        /// <summary>
        /// Current Game Location.
        /// </summary>
        public GameLocation GameLocation { get; protected set; } = GameLocation.Village;

        /// <summary>
        /// Current Dungeon Level
        /// </summary>
        public int DungeonLevel { get; set; }

        /// <summary>
        /// Rooms Opened in Current Dungeon
        /// </summary>
        public int OpenedRooms { get; set; }

        /// <summary>
        /// Can Travel Lower into the Dungeon.
        /// </summary>
        /// <returns></returns>
        public bool CanTravelDown() => OpenedRooms >= 5 * (DungeonLevel + 1);

        /// <summary>
        /// Check if there are more rooms on the current floor.
        /// </summary>
        /// <returns></returns>
        public bool CanOpenRoom() => OpenedRooms < 5 * (DungeonLevel + 1);

        /// <summary>
        /// Current Room Type.
        /// </summary>
        public RoomType RoomType { get; protected set; }

        /// <summary>
        /// Room Description.
        /// </summary>
        /// <returns></returns>
        public string RoomDescription { get; protected set; }

        /// <summary>
        /// Experience Gained in Room.
        /// </summary>
        public int ExperienceGained { get; protected set; }

        /// <summary>
        /// Has the Game Goal been Achieved yet.
        /// </summary>
        public bool GoalAchieved { get; protected set; }

        /// <summary>
        /// Constructor with Character.
        /// </summary>
        /// <param name="character">Player Character</param>        
        public Game(Character character)
        {
            Character = character;

            LootGenerator = new LootGenerator(Random);
            // Character starting items:
            // Character.Items.AddRange(LootGenerator.GenerateInRange(3, 5, true));
            Character.Items.AddRange(LootGenerator.Generate(16, true));
            StockSellerInventory();
        }

        /// <summary>
        /// Get the item owner.
        /// </summary>
        /// <param name="entityEnum">Item to search owner of</param>
        /// <returns>Owner</returns>
        public IEntity GetEntity(GameEntity entityEnum)
        {
            switch (entityEnum)
            {
                case GameEntity.Character:
                    return Character;
                case GameEntity.Seller:
                    return Seller;
                case GameEntity.Enemy:
                    return Enemy;
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityEnum), entityEnum, null);
            }
        }

        /// <summary>
        /// Get the item owner's name.
        /// </summary>
        /// <param name="item">Item to search owner of</param>
        /// <returns>Owner Name</returns>
        public GameEntity GetItemOwnerEnum(Item item)
        {
            if (Character.OwnsItem(item))
            {
                return GameEntity.Character;
            }

            if (Seller.OwnsItem(item))
            {
                return GameEntity.Seller;
            }

            if (Enemy.OwnsItem(item))
            {
                return GameEntity.Enemy;
            }

            throw new Exception($"No one owns this item: {item.Name}!");
        }

        /// <summary>
        /// Change Game Location and reset anything needed.
        /// </summary>
        /// <param name="gameLocation"></param>
        public void ChangeLocation(GameLocation gameLocation)
        {
            if (GameLocation == gameLocation) return;

            GameLocation = gameLocation;
            OpenedRooms = 0;
            DungeonLevel = 0;
            StockSellerInventory();
        }

        /// <summary>
        /// Open New Room.
        /// </summary>
        public void OpenRoom()
        {
            if (!CanOpenRoom()) return;

            OpenedRooms++;

            // Choose Room Type.
            var number = Random.Next(100);
            if (number < 40)
            {
                if (number < 10 && DungeonLevel >= 5)
                {
                    RoomType = RoomType.Dragon;
                }
                else
                {
                    RoomType = RoomType.Loot;
                }
            }
            else if (number < 90)
            {
                RoomType = RoomType.Trap;
            }
            else
            {
                RoomType = RoomType.Empty;
            }

            Enemy = new Character("Loot", 8);

            switch (RoomType)
            {
                case RoomType.Loot:
                    Enemy.Money = Random.Next(30, 60);
                    var lootItems = LootGenerator.Generate(Random.Next(Enemy.InventorySize));
                    Enemy.Items = lootItems.ToList();
                    RoomDescription = "Loot! Lucky :). Take anything you want, as long as you have space for it or need of it!";
                    ExperienceGained = Random.Next(15, 30) * DungeonLevel;
                    break;
                case RoomType.Trap:
                    var healthLost = Random.Next((int)Math.Floor((double)Character.MaxHealth / 5)) + (5 * DungeonLevel);
                    if (Character.Health - healthLost <= 0)
                    {
                        Character.Money = Character.Money - healthLost < 0 ? 0 : Character.Money - healthLost;
                        Character.Health = Character.MaxHealth;
                        ChangeLocation(GameLocation.Village);

                        throw new Exception($"You Fainted in the Dungeon! Thankfully, another Adventurer saved you, at the small cost of {healthLost}");
                    }
                    Character.Health -= healthLost;
                    RoomDescription = $"a Trap! Ouch! Be wary of these dungeons, Hero, they can be treacherous! You Lost {healthLost} Health!";
                    ExperienceGained = Random.Next(25, 40) * DungeonLevel;
                    break;
                case RoomType.Dragon:
                    GoalAchieved = true;
                    RoomDescription = "You found the Dragon!";
                    ChangeLocation(GameLocation.Village);
                    return;
                case RoomType.Empty:
                    RoomDescription = "an Empty Space... Sorry! Hopefully you will find more in the next room!";
                    ExperienceGained = Random.Next(5, 15) * DungeonLevel;
                    break;
            }

            Character.Experience += ExperienceGained;
        }

        /// <summary>
        /// Setup Store.
        /// </summary>
        public void StockSellerInventory()
        {
            Seller.Items = LootGenerator.Generate(Seller.InventorySize, true);
        }

        /// <summary>
        /// Actions to perform each game second.
        /// </summary>
        public void UpdateTime()
        {
            _gameSecond++;
            if (_gameSecond == 60)
            {
                _gameSecond = 0;
                _gameMinute++;
            }
            if (_gameMinute == 60)
            {
                _gameMinute = 0;
                _gameHour++;
            }
            // Oh well, if you're playing this long, restart counting.
            if (_gameHour == 24)
            {
                _gameHour = 0;
            }
        }
    }
}
