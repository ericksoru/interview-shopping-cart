using Rezult.Interviews.ShoppingCart.Entities;

namespace Rezult.Interviews.ShoppingCart.Core.Services
{
    public interface ICartService
    {
        string UniqueIdentifier { get; }

        void AddProduct(Product product);
        Product DeleteProduct(int id);
        bool ExistsProduct(int id);
        bool ExistsProduct(Product product);

        bool HasProducts();
    }
}