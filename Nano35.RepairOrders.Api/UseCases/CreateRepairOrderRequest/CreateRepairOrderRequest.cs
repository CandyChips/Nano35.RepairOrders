using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Api.UseCases.CreateRepairOrderRequest
{
    public class CreateRepairOrderRequest :
        IPipelineNode<
            ICreateRepairOrderRequestContract,
            ICreateRepairOrderResultContract>
    {
        private readonly IBus _bus;
        public CreateRepairOrderRequest(
            IBus bus)
        {
            _bus = bus;
        }
        
        public async Task<ICreateRepairOrderResultContract> Ask(
            ICreateRepairOrderRequestContract input)
        {
            var client = _bus.CreateRequestClient<ICreateRepairOrderRequestContract>(TimeSpan.FromSeconds(10));
            
            var response = await client
                .GetResponse<ICreateRepairOrderSuccessResultContract, ICreateRepairOrderErrorResultContract>(input);
            
            if (response.Is(out Response<ICreateRepairOrderSuccessResultContract> successResponse))
                return successResponse.Message;
            
            if (response.Is(out Response<ICreateRepairOrderErrorResultContract> errorResponse))
                return errorResponse.Message;
            
            throw new InvalidOperationException();
        }
    }
}