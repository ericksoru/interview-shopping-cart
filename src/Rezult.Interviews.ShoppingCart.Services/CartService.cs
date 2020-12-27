using System;
using System.Collections.Generic;
using Rezult.Interviews.ShoppingCart.Core.Services;
using Rezult.Interviews.ShoppingCart.Entities;

namespace Rezult.Interviews.ShoppingCart.Services
{
    public partial class CartService : ICartService
    {
        private readonly IList<Product> _products;

        public string UniqueIdentifier { get; } = new Guid().ToString("N").ToUpper();

        public CartService()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product) => throw new NotImplementedException();

        public Product DeleteProduct(int id) => throw new NotImplementedException();

        public bool ExistsProduct(int id) => throw new NotImplementedException();

        public bool ExistsProduct(Product product) => throw new NotImplementedException();

        public bool HasProducts() => _products.Count > 0;
    }
}