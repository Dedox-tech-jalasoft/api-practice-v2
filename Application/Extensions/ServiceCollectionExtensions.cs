using InsuranceAPIv2.Application.Contexts;
using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.Factories;
using InsuranceAPIv2.Application.Strategies;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IPatientContext, PatientContext>();
            services.AddScoped<IPatientStrategyFactory, PatientStrategyFactory>();

            services.AddScoped<IPatientStrategy, EyeMedPatientStrategy>();
            services.AddScoped<IPatientStrategy, VspPatientStrategy>();

            services.AddScoped<IBenefitContext, BenefitContext>();
            services.AddScoped<IBenefitStrategyFactory, BenefitStrategyFactory>();

            services.AddScoped<IBenefitStrategy, EyeMedBenefitStrategy>();
        }
    }
}
