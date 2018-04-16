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
        /// Generate Randomized Loot in number up to maximum.
        /// </summary>
        /// <param name="maximum">Maximum number of items to generate</param>
        /// <param name="noJunk">Whether to generate junk items</param>
        /// <returns>Item List</returns>
        public List<Item> GenerateUpTo(int maximum, bool noJunk = false)
        {
            var howMany = _random.Next(maximum);

            return Generate(howMany, noJunk);
        }

        /// <summary>
        /// Generate Randomized Loot in number between minimum and maximum.
        /// </summary>
        /// <param name="minimum">Minimum number of items to generate</param>
        /// <param name="maximum">Maximum number of items to generate</param>
        /// <param name="noJunk">Whether to generate junk items</param>
        /// <returns>Item List</returns>
        public List<Item> GenerateInRange(int minimum, int maximum, bool noJunk = false)
        {
            var howMany = _random.Next(minimum, maximum);

            return Generate(howMany, noJunk);
        }

        /// <summary>
        /// Generate Randomized Loot in exact number.
        /// </summary>
        /// <param name="howMany">Number of items to generate.</param>
        /// <param name="noJunk">Whether to generate junk items</param>
        /// <returns>Item List</returns>
        public List<Item> Generate(int howMany, bool noJunk = false)
        {
            var items = new List<Item>(howMany);

            var startFrom = noJunk ? 40 : 0;

            for (var i = 0; i < howMany; i++)
            {
                items.Add(SelectItem(_random.Next(startFrom, 100)));
            }

            return items;
        }

        /// <summary>
        /// Item Selector from possible items.
        /// </summary>
        /// <param name="number">Number between 0 and 100 - used to select item</param>
        /// <returns>Item</returns>
        public Item SelectItem(int number)
        {
            if (number >= 0 && number < 40)
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

            throw new ArgumentOutOfRangeException("LootGenerator: Item Number out of range!");
        }
    }
}
