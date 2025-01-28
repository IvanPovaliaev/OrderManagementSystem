using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepositoryService.Application.Products.DTO;
using RepositoryService.Application.Products.Queries.GetAllProducts;
using RepositoryService.Application.Products.Queries.GetProductById;
using System;
using System.Threading.Tasks;

namespace RepositoryService.API.Controllers
{
    /// <summary>
    /// Controller for managing products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retrieves all products from the service.
        /// </summary>
        /// <returns>A collection of <see cref="ProductDTO"/> instances</returns>
        /// <response code="200">Returns the collection of products</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _sender.Send(new GetAllProductsQuery());

            return Ok(products);
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The <see cref="ProductDTO"/> instance if found, or <c>404 Not Found</c> if not found.</returns>
        /// <response code="200">Returns the requested product</response>
        /// <response code="404">If the product with the specified id is not found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            var product = await _sender.Send(query);

            return product is null ? NotFound() : Ok(product);
        }
    }
}
