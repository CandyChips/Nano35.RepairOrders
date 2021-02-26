using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrdersWorkRequest
{
    public class LoggedCreateRepairOrderWorkRequest :
        IPipelineNode<
            ICreateRepairOrderWorkRequestContract,
            ICreateRepairOrderWorkResultContract>
    {
        private readonly ILogger<LoggedCreateRepairOrderWorkRequest> _logger;
        private readonly IPipelineNode<
            ICreateRepairOrderWorkRequestContract, 
            ICreateRepairOrderWorkResultContract> _nextNode;

        public LoggedCreateRepairOrderWorkRequest(
            ILogger<LoggedCreateRepairOrderWorkRequest> logger,
            IPipelineNode<
                ICreateRepairOrderWorkRequestContract,
                ICreateRepairOrderWorkResultContract> nextNode)
        {
            _nextNode = nextNode;
            _logger = logger;
        }

        public async Task<ICreateRepairOrderWorkResultContract> Ask(
            ICreateRepairOrderWorkRequestContract input,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateRepairOrderWorkLogger starts on: {DateTime.Now}");
            var result = await _nextNode.Ask(input, cancellationToken);
            _logger.LogInformation($"CreateRepairOrderWorkLogger ends on: {DateTime.Now}");
            return result;
        }
    }
}