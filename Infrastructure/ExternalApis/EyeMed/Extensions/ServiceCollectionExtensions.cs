﻿using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEyeMedServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<EyeMedPatientService>(options =>
            {
                options.BaseAddress = new Uri(configuration["ExternalApis:EyeMedUrl"]!);
            });
        }
    }
}
