using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.RepairOrders.Processor.Models;
using Nano35.RepairOrders.Processor.Services;

namespace Nano35.RepairOrders.Processor.UseCases.CreateWorkRequest
{
    public class CreateWorkRequest :
        IPipelineNode<
            ICreateWorkRequestContract,
            ICreateWorkResultContract>
    {
        private readonly ApplicationContext _context;

        public CreateWorkRequest(
            ApplicationContext context)
        {
            _context = context;
        }
        
        private class CreateWorkSuccessResultContract : 
            ICreateWorkSuccessResultContract
        {
            
        }
        
        public async Task<ICreateWorkResultContract> Ask(
            ICreateWorkRequestContract input,
            CancellationToken cancellationToken)
        {
            var work = new Work()
            {
                Id = input.Id,
                InstanceId = input.InstanceId,
                Name = input.Name,
                Price = input.Price,
                IsDeleted = false
            };

            await _context.Works.AddAsync(work, cancellationToken);
            
            return new CreateWorkSuccessResultContract();
        }
    }
}