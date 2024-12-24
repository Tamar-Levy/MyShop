using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsService _productsService;
        IMapper _mapper;

        public ProductsController(IProductsService productsService,IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<List<ProductDTO>> Get([FromQuery] int position, [FromQuery] int skip, [FromQuery] string? name, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await _productsService.GetProducts(position,skip, name, minPrice,maxPrice,categoryIds);

            return _mapper.Map<List<Product>, List<ProductDTO>>(products);
        }
    }
}
