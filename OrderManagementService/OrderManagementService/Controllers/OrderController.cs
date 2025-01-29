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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] NewOrderDTO order)
        {
            var isSuccess = await _ordersService.CreateAsync(order);
            return isSuccess ? Ok() : BadRequest();
        }

        [HttpPost("updateitems")]
        public async Task<IActionResult> UpdateItems([FromBody] UpdateOrderItemsDTO order)
        {
            var isSuccess = await _ordersService.UpdateItemsAsync(order);
            return isSuccess ? Ok() : BadRequest();
        }

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
