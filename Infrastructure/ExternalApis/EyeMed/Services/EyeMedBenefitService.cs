﻿using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs;
using System.Net.Http.Json;

namespace InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.Services
{
    public class EyeMedBenefitService
    {
        private readonly HttpClient httpClient;

        public EyeMedBenefitService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<EyeMedDtoBenefit>> GetPatientBenefits(int patientId)
        {
            IEnumerable<EyeMedDtoBenefit>? benefits = await httpClient
                .GetFromJsonAsync<IEnumerable<EyeMedDtoBenefit>>($"/patients/{patientId}/benefits");

            return benefits ?? throw new InvalidOperationException("Failed to parse JSON payload");
        }
    }
}
