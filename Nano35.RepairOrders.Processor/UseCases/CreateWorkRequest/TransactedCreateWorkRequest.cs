using System;
using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.RepairOrders.Processor.Services;

namespace Nano35.RepairOrders.Processor.UseCases.CreateWorkRequest
{
    public class CreateWorkTransactionErrorResult :
        ICreateWorkErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class TransactedCreateWorkRequest :
        IPipelineNode<
            ICreateWorkRequestContract, 
            ICreateWorkResultContract>
    {
        private readonly ApplicationContext _context;
        private readonly IPipelineNode<
            ICreateWorkRequestContract,
            ICreateWorkResultContract> _nextNode;

        public TransactedCreateWorkRequest(
            ApplicationContext context,
            IPipelineNode<
                ICreateWorkRequestContract, 
                ICreateWorkResultContract> nextNode)
        {
            _nextNode = nextNode;
            _context = context;
        }

        public async Task<ICreateWorkResultContract> Ask(
            ICreateWorkRequestContract input,
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
                return new CreateWorkTransactionErrorResult{ Message = "Наименование не создано"};
            }
        }
    }
}