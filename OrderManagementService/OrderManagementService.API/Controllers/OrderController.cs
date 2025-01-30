using Microsoft.AspNetCore.Mvc;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.API.Controllers
{
    /// <summary>
    /// Controller for managing orders
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrderController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="order">The order data transfer object.</param>
        /// <returns>An HTTP response indicating success or failure.</returns>
        /// <response code="200">If the order was successfully created</response>
        /// <response code="400">If the request data is invalid.</response>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] NewOrderDTO order)
        {
            var isSuccess = await _ordersService.CreateAsync(order);
            return isSuccess ? Ok() : BadRequest();
        }

        /// <summary>
        /// Updates the items in an existing order.
        /// </summary>
        /// <param name="order">The order data transfer object with updated items</param>
        /// <returns>An HTTP response indicating success or failure.</returns>
        /// <response code="200">If the order items were successfully updated</response>
        /// <response code="400">If the request data is invalid</response>
        [HttpPost("updateitems")]
        public async Task<IActionResult> UpdateItems([FromBody] UpdateOrderItemsDTO order)
        {
            var isSuccess = await _ordersService.UpdateItemsAsync(order);
            return isSuccess ? Ok() : BadRequest();
        }

        /// <summary>
        /// Changes the status of an existing order.
        /// </summary>
        /// <param name="order">The order data transfer object with the new status</param>
        /// <returns>An HTTP response indicating success or failure</returns>
        /// <response code="200">If the order status was successfully changed</response>
        /// <response code="404">If the order does not exist</response>
        /// <response code="400">If the request data is invalid</response>
        [HttpPost("changeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeOrderStatusDTO order)
        {
            var isOrderExist = await _ordersService.IsExistAsync(order.Id);

            if (!isOrderExist)
            {
                return NotFound();
            }

            return await _ordersService.ChangeStatusAsync(order) ? Ok(order) : BadRequest();
        }

        /// <summary>
        /// Cancels an existing order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to cancel.</param>
        /// <returns>An HTTP response indicating success or failure</returns>
        /// <response code="200">If the order was successfully canceled</response>
        /// <response code="404">If the order does not exist</response>
        /// <response code="400">If the request data is invalid</response>
        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var isOrderExist = await _ordersService.IsExistAsync(id);

            if (!isOrderExist)
            {
                return NotFound();
            }

            return await _ordersService.CancelAsync(id) ? Ok(id) : BadRequest();
        }
    }
}
