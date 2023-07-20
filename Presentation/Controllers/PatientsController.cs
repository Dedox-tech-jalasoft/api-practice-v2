using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPIv2.Presentation.Controllers
{
    [Route("api/v2/carriers/{carrierId}/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientContext patientContext;

        public PatientsController(IPatientContext patientContext)
        {
            this.patientContext = patientContext;
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int carrierId, int patientId)
        {
            Result<DtoPatient> result = await patientContext.RetrievePatientById(carrierId, patientId);
            
            if (result.Error?.Code == Code.BadRequest)
            {
                return BadRequest(result.Error.Message);
            }

            if (result.Error?.Code == Code.NotFound)
            {
                return NotFound(result.Error.Message);
            }
            
            return Ok(result.Data);
        }
    }
}
