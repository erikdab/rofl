using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Trophy valued among Sellers.
    /// </summary>
    public class Trophy : Item, ITradeable
    {
        /// <summary>
        /// Cost at which Item may be sold.
        /// </summary>
        public int SellCost { get; protected set; }

        /// <summary>
        /// Cost at which Item may be bought.
        /// </summary>
        public int BuyCost { get; protected set; }
        /// <summary>
        /// Possible Trophy Types Count.
        /// </summary>
        private const int TrophTypeCount = 5;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Trophy(Random random) : base(random)
        {
            var number = _random.Next(TrophTypeCount);

            switch (number)
            {
                case 0:
                    Name = "Treasure Map";
                    Description = "A carefully etched, precise treasure map";
                    SellCost = 70;
                    break;
                case 1:
                    Name = "Ruby Necklace";
                    Description = "An abandoned, beautiful ruby necklace";
                    SellCost = 90;
                    break;
                case 2:
                    Name = "Gold Medal";
                    Description = "A dusty, but true gold medal";
                    SellCost = 110;
                    break;
                case 3:
                    Name = "Golden Mirror";
                    Description = "An dusty, but elaborate golden mirror";
                    SellCost = 130;
                    break;
                default:
                    Name = "Polished Diamond";
                    Description = "A big, polished diamond";
                    SellCost = 150;
                    break;
            }

            SellCost += _random.Next(20);
            BuyCost = SellCost + 50;

            Description += ". It must be worth a lot!";
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
