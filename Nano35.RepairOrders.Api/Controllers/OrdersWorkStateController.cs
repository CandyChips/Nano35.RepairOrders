using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nano35.RepairOrders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersWorkStateController :
        ControllerBase
    {
        private readonly IServiceProvider _services;
        
        public OrdersWorkStateController(
            IServiceProvider services)
        {
            _services = services;
        }
        
        [HttpGet]
        [Route("GetAllOrderWorkStates")]
        public async Task<IActionResult> GetAllOrderWorkStates()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("GetOrderWorkStateById")]
        public async Task<IActionResult> GetOrderWorkStateById()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("CreateOrderWorkState")]
        public async Task<IActionResult> CreateOrderWorkState()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateOrderWorkStatesCommentId")]
        public async Task<IActionResult> UpdateOrderWorkStatesCommentId()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateOrderWorkStatesTypeId")]
        public async Task<IActionResult> UpdateOrderWorkStatesTypeId()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateOrderWorkStatesDateId")]
        public async Task<IActionResult> UpdateOrderWorkStatesDateId()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrderWorkState")]
        public async Task<IActionResult> DeleteOrderWorkState()
        {
            return Ok();
        }
    }
}