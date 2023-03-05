using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly StoreContext _context;
    public ProductsController(StoreContext context)
    {
      _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _context.Products.FindAsync(id); ;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
  }
}