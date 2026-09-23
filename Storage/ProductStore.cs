using ProductCatalogApi.Models;

namespace ProductCatalogApi.Storage;

public class ProductStore
{
    public object SyncRoot { get; } = new();

    public List<Product> Products { get; } =
    [
        new Product
        {
            Id = 1,
            Name = "Wireless Headphones",
            Description = "Noise-cancelling Bluetooth headphones.",
            Price = 79.99m,
            Category = "Electronics",
            StockQuantity = 25
        },
        new Product
        {
            Id = 2,
            Name = "Travel Mug",
            Description = "Insulated stainless-steel mug.",
            Price = 18.50m,
            Category = "Home",
            StockQuantity = 40
        }
    ];
}
