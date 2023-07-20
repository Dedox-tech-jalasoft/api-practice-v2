using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs;
using System.Net;
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

        public async Task<EyeMedDtoPatient?> GetPatientById (int patientId)
        {
            try
            {
                EyeMedDtoPatient? patient = await httpClient.GetFromJsonAsync<EyeMedDtoPatient>($"/patients/{patientId}");

                return patient ?? throw new InvalidOperationException("Failed to parse JSON payload");
            }
            
            catch (HttpRequestException exception)
            {
                if (exception.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }
    }
}
