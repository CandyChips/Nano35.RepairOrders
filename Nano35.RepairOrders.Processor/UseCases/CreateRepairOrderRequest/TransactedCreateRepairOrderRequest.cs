using System;
using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.Contracts.Storage.Artifacts;
using Nano35.RepairOrders.Processor.Services;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrderRequest
{
    public class CreateRepairOrderTransactionErrorResult :
        ICreateRepairOrderErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class TransactedCreateRepairOrderRequest :
        IPipelineNode<
            ICreateRepairOrderRequestContract, 
            ICreateRepairOrderResultContract>
    {
        private readonly ApplicationContext _context;
        private readonly IPipelineNode<
            ICreateRepairOrderRequestContract,
            ICreateRepairOrderResultContract> _nextNode;

        public TransactedCreateRepairOrderRequest(
            ApplicationContext context,
            IPipelineNode<
                ICreateRepairOrderRequestContract, 
                ICreateRepairOrderResultContract> nextNode)
        {
            _nextNode = nextNode;
            _context = context;
        }

        public async Task<ICreateRepairOrderResultContract> Ask(
            ICreateRepairOrderRequestContract input,
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
                return new CreateRepairOrderTransactionErrorResult{ Message = "Наименование не создано"};
            }
        }
    }
}