using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPIv2.Presentation.Controllers
{
    [Route("api/v2/carriers/{carrierId}/patients/{patientId}/benefits")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitContext benefitContext;

        public BenefitsController(IBenefitContext benefitContext)
        {
            this.benefitContext = benefitContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientBenefits (int carrierId, int patientId)
        {
            Result<IEnumerable<DtoBenefit>> result = await benefitContext
                .RetrievePatientBenefits(carrierId, patientId);
            
            if (result.Error?.Code == Code.BadRequest)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok(result.Data);
        }

    }
}
