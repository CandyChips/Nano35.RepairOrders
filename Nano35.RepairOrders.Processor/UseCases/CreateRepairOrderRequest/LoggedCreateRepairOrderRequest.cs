using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nano35.Contracts.repair.artifacts;
using Nano35.Contracts.Storage.Artifacts;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrderRequest
{
    public class LoggedCreateRepairOrderRequest :
        IPipelineNode<
            ICreateRepairOrderRequestContract,
            ICreateRepairOrderResultContract>
    {
        private readonly ILogger<LoggedCreateRepairOrderRequest> _logger;
        private readonly IPipelineNode<
            ICreateRepairOrderRequestContract, 
            ICreateRepairOrderResultContract> _nextNode;

        public LoggedCreateRepairOrderRequest(
            ILogger<LoggedCreateRepairOrderRequest> logger,
            IPipelineNode<
                ICreateRepairOrderRequestContract,
                ICreateRepairOrderResultContract> nextNode)
        {
            _nextNode = nextNode;
            _logger = logger;
        }

        public async Task<ICreateRepairOrderResultContract> Ask(
            ICreateRepairOrderRequestContract input,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateRepairOrderLogger starts on: {DateTime.Now}");
            var result = await _nextNode.Ask(input, cancellationToken);
            _logger.LogInformation($"CreateRepairOrderLogger ends on: {DateTime.Now}");
            return result;
        }
    }
}