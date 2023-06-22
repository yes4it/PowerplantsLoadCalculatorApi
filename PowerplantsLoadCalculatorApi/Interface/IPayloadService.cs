using GemDomain.Entities;
using PowerplantsLoadCalculatorApi.Model;

namespace PowerplantsLoadCalculatorApi.Interface
{
    public interface IPayloadService
    {
        List<PayloadResponse> GetProductionPlan(Model.Payload payload);

    }
}