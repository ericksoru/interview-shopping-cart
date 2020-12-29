using System;
using Bogus;
using NUnit.Framework;
using Rezult.Interviews.ShoppingCart.Core.Exceptions;
using Rezult.Interviews.ShoppingCart.Core.Services;
using Rezult.Interviews.ShoppingCart.Entities;
using Rezult.Interviews.ShoppingCart.Services.Tests.Extensions;

namespace Rezult.Interviews.ShoppingCart.Services.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CartServiceTest
    {
        private ICartService _cartService;
        private Faker _faker;
        private Product _testProduct;
        private int IdProduct = 0;

        [SetUp]
        public void Setup()
        {
            _faker = new Faker();
            _cartService = new CartService();
            _testProduct = new Product();
            
        }

        [Test]
        public void WhenInitCart_UniqueIdentifier_IsGuid()
        {
            bool success = Guid.TryParse(_cartService.UniqueIdentifier, out Guid result);            
            Assert.That(success, Is.True);            
            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void WhenAdd_NullProduct_ShouldThrowException()
        {
            MissingEntityException exception = Assert.Throws<MissingEntityException>(() => _cartService.AddProduct(null));
            
            Assert.That(exception.Entity, Is.EqualTo(nameof(Product)));
        }
        
        [Test]
        public void WhenAdd_NormalProduct_ShouldAdd()
        {
            Product product = _faker.GenerateProduct();
            
            bool hasItems = _cartService.HasProducts();
            
            Assert.That(hasItems, Is.False);

            _cartService.AddProduct(product);

            hasItems = _cartService.HasProducts();
            Assert.That(hasItems, Is.True);
        }
        [Test]
        public void WhenDelete_ExistingProduct_ProductNull()
        {
            Product product = _faker.GenerateProduct();
            var deletedProduct = new Product();
            
            _cartService.AddProduct(product);

            deletedProduct = _cartService.DeleteProduct(10);
            Assert.IsNull(deletedProduct);

            deletedProduct = _cartService.DeleteProduct(product.Id);
            Assert.IsNotNull(deletedProduct);


        }
        [Test]
        public void WhenSearch_ProductThatExistOrNot_ReturnTrueOrFalse()
        {
            Product product = _faker.GenerateProduct();
            var badId = 4;
            
            _cartService.AddProduct(product);
            
            bool productExist = _cartService.ExistsProduct(product.Id);            
            Assert.That(productExist,Is.True);
            

            productExist = _cartService.ExistsProduct(product);            
            Assert.That(productExist, Is.True);

            productExist = _cartService.ExistsProduct(badId);
            Assert.That(productExist, Is.False);

            product= _faker.GenerateProduct();
            productExist = _cartService.ExistsProduct(product);
            Assert.That(productExist, Is.False);

            InvalidInputException exception = Assert.Throws<InvalidInputException>(() => _cartService.ExistsProduct(-1));            
            Assert.That(exception.Entity, Is.EqualTo(nameof(Product)));
            Console.WriteLine("Final");

            exception = Assert.Throws<InvalidInputException>(() => _cartService.ExistsProduct(null));
            Assert.That(exception.Entity, Is.EqualTo(nameof(Product)));

        }
        
    }
}