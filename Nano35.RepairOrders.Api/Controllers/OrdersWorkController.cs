using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nano35.RepairOrders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersWorkController :
        ControllerBase
    {
        private readonly IServiceProvider _services;
        
        public OrdersWorkController(
            IServiceProvider services)
        {
            _services = services;
        }
        
        [HttpGet]
        [Route("GetAllOrderWorks")]
        public async Task<IActionResult> GetAllWorks()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("GetOrderWorkById")]
        public async Task<IActionResult> GetWorkById()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("CreateOrderWork")]
        public async Task<IActionResult> CreateOrderWork()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateOrderWorksWorkId")]
        public async Task<IActionResult> UpdateOrderWorksWorkId()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateOrderWorksComment")]
        public async Task<IActionResult> UpdateOrderWorksComment()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateOrderWorksPrice")]
        public async Task<IActionResult> UpdateOrderWorksPrice()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrderWork")]
        public async Task<IActionResult> DeleteOrderWork()
        {
            return Ok();
        }
    }
}