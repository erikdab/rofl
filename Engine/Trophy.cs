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
        public int SellPrice { get; protected set; }

        /// <summary>
        /// Cost at which Item may be bought.
        /// </summary>
        public int BuyPrice { get; protected set; }

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
                    SellPrice = 70;
                    break;
                case 1:
                    Name = "Ruby Necklace";
                    Description = "An abandoned, beautiful ruby necklace";
                    SellPrice = 90;
                    break;
                case 2:
                    Name = "Gold Medal";
                    Description = "A dusty, but true gold medal";
                    SellPrice = 110;
                    break;
                case 3:
                    Name = "Golden Mirror";
                    Description = "An dusty, but elaborate golden mirror";
                    SellPrice = 130;
                    break;
                default:
                    Name = "Polished Diamond";
                    Description = "A big, polished diamond";
                    SellPrice = 150;
                    break;
            }

            SellPrice += _random.Next(20);
            BuyPrice = SellPrice + 50;

            Description += ". It must be worth a lot!";
        }
    }
}
