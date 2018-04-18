using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Item Transfer Types
    /// </summary>
    public enum TransferType
    {
        Give, Take, Buy, Sell, None
    }

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
        /// Try to Take Item from other giver.
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

        public TransferType TransferTypeFromTo(IEntity giver, IEntity receiver)
        {
            if (giver == null || receiver == null)
            {
                return TransferType.None;
            }
            if (giver.Type == EntityType.Character && receiver.Type == EntityType.Seller)
            {
                return TransferType.Sell;
            }
            if (giver.Type == EntityType.Seller && receiver.Type == EntityType.Character)
            {
                return TransferType.Buy;
            }
            if (giver.Type == EntityType.Character && receiver.Type == EntityType.Enemy)
            {
                return TransferType.Give;
            }
            if (giver.Type == EntityType.Enemy && receiver.Type == EntityType.Character)
            {
                return TransferType.Take;
            }

            return TransferType.None;
        }

        /// <summary>
        /// Trade Price of item for given transfer type.
        /// </summary>
        /// <param name="tradeableItem">Item to trade</param>
        /// <param name="type">Transfer type</param>
        /// <returns>Trade Price</returns>
        public decimal TradePrice(ITradeable tradeableItem, TransferType type)
        {
            return type == TransferType.Buy ? tradeableItem.BuyPrice : tradeableItem.SellPrice;
        }

        /// <summary>
        /// Try to transfer Item.
        /// </summary>
        public void TransferTry(IEntity giver, IEntity receiver)
        {
            var type = TransferTypeFromTo(giver, receiver);

            var tradeableItem = this as ITradeable;
            if (tradeableItem == null &&
                (type == TransferType.Buy || type == TransferType.Sell))
            {
                throw new Exception($"{Name} is not tradeable!");
            }

            // Receiver inventory is full
            if (receiver.InventorySize == receiver.Items.Count)
            {
                throw new Exception($"{giver.Name} cannot {type} {Name}, {receiver.Name} inventory is full.");
            }

            // Only Player pays or receives money
            if (tradeableItem != null && type == TransferType.Sell || type == TransferType.Buy)
            {
                var price = TradePrice(tradeableItem, type);
                if (receiver.Money < price)
                {
                    var message = receiver.Type == EntityType.Seller ? " Come back later." : "";
                    throw new Exception($"{giver.Name} cannot {type} {Name}, {receiver.Name} has insufficient funds.{message}");
                }
                giver.Money += price;
                receiver.Money -= price;
            }
            giver.Items.Remove(this);
            receiver.Items.Add(this);
        }
    }
}
