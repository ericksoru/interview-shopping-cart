using Bogus;
using Rezult.Interviews.ShoppingCart.Entities;

namespace Rezult.Interviews.ShoppingCart.Services.Tests.Extensions
{
    public static class ProductExtensions
    {
        public static Product GenerateProduct(this Faker faker)
        {
            Product product = new Faker<Product>()
                .RuleFor(t => t.Category, f => f.PickRandom<Category>())
                .RuleFor(t => t.Discount, f => f.PickRandom<double?>(null, (double?)f.Random.Double(min: 1, max: 20)))
                .RuleFor(t => t.Id, f => f.Random.Int(min: 1))
                .RuleFor(t => t.Name, f => f.Commerce.Product())
                .RuleFor(t => t.Price, f => f.Random.Double(min: 100, max: 5000))
                .Generate();

            return product;
        }
    }
}
