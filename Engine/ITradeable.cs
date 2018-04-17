using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Is Item Tradeable.
    /// </summary>
    public interface ITradeable
    {
        /// <summary>
        /// Cost at which Item may be sold.
        /// </summary>
        int SellPrice { get; }

        /// <summary>
        /// Cost at which Item may be bought.
        /// </summary>
        int BuyPrice { get; }

        /// <summary>
        /// Try to sell Item.
        /// </summary>
        void SellTry(IEntity entity, IEntity toOtherEntity);

        /// <summary>
        /// Try to buy Item.
        /// </summary>
        void BuyTry(IEntity entity, IEntity fromOtherEntity);
    }
}
