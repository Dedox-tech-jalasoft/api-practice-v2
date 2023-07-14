using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
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
            DtoPatient patient = await patientContext.RetrievePatientById(carrierId, patientId);
            
            return Ok(patient);
        }
    }
}
