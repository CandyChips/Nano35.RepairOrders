using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.RepairOrders.Processor.Models;
using Nano35.RepairOrders.Processor.Services;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrdersWorkRequest
{
    public class CreateRepairOrderWorkRequest :
        IPipelineNode<
            ICreateRepairOrderWorkRequestContract,
            ICreateRepairOrderWorkResultContract>
    {
        private readonly ApplicationContext _context;

        public CreateRepairOrderWorkRequest(
            ApplicationContext context)
        {
            _context = context;
        }
        
        private class CreateRepairOrderWorkSuccessResultContract : 
            ICreateRepairOrderWorkSuccessResultContract
        {
            
        }
        
        public async Task<ICreateRepairOrderWorkResultContract> Ask(
            ICreateRepairOrderWorkRequestContract input,
            CancellationToken cancellationToken)
        {
            var repairOrderWork = new OrdersWork()
            {
                Id = input.Id,
                RepairOrderId = input.RepairOrderId,
                WorkId = input.WorkId,
                WorkerId = input.CreatorId,
                Comment = input.Comment,
                Price = input.Price,
                IsDeleted = false
            };

            await _context.OrdersWorks.AddAsync(repairOrderWork, cancellationToken);

            return new CreateRepairOrderWorkSuccessResultContract();
        }
    }
}