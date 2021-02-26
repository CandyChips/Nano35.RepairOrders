using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Processor.UseCases.CreateWorkRequest
{
    public class LoggedCreateWorkRequest :
        IPipelineNode<
            ICreateWorkRequestContract,
            ICreateWorkResultContract>
    {
        private readonly ILogger<LoggedCreateWorkRequest> _logger;
        private readonly IPipelineNode<
            ICreateWorkRequestContract, 
            ICreateWorkResultContract> _nextNode;

        public LoggedCreateWorkRequest(
            ILogger<LoggedCreateWorkRequest> logger,
            IPipelineNode<
                ICreateWorkRequestContract,
                ICreateWorkResultContract> nextNode)
        {
            _nextNode = nextNode;
            _logger = logger;
        }

        public async Task<ICreateWorkResultContract> Ask(
            ICreateWorkRequestContract input,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateWorkLogger starts on: {DateTime.Now}");
            var result = await _nextNode.Ask(input, cancellationToken);
            _logger.LogInformation($"CreateWorkLogger ends on: {DateTime.Now}");
            return result;
        }
    }
}