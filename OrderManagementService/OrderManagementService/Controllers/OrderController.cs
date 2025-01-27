using Microsoft.AspNetCore.Mvc;
using OrderManagementService.Application.Models;
using OrderManagementService.Infrastructure.RepositoryService;
using System;
using System.Threading.Tasks;

namespace OrderManagementService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryServiceClient _repositoryServiceClient;

        public OrderController(IRepositoryServiceClient repositoryServiceClient)
        {
            _repositoryServiceClient = repositoryServiceClient;
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
            return BadRequest();
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var order = await _repositoryServiceClient.GetOrderByIdAsync(id);
            return BadRequest(order);
        }
    }
}
