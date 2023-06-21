using GemDomain.Entities;

namespace PowerplantsLoadCalculatorApi.Manager
{
    public interface IPayloadService
    {
        List<PowerProduction> GetProductionPlan(Payload payload);

    }
}