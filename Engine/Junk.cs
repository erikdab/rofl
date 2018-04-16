using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Junk Items.
    /// </summary>
    public class Junk : Item
    {
        /// <summary>
        /// Possible Junk Types Count.
        /// </summary>
        private const int JunkTypeCount = 5;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Junk(Random random) : base(random)
        {
            var number = _random.Next(JunkTypeCount);

            switch (number)
            {
                case 0:
                    Name = "Rags";
                    Description = "Some dirty, ugly rags worn by monsters";
                    break;
                case 1:
                    Name = "Rotten Meat";
                    Description = "Some old, moldy, rotten meat";
                    break;
                case 2:
                    Name = "Broken Sword";
                    Description = "A rusty, broken sword";
                    break;
                case 3:
                    Name = "Faded Book";
                    Description = "A faded book";
                    break;
                default:
                    Name = "Empty Flask";
                    Description = "An empty, broken flask";
                    break;
            }

            Description += " with no apparent use.";
        }
    }
}
