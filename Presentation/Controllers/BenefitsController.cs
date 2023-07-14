using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
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
            IEnumerable<DtoBenefit> benefits = await benefitContext
                .RetrievePatientBenefits(carrierId, patientId);

            return Ok(benefits);
        }

    }
}
