using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    /// <summary>
    /// A class modelling a Player's Game Character.
    /// </summary>
    public class Character : IEntity
    {
        /// <summary>
        /// Inventory Size.
        /// </summary>
        public int InventorySize { get; private set; }

        // Health Field
        private int _health;

        // Items Field
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Character Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Character Level.
        /// </summary>
        public int Level { get; private set; } = 1;

        /// <summary>
        /// Character current Health.
        /// </summary>
        public int Health
        {
            get => _health;
            set
            {
                if (value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else if (value < 0)
                {
                    _health = 0;
                }
                else
                {
                    _health = value;
                }
            }
        }
        /// <summary>
        /// Character maximum Health.
        /// </summary>
        public int MaxHealth { get; private set; } = 100;

        /// <summary>
        /// Character Experience - useful to gain new levels.
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Experience Cost to Level Up Character.
        /// </summary>
        public int LevelUpCost => Level * Level * 100;

        /// <summary>
        /// Remaining Experience Cost to Level Up Character.
        /// </summary>
        public int LevelUpRemainingCost => LevelUpCost > Experience ? LevelUpCost - Experience : 0;


        /// <summary>
        /// Character's Money.
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// Entity Type.
        /// </summary>
        public EntityType Type { get; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name">Character name.</param>
        /// <param name="type">Entity Type.</param>
        /// <param name="inventorySize">Inventory Size.</param>
        public Character(string name, EntityType type, int inventorySize = 16)
        {
            Health = MaxHealth;
            Name = name;
            InventorySize = inventorySize;
            Type = type;
        }

        /// <summary>
        /// Character items
        /// </summary>
        public List<Item> Items { get => _items;
            set
            {
                if (value.Count > InventorySize)
                {
                    throw new InventoryFullException();
                }

                _items = value;
            }
        }

        /// <summary>
        /// Try to Upgrade Character Level.
        /// Throws Exception if Character does not have enough experience.
        /// </summary>
        public void LevelUpTry()
        {
            if (Experience < LevelUpCost)
            {
                throw new InsufficientExperienceToLevelUpException();
            }

            // Remove experience needed for current level, but leave remainder
            Experience -= LevelUpCost;
            Level++;
            MaxHealth += 20;
        }

        /// <summary>
        /// Sort Items.
        /// </summary>
        public void SortItems()
        {
            Items = Items.OrderBy(o => o.Name).ToList();
        }

        /// <summary>
        /// Does Entity Own Item.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns></returns>
        public bool OwnsItem(Item item)
        {
            return item != null && Items.Contains(item);
        }
    }
}
