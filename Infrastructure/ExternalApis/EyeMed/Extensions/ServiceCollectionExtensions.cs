using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        public static void AddEyeMedServices (this IServiceCollection services, IConfiguration configuration)
        {
            Uri eyeMedUri = new(configuration["ExternalApis:EyeMedUrl"]!);
            
            services.AddHttpClient<EyeMedPatientService>(options => options.BaseAddress = eyeMedUri);

            services.AddHttpClient<EyeMedBenefitService>(options => options.BaseAddress = eyeMedUri);
        }
    }
}
