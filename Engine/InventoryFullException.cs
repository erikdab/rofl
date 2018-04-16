using System;
using System.Runtime.Serialization;

namespace Engine
{
    /// <summary>
    /// Exception thrown when inventory is full.
    /// </summary>
    [Serializable]
    internal class InventoryFullException : Exception
    {
        public InventoryFullException()
        {
        }

        public InventoryFullException(string message) : base(message)
        {
        }

        public InventoryFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InventoryFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}