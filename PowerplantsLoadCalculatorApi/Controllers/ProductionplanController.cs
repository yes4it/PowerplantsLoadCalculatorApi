using AutoMapper;
using GemBAL.Interface;
using GemBAL.Model;
using Microsoft.AspNetCore.Mvc;
using PowerplantsLoadCalculatorApi.Model;

namespace PowerplantsLoadCalculatorApi.Controllers
{
    [ApiController]
    [Route("productionplan")]
    public class ProductionplanController : ControllerBase
    {
        private readonly ILogger<ProductionplanController> _logger;
        private readonly IPayloadService _payloadService;
        private readonly IMapper _mapper;

        public ProductionplanController(ILogger<ProductionplanController> logger, IPayloadService payloadService, IMapper mapper)
        {
            _logger = logger;
            _payloadService = payloadService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CalculateProductionPlan([FromBody] Payload payload)
        {
            try
            {
                if (payload == null) return BadRequest();

                var productionPlans = _payloadService.GetProductionPlan(_mapper.Map<PayloadDto>(payload));

                return new JsonResult(productionPlans);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return StatusCode(500, $@"An error occurred while calculating the production plan.");
            }
        }
    }
}