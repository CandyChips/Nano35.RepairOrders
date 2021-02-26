using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Api.UseCases.CreateRepairOrdersWorkRequest
{
    public class CreateRepairOrderWorkValidatorErrorResult :
        ICreateRepairOrderWorkErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class ValidatedCreateRepairOrderWorkRequest:
        IPipelineNode<
            ICreateRepairOrderWorkRequestContract, 
            ICreateRepairOrderWorkResultContract>
    {
        private readonly IPipelineNode<
            ICreateRepairOrderWorkRequestContract, 
            ICreateRepairOrderWorkResultContract> _nextNode;

        public ValidatedCreateRepairOrderWorkRequest(
            IPipelineNode<
                ICreateRepairOrderWorkRequestContract, 
                ICreateRepairOrderWorkResultContract> nextNode)
        {
            _nextNode = nextNode;
        }

        public async Task<ICreateRepairOrderWorkResultContract> Ask(
            ICreateRepairOrderWorkRequestContract input)
        {
            if (false)
            {
                return new CreateRepairOrderWorkValidatorErrorResult() {Message = "Ошибка валидации"};
            }
            return await _nextNode.Ask(input);
        }
    }
}