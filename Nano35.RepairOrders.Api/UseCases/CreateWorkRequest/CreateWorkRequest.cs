using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Api.UseCases.CreateWorkRequest
{
    public class CreateWorkRequest :
        IPipelineNode<
            ICreateWorkRequestContract,
            ICreateWorkResultContract>
    {
        private readonly IBus _bus;
        public CreateWorkRequest(
            IBus bus)
        {
            _bus = bus;
        }
        
        public async Task<ICreateWorkResultContract> Ask(
            ICreateWorkRequestContract input)
        {
            var client = _bus.CreateRequestClient<ICreateWorkRequestContract>(TimeSpan.FromSeconds(10));
            
            var response = await client
                .GetResponse<ICreateWorkSuccessResultContract, ICreateWorkErrorResultContract>(input);
            
            if (response.Is(out Response<ICreateWorkSuccessResultContract> successResponse))
                return successResponse.Message;
            
            if (response.Is(out Response<ICreateWorkErrorResultContract> errorResponse))
                return errorResponse.Message;
            
            throw new InvalidOperationException();
        }
    }
}