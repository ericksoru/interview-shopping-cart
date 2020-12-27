namespace Rezult.Interviews.ShoppingCart.Entities
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
    }
}