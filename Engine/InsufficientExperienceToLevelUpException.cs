using System;
using System.Runtime.Serialization;

namespace Engine
{
    /// <summary>
    /// Exception thrown when a Character has insufficient experience to upgrade to the next level.
    /// </summary>
    [Serializable]
    public class InsufficientExperienceToLevelUpException : Exception
    {
        public InsufficientExperienceToLevelUpException()
        {
        }

        public InsufficientExperienceToLevelUpException(string message) : base(message)
        {
        }

        public InsufficientExperienceToLevelUpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientExperienceToLevelUpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}