using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// A Game Item: there are various types
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        protected Random _random;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="random">Randomizer</param>
        public Item(Random random)
        {
            _random = random;
        }

        /// <summary>
        /// Unique Name used for identifying an Item.
        /// </summary>
        public string UniqueNameId => Name.Replace(" ", "_");

        /// <summary>
        /// Item Name.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Item Description.
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Can Trash Item.
        /// </summary>
        public bool CanTrash(IEntity entity)
        {
            return entity.Items.Contains(this);
        }

        /// <summary>
        /// Try to Trash Item.
        /// </summary>
        public void TrashTry(IEntity entity)
        {
            if (! CanTrash(entity))
            {
                throw new Exception($"{entity.Name} does not own {Name}, so they cannot trash it.");
            }

            entity.Items.Remove(this);
        }

        /// <summary>
        /// Try to Take Item from other entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fromOtherEntity"></param>
        public void TakeTry(IEntity entity, IEntity fromOtherEntity)
        {
            if (entity.InventorySize == entity.Items.Count)
            {
                throw new Exception($"{entity.Name} cannot take {Name}, they have no room in their inventory.");
            }
            entity.Items.Add(this);
            fromOtherEntity.Items.Remove(this);
        }
    }
}
