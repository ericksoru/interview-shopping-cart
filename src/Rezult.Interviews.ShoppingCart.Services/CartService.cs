using System;
using System.Collections.Generic;
using Rezult.Interviews.ShoppingCart.Core.Exceptions;
using Rezult.Interviews.ShoppingCart.Core.Services;
using Rezult.Interviews.ShoppingCart.Entities;

namespace Rezult.Interviews.ShoppingCart.Services
{
    public partial class CartService : ICartService
    {
        //prop
        private readonly IList<Product> _products;

        //Sets the identifier
        public string UniqueIdentifier { get; } = Guid.NewGuid().ToString("N").ToUpper();

        //Constructor
        public CartService()
        {
            _products = new List<Product>();
            
        }

        public void AddProduct(Product product) //=> throw new NotImplementedException();
        {

            try
            {
                if (!product.Equals(null))
                    _products.Add(product);
            }

            catch (Exception ex)
            {

                throw new MissingEntityException("Product");
            }            
            
        }

        public Product DeleteProduct(int id)// => throw new NotImplementedException();
        {
            var finalProduct = new Product();

            if (_products.Count > 0)
            {
                foreach (var product in _products)
                {
                    if (product.Id == id)
                    {
                        
                        _products.Remove(product);
                        return product;
                    }

                }
                return finalProduct=null;
            }
            else
            {
                return finalProduct=null;
            }
            
        }

        public bool ExistsProduct(int id) //=> throw new NotImplementedException();
        {
            
            if (id > 0)
            {
                
                if ( _products.Count > 0)
                {
                    
                    foreach (var semiproduct in _products)
                    {
                        if (semiproduct.Id == id)
                            return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
                throw new InvalidInputException("Product", id);
        }

        public bool ExistsProduct(Product product)// => throw new NotImplementedException();
        {
            
            try
            {
                if (product.Id > 0 && !product.Equals(null))
                {
                    
                    if (_products.Count > 0)
                    {
                        foreach (var semiproduct in _products)
                        {
                            if (semiproduct == product)
                                return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    throw new InvalidInputException("Product", "22");
            }
            catch (Exception ex)
            {

                throw new InvalidInputException("Product", "22");
            }
            
            
            
        }

        public bool HasProducts() => _products.Count > 0;
    }
}