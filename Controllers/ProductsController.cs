using Microsoft.AspNetCore.Mvc;
using ProductCatalogApi.Models;
using ProductCatalogApi.Services;

namespace ProductCatalogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyList<Product>> GetAll() => Ok(productService.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id) => Ok(productService.GetById(id));

    [HttpPost]
    public ActionResult<Product> Create(ProductRequest request)
    {
        var product = productService.Create(request);
        return CreatedAtAction(nameof(GetById), new { product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, ProductRequest request)
    {
        productService.Update(id, request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        productService.Delete(id);
        return NoContent();
    }
}
