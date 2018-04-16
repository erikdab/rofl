using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Health Potion used to heal.
    /// </summary>
    public class HealthPotion : Item, IUsable, ITradeable
    {
        /// <summary>
        /// Cost at which Item may be sold.
        /// </summary>
        public int SellCost { get; protected set; } = 35;

        /// <summary>
        /// Cost at which Item may be bought.
        /// </summary>
        public int BuyCost { get; protected set; } = 50;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public HealthPotion(Random random) : base(random)
        {
            Name = "Health Potion";
            Description = "A flask filled with a red fluid. It seems to emanate a refreshing aura.";
            HealingPower = 30 + _random.Next(20);
        }

        /// <summary>
        /// How much the Health Potion can heal.
        /// </summary>
        /// <returns></returns>
        public int HealingPower { get; protected set; }

        /// <summary>
        /// Short description of Action performed on Item use.
        /// </summary>
        /// <returns>string Textual description of Action</returns>
        public string UseDescription() => $"Drinking this {Name} will recover {HealingPower} Health.";

        /// <summary>
        /// Verb form of Action performed on Item use.
        /// </summary>
        /// <returns>string Noun form of Action</returns>
        public string UseVerbName() => "Drink";

        /// <summary>
        /// Noun form of Action performed on Item use.
        /// </summary>
        /// <returns>string Noun form of Action</returns>
        public string UseNounName() => "Drinking";

        /// <summary>
        /// Try to Use Item.
        /// </summary>
        /// <param name="entity">Entity to use item on.</param>
        public void UseTry(IEntity entity)
        {
            if (! CanUse(entity))
            {
                throw new Exception($"{entity.Name} does not own {Name}, so they cannot use it.");
            }
            if(entity.Health < entity.MaxHealth)
            {
                entity.Health += HealingPower;
                entity.Items.Remove(this);
            }
            else
            {
                throw new Exception($"{entity.Name} is fully healthy, so they cannot use {Name}.");
            }
        }

        /// <summary>
        /// Check if Item can be used by entity.
        /// </summary>
        /// <param name="entity">Entity to use item on.</param>
        public bool CanUse(IEntity entity)
        {
            return entity.Items.Contains(this);
        }

        /// <summary>
        /// Try to sell Item.
        /// </summary>
        public void SellTry(IEntity entity, IEntity toOtherEntity)
        {
            entity.Money += SellCost;
            entity.Items.Remove(this);
        }

        /// <summary>
        /// Try to buy Item.
        /// </summary>
        public void BuyTry(IEntity entity, IEntity fromOtherEntity)
        {
            if (entity.InventorySize == entity.Items.Count)
            {
                throw new Exception($"{entity.Name} cannot buy {Name}, they have no room in their inventory.");
            }
            if (entity.Money >= BuyCost)
            {
                entity.Money -= BuyCost;

                entity.Items.Add(this);
                fromOtherEntity.Items.Remove(this);
            }
            else
            {
                throw new Exception($"{entity.Name} cannot buy {Name}, they have insufficient funds.");
            }
        }
    }
}
