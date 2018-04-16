using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    /// <summary>
    /// Generates Loot.
    /// </summary>
    public class LootGenerator
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private Random _random;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="random"></param>
        public LootGenerator(Random random)
        {
            _random = random;
        }

        /// <summary>
        /// Generate Randomized Loot.
        /// </summary>
        /// <param name="howMany">How many items to generate.</param>
        /// <param name="noJunk"></param>
        /// <returns>Array of Items</returns>
        public Item[] Generate(int howMany, bool noJunk = false)
        {
            var items = new Item[howMany];

            for (var i = 0; i < howMany; i++)
            {
                items[i] = SelectItem(_random.Next(100), noJunk);
            }

            return items;
        }

        /// <summary>
        /// Select given item.
        /// </summary>
        /// <param name="number">Item Number.</param>
        /// <returns>Selected Item.</returns>
        public Item SelectItem(int number, bool noJunk)
        {
            if (number < 40)
            {
                return new Junk(_random);
            }
            if (number < 65)
            {
                return new HealthPotion(_random);
            }

            if (number < 85)
            {
                return new ExperienceBooklet(_random);
            }

            if (number <= 100)
            {
                return new Trophy(_random);
            }

            throw new Exception("No such item exists.");
        }
    }
}
