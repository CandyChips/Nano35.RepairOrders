using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.Contracts.Storage.Artifacts;
using Nano35.RepairOrders.Processor.Models;
using Nano35.RepairOrders.Processor.Services;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrderRequest
{
    public class CreateRepairOrderRequest :
        IPipelineNode<
            ICreateRepairOrderRequestContract,
            ICreateRepairOrderResultContract>
    {
        private readonly ApplicationContext _context;

        public CreateRepairOrderRequest(
            ApplicationContext context)
        {
            _context = context;
        }
        
        private class CreateRepairOrderSuccessResultContract : 
            ICreateRepairOrderSuccessResultContract
        {
            
        }
        
        public async Task<ICreateRepairOrderResultContract> Ask(
            ICreateRepairOrderRequestContract input,
            CancellationToken cancellationToken)
        {
            var repairOrder = new RepairOrder()
            {
                Id = input.Id,
                ClientId = input.ClientId,
                ManagerId = input.CreatorId,
                ArticleId = input.ArticleId,
                Serial = input.Serial,
                Condition = input.Condition,
                Trouble = input.Trouble,
                Complication = input.Complication,
            };

            await _context.RepairOrders.AddAsync(repairOrder, cancellationToken);
            
            return new CreateRepairOrderSuccessResultContract();
        }
    }
}