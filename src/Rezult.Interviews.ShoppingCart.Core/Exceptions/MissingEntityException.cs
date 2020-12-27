using System;

namespace Rezult.Interviews.ShoppingCart.Core.Exceptions
{
    public class MissingEntityException : Exception
    {
        public string Entity { get; }

        public MissingEntityException(string entity)
            : base($"Missing entity '{entity}'.")
        {
            Entity = entity;
        }
    }
}