using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Experience Booklet used to increase wisdom.
    /// </summary>
    public class ExperienceBooklet : Item, IUsable, ITradeable
    {
        /// <summary>
        /// Cost at which Item may be sold.
        /// </summary>
        public int SellCost { get; protected set; } = 40;

        /// <summary>
        /// Cost at which Item may be bought.
        /// </summary>
        public int BuyCost { get; protected set; } = 60;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ExperienceBooklet(Random random) : base(random)
        {
            Name = "Experience Booklet";
            Description = "A booklet filled with many words. It appears to contain beneficial wisdom.";
            Power = 20 + _random.Next(20);
        }

        /// <summary>
        /// How much the Health Potion can heal.
        /// </summary>
        /// <returns></returns>
        public int Power { get; protected set; }

        /// <summary>
        /// Short description of Action performed on Item use.
        /// </summary>
        /// <returns>string Textual description of Action</returns>
        public string UseDescription() => $"Reading this {Name} will increase Experience by {Power}.";

        /// <summary>
        /// Verb form of Action performed on Item use.
        /// </summary>
        /// <returns>string Noun form of Action</returns>
        public string UseVerbName() => "Read";

        /// <summary>
        /// Noun form of Action performed on Item use.
        /// </summary>
        /// <returns>string Noun form of Action</returns>
        public string UseNounName() => "Reading";

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
            entity.Experience += Power;
            entity.Items.Remove(this);
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
