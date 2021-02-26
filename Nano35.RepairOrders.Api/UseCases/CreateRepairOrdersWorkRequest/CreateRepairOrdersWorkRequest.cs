using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Api.UseCases.CreateRepairOrdersWorkRequest
{
    public class CreateRepairOrderWorkRequest :
        IPipelineNode<
            ICreateRepairOrderWorkRequestContract,
            ICreateRepairOrderWorkResultContract>
    {
        private readonly IBus _bus;
        public CreateRepairOrderWorkRequest(
            IBus bus)
        {
            _bus = bus;
        }
        
        public async Task<ICreateRepairOrderWorkResultContract> Ask(
            ICreateRepairOrderWorkRequestContract input)
        {
            var client = _bus.CreateRequestClient<ICreateRepairOrderWorkRequestContract>(TimeSpan.FromSeconds(10));
            
            var response = await client
                .GetResponse<ICreateRepairOrderWorkSuccessResultContract, ICreateRepairOrderWorkErrorResultContract>(input);
            
            if (response.Is(out Response<ICreateRepairOrderWorkSuccessResultContract> successResponse))
                return successResponse.Message;
            
            if (response.Is(out Response<ICreateRepairOrderWorkErrorResultContract> errorResponse))
                return errorResponse.Message;
            
            throw new InvalidOperationException();
        }
    }
}