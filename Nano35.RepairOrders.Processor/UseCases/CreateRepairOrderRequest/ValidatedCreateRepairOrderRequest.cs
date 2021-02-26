using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;
using Nano35.Contracts.Storage.Artifacts;

namespace Nano35.RepairOrders.Processor.UseCases.CreateRepairOrderRequest
{
    public class CreateRepairOrderValidatorErrorResult :
        ICreateRepairOrderErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class ValidatedCreateRepairOrderRequest:
        IPipelineNode<
            ICreateRepairOrderRequestContract, 
            ICreateRepairOrderResultContract>
    {
        private readonly IPipelineNode<
            ICreateRepairOrderRequestContract, 
            ICreateRepairOrderResultContract> _nextNode;

        public ValidatedCreateRepairOrderRequest(
            IPipelineNode<
                ICreateRepairOrderRequestContract, 
                ICreateRepairOrderResultContract> nextNode)
        {
            _nextNode = nextNode;
        }

        public async Task<ICreateRepairOrderResultContract> Ask(
            ICreateRepairOrderRequestContract input,
            CancellationToken cancellationToken)
        {
            if (false)
            {
                return new CreateRepairOrderValidatorErrorResult() {Message = "Ошибка валидации"};
            }
            return await _nextNode.Ask(input, cancellationToken);
        }
    }
}