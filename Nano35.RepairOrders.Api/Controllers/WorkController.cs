using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nano35.RepairOrders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController :
        ControllerBase
    {
        private readonly IServiceProvider _services;
        
        public WorkController(
            IServiceProvider services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("GetAllWorks")]
        public async Task<IActionResult> GetAllWorks()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("GetWorkById")]
        public async Task<IActionResult> GetWorkById()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("CreateWork")]
        public async Task<IActionResult> CreateWork()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateWorksName")]
        public async Task<IActionResult> UpdateWorksName()
        {
            return Ok();
        }
        
        [HttpPatch]
        [Route("UpdateWorksPrice")]
        public async Task<IActionResult> UpdateRepairOrdersPrice()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteWork")]
        public async Task<IActionResult> DeleteWork()
        {
            return Ok();
        }
    }
}