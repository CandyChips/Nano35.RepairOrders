using System.Threading;
using System.Threading.Tasks;
using Nano35.Contracts.repair.artifacts;

namespace Nano35.RepairOrders.Api.UseCases.CreateWorkRequest
{
    public class CreateWorkValidatorErrorResult :
        ICreateWorkErrorResultContract
    {
        public string Message { get; set; }
    }
    
    public class ValidatedCreateWorkRequest:
        IPipelineNode<
            ICreateWorkRequestContract, 
            ICreateWorkResultContract>
    {
        private readonly IPipelineNode<
            ICreateWorkRequestContract, 
            ICreateWorkResultContract> _nextNode;

        public ValidatedCreateWorkRequest(
            IPipelineNode<
                ICreateWorkRequestContract, 
                ICreateWorkResultContract> nextNode)
        {
            _nextNode = nextNode;
        }

        public async Task<ICreateWorkResultContract> Ask(
            ICreateWorkRequestContract input)
        {
            if (false)
            {
                return new CreateWorkValidatorErrorResult() {Message = "Ошибка валидации"};
            }
            return await _nextNode.Ask(input);
        }
    }
}