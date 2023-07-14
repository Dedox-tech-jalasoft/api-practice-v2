using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs;
using System.Net.Http.Json;

namespace InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.Services
{
    public class VspBenefitService
    {
        private readonly HttpClient httpClient;

        public VspBenefitService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<VspDtoBenefit>> GetPatientBenefits (int patientId)
        {
            return await httpClient
                .GetFromJsonAsync<IEnumerable<VspDtoBenefit>>($"patients/{patientId}/benefits");
        }
    }
}
