using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepositoryService.Application.Models;
using RepositoryService.Application.Orders.Queries.GetAllOrders;
using RepositoryService.Application.Orders.Queries.GetOrderById;
using System;
using System.Threading.Tasks;

namespace RepositoryService.API.Controllers
{
    /// <summary>
    /// Controller for managing orders
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retrieves all orders from the service.
        /// </summary>
        /// <returns>A collection of <see cref="OrderDTO"/> instances</returns>
        /// <response code="200">Returns the collection of order</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _sender.Send(new GetAllOrdersQuery());

            return Ok(orders);
        }

        /// <summary>
        /// Retrieves a order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The <see cref="OrderDetailsDTO"/> instance if found, or <c>404 Not Found</c> if not found.</returns>
        /// <response code="200">Returns the requested order</response>
        /// <response code="404">If the order with the specified id is not found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetOrderByIdQuery() { Id = id };
            var order = await _sender.Send(query);

            return order is null ? NotFound() : Ok(order);
        }
    }
}
