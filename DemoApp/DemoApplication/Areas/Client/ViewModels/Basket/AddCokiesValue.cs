namespace DemoApplication.Areas.Client.ViewModels.Basket
{
    public class AddCokiesValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public AddCokiesValue(int id, string name, string imageUrl, int count, decimal price, decimal total)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Count = count;
            Price = price;
            Total = total;
        }
    }
}
