using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nano35.RepairOrders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepairOrderController :
        ControllerBase
    {
        private readonly IServiceProvider _services;
        
        public RepairOrderController(
            IServiceProvider services)
        {
            _services = services;
        }
        
        [HttpGet]
        [Route("GetAllRepairOrders")]
        public async Task<IActionResult> GetAllRepairOrders()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("GetRepairOrderById")]
        public async Task<IActionResult> GetRepairOrderById()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("CreateRepairOrder")]
        public async Task<IActionResult> CreateRepairOrder()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersClient")]
        public async Task<IActionResult> UpdateRepairOrdersClient()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersManager")]
        public async Task<IActionResult> UpdateRepairOrdersManager()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersArticle")]
        public async Task<IActionResult> UpdateRepairOrdersArticle()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersSerial")]
        public async Task<IActionResult> UpdateRepairOrdersSerial()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersCondition")]
        public async Task<IActionResult> UpdateRepairOrdersCondition()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersTrouble")]
        public async Task<IActionResult> UpdateRepairOrdersTrouble()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateRepairOrdersComplication")]
        public async Task<IActionResult> UpdateRepairOrdersComplication()
        {
            return Ok();
        }
    }
}