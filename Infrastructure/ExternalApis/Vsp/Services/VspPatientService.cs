using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs;
using System.Net;
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

        public async Task<VspDtoPatient?> GetPatientById(int patientId)
        {
            try
            {
                VspDtoPatient? patient = await httpClient.GetFromJsonAsync<VspDtoPatient>($"patients/{patientId}");

                return patient ?? throw new InvalidOperationException("Failed to parse JSON payload");
            }

            catch (HttpRequestException expection)
            {
                if (expection.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }
    }
}
