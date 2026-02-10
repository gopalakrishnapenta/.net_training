namespace ECommerceInventorySystem.Models
{
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string? Brand { get; set; }

    }
}