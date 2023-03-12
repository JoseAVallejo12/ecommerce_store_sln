using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Core.Interfaces;

namespace API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ProductsController : ControllerBase
  {
    private IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
      _repository = repository;
    }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _repository.GetProductsAsync();
      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _repository.GetProductByIdAsync(id);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<List<ProductBrand>>> GetBrands()
    {
      return Ok(await _repository.GetProductBrandsAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<List<ProductType>>> GetTypes()
    {
      return Ok(await _repository.GetProductTypesAsync());
    }
  }
}