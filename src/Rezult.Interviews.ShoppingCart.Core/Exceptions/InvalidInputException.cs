using System;

namespace Rezult.Interviews.ShoppingCart.Core.Exceptions
{
    public class InvalidInputException : Exception
    {
        public string Entity { get; }
        public string Identifier { get; }

        public InvalidInputException(string entity, string identifier)
            : base($"Invalid input for '{entity}' with identifier '{identifier}'.")
        {
            Entity = entity;
            Identifier = identifier;
        }

        public InvalidInputException(string entity, int identifier)
            : this(entity, identifier.ToString())
        {
        }
    }
}