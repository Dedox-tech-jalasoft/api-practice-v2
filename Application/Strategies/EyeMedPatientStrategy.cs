using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs;
using InsuranceAPIv2.Shared.Constants;
using System.Text.Json;

namespace InsuranceAPIv2.Application.Strategies
{
    public class EyeMedPatientStrategy : IPatientStrategy
    {
        public int SupportedCarrier => CarriersIdsConstants.EyeMed;

        private readonly IHttpClientFactory httpClientFactory;

        public EyeMedPatientStrategy(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<DtoPatient> FindPatientById(int patiendId)
        {
            HttpClient httpClient = httpClientFactory.CreateClient("EyeMed");

            HttpResponseMessage response = await httpClient.GetAsync($"/patients/{patiendId}");

            Stream rawContent = await response.Content.ReadAsStreamAsync();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            DtoPatientEyeMed patient = await JsonSerializer.DeserializeAsync<DtoPatientEyeMed>(rawContent, options);

            return new DtoPatient
            {
                Id = patient.Id,
                FullName = patient.Name,
                Company = patient.Enterprise
            };

        }
    }
}
