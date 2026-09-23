using ProductCatalogApi.Models;
using ProductCatalogApi.Storage;

namespace ProductCatalogApi.Services;

public class ProductService(ProductStore store) : IProductService
{
    public IReadOnlyList<Product> GetAll()
    {
        lock (store.SyncRoot)
        {
            return store.Products.Select(Clone).ToList();
        }
    }

    public Product GetById(int id)
    {
        lock (store.SyncRoot)
        {
            return Clone(FindProduct(id));
        }
    }

    public Product Create(ProductRequest request)
    {
        lock (store.SyncRoot)
        {
            var product = new Product
            {
                Id = store.Products.Count == 0 ? 1 : store.Products.Max(product => product.Id) + 1,
                Name = request.Name.Trim(),
                Description = request.Description.Trim(),
                Price = request.Price,
                Category = request.Category.Trim(),
                StockQuantity = request.StockQuantity
            };

            store.Products.Add(product);
            return Clone(product);
        }
    }

    public void Update(int id, ProductRequest request)
    {
        lock (store.SyncRoot)
        {
            var product = FindProduct(id);
            product.Name = request.Name.Trim();
            product.Description = request.Description.Trim();
            product.Price = request.Price;
            product.Category = request.Category.Trim();
            product.StockQuantity = request.StockQuantity;
        }
    }

    public void Delete(int id)
    {
        lock (store.SyncRoot)
        {
            store.Products.Remove(FindProduct(id));
        }
    }

    private Product FindProduct(int id) => store.Products.FirstOrDefault(product => product.Id == id)
        ?? throw new KeyNotFoundException($"Product with id {id} was not found.");

    private static Product Clone(Product product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Category = product.Category,
        StockQuantity = product.StockQuantity
    };
}
