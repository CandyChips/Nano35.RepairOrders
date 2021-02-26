using System.Threading.Tasks;

namespace Nano35.RepairOrders.Api.UseCases
{
    public interface IPipelineNode<in TIn, TOut>
    {
        Task<TOut> Ask(TIn input);
    }
}