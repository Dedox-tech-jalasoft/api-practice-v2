using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs;
using System.Net.Http.Json;

namespace InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.Services
{
    public class VspPatientService
    {
        private readonly HttpClient httpClient;

        public VspPatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<VspDtoPatient> GetPatientById(int patientId)
        {
            return await httpClient
                .GetFromJsonAsync<VspDtoPatient>($"/patients/{patientId}");
        }
    }
}
