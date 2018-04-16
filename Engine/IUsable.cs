using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// A Usable Item.
    /// </summary>
    public interface IUsable
    {
        /// <summary>
        /// Verb form of Action performed on Item use.
        /// </summary>
        /// <returns>string Noun form of Action</returns>
        string UseVerbName();

        /// <summary>
        /// Noun form of Action performed on Item use.
        /// </summary>
        /// <returns>string Noun form of Action</returns>
        string UseNounName();

        /// <summary>
        /// Short description of Action performed on Item use.
        /// </summary>
        /// <returns>string Textual description of Action</returns>
        string UseDescription();

        /// <summary>
        /// Try to Use Item.
        /// </summary>
        /// <param name="entity">Entity to use item on.</param>
        void UseTry(IEntity entity);

        /// <summary>
        /// Check if Item can be used by entity.
        /// </summary>
        /// <param name="entity">Entity to use item on.</param>
        bool CanUse(IEntity entity);
    }
}
