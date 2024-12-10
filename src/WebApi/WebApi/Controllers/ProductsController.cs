using AppServices.Products.Services;
using AppServices.Users.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Пользователи.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Получить данные о товарах.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Список товаров.</returns>
        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetAllProductsAsync(CancellationToken token)
        {
            var users = await _productService.GetAllAsync(token);
            return Ok(users);        
        }
    }
}