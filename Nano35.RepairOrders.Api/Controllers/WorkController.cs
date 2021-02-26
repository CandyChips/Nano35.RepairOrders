using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano35.Contracts.repair.artifacts;
using Nano35.RepairOrders.Api.UseCases.CreateWorkRequest;

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
        
        public class CreateWorkHttpContext : 
            ICreateWorkRequestContract
        {
            public Guid Id { get; set; }
            public Guid CreatorId { get; set; }
            public Guid InstanceId { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
        
        [HttpPost]
        [Route("CreateWork")]
        public async Task<IActionResult> CreateWork(
            [FromBody] CreateWorkHttpContext query)
        {
            // Setup configuration of pipeline
            var bus = (IBus)_services.GetService(typeof(IBus));
            var logger = (ILogger<LoggedCreateWorkRequest>)_services.GetService(typeof(ILogger<LoggedCreateWorkRequest>));
            
            // Send request to pipeline
            var result =
                await new LoggedCreateWorkRequest(logger,
                    new ValidatedCreateWorkRequest(
                        new CreateWorkRequest(bus)
                    )).Ask(query);
            
            // Check response of get all instances request
            // You can check result by result contracts
            return result switch
            {
                ICreateWorkSuccessResultContract => Ok(),
                ICreateWorkErrorResultContract error => BadRequest(error.Message),
                _ => BadRequest()
            };
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