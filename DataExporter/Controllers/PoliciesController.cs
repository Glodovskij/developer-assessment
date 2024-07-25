using DataExporter.Application.Dtos;
using DataExporter.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoliciesController : ControllerBase
    {
        private IPolicyService _policyService;
        private readonly ILogger<PoliciesController> _logger;

        public PoliciesController(IPolicyService policyService, ILogger<PoliciesController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostPolicies([FromBody] CreatePolicyDto createPolicyDto)
        {
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            return Ok();
        }

        [HttpGet("{policyId}")]
        public async Task<IActionResult> GetPolicy(int policyId)
        {
            try
            {
                return Ok(_policyService.ReadPolicyAsync(policyId));
            }
            catch (Exception ex)
            {
                _logger.LogError("GetPolicy ", ex);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("export")]
        public async Task<IActionResult> ExportData([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return Ok();
        }
    }
}
