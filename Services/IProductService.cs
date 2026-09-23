using ProductCatalogApi.Models;

namespace ProductCatalogApi.Services;

public interface IProductService
{
    IReadOnlyList<Product> GetAll();
    Product GetById(int id);
    Product Create(ProductRequest request);
    void Update(int id, ProductRequest request);
    void Delete(int id);
}
