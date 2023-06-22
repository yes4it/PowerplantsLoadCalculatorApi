using GemBAL.Model;

namespace GemBAL.Interface
{
    public interface IPayloadService
    {
        List<PayloadResponseDto> GetProductionPlan(PayloadDto payload);

    }
}