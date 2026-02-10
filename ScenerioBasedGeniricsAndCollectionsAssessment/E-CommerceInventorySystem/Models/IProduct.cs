using System.ComponentModel;

namespace ECommerceInventorySystem.Models
{
    public interface IProduct
    {
        int Id { get;  }
        string Name { get; }
        decimal Price { get; set; }
        Category Category { get; }
    }
}