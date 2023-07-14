using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs;
using System.Net.Http.Json;

namespace InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.Services
{
    public class EyeMedPatientService
    {
        private readonly HttpClient httpClient;

        public EyeMedPatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<EyeMedDtoPatient> GetPatientById (int patientId)
        {
            return await httpClient
                .GetFromJsonAsync<EyeMedDtoPatient>($"/patients/{patientId}");
        }
    }
}
