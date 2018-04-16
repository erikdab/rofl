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
        public int InventorySize { get; protected set; }

        // Health Field
        private int _health;

        // Items Field
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Character Name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Character Level.
        /// </summary>
        public int Level { get; protected set; } = 1;

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
        public int MaxHealth { get; protected set; } = 100;

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

        public bool OwnsItem(Item item)
        {
            return Items.Contains(item);
        }

        /// <summary>
        /// Character's Money.
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="name">Character name.</param>
        /// <param name="inventorySize"></param>
        public Character(string name, int inventorySize = 16)
        {
            Health = MaxHealth;
            Name = name;
            InventorySize = inventorySize;
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
    }
}
