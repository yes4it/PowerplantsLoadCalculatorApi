using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PowerplantsLoadCalculatorApi.Interface;
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

                var productionPlan = _payloadService.GetProductionPlan(payload);

                var response = new List<PayloadResponse>();

                foreach (var production in productionPlan)
                {
                    response.Add(new PayloadResponse
                    {
                        Name = production.Name,
                        P = Math.Round(production.P, 1)
                    });
                }

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return StatusCode(500, $@"An error occurred while calculating the production plan.");
            }
        }
    }
}