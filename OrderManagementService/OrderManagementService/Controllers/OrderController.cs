using Microsoft.AspNetCore.Mvc;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.API.Controllers
{
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
        public async Task<IActionResult> Create([FromBody] CreateOrderDTO order)
        {
            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDTO order)
        {
            return BadRequest();
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

        [HttpPost("cancel")]
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
