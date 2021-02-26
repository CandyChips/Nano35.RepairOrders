using System;
using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.RepairOrders.Processor.Services;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrdersWorkRequest
{
    public class CreateRepairOrderWorkTransactionErrorResult :
        ICreateRepairOrderWorkErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class TransactedCreateRepairOrderWorkRequest :
        IPipelineNode<
            ICreateRepairOrderWorkRequestContract, 
            ICreateRepairOrderWorkResultContract>
    {
        private readonly ApplicationContext _context;
        private readonly IPipelineNode<
            ICreateRepairOrderWorkRequestContract,
            ICreateRepairOrderWorkResultContract> _nextNode;

        public TransactedCreateRepairOrderWorkRequest(
            ApplicationContext context,
            IPipelineNode<
                ICreateRepairOrderWorkRequestContract, 
                ICreateRepairOrderWorkResultContract> nextNode)
        {
            _nextNode = nextNode;
            _context = context;
        }

        public async Task<ICreateRepairOrderWorkResultContract> Ask(
            ICreateRepairOrderWorkRequestContract input,
            CancellationToken cancellationToken)
        {
            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var response = await _nextNode.Ask(input, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                return new CreateRepairOrderWorkTransactionErrorResult{ Message = "Наименование не создано"};
            }
        }
    }
}