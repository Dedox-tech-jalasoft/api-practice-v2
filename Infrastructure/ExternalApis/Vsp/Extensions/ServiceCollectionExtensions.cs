using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceCollectionExtensions
    {
        public static void AddVspServices (this IServiceCollection services, IConfiguration configuration)
        {
            Uri vspUri = new Uri(configuration["ExternalApis:VspUrl"]!);
            
            services.AddHttpClient<VspPatientService>(options => options.BaseAddress = vspUri);

            services.AddHttpClient<VspBenefitService>(options => options.BaseAddress = vspUri);
        }
    }
}
