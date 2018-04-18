using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Possible Game EntityType
    /// </summary>
    public enum EntityType
    {
        Character, Seller, Enemy, None
    }

    /// <summary>
    /// Base Entity interface.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Entity Level.
        /// </summary>
        int Level { get; }

        /// <summary>
        /// Entity Experience.
        /// </summary>
        int Experience { get; set; }

        /// <summary>
        /// Entity current Health.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Entity maximum Health.
        /// </summary>
        int MaxHealth { get; }

        /// <summary>
        /// Inventory Size.
        /// </summary>
        int InventorySize { get; }

        /// <summary>
        /// Entity Items.
        /// </summary>
        List<Item> Items { get; set; }

        /// <summary>
        /// Check if Entity owns item.
        /// </summary>
        bool OwnsItem(Item item);

        /// <summary>
        /// Entity Money.
        /// </summary>
        decimal Money { get; set; }

        /// <summary>
        /// Entity Type.
        /// </summary>
        EntityType Type { get; }
    }
}
