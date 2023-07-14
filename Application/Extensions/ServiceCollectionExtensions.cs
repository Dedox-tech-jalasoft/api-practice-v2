using InsuranceAPIv2.Application.Contexts;
using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.Strategies;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IPatientContext, PatientContext>();

            services.AddScoped<IPatientStrategy, EyeMedPatientStrategy>();
            services.AddScoped<IPatientStrategy, VspPatientStrategy>();
        }
    }
}
