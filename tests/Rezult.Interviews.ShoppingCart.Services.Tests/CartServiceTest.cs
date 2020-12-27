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

        [SetUp]
        public void Setup()
        {
            _faker = new Faker();
            _cartService = new CartService();
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
    }
}