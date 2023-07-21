using InsuranceAPIv2.Application.Contexts;
using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.Factories;
using InsuranceAPIv2.Application.Services;
using InsuranceAPIv2.Application.Strategies;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices (this IServiceCollection services)
        {
            services.AddSingleton<ICarrierService, CarrierService>();
            
            services.AddScoped<IPatientContext, PatientContext>();
            services.AddScoped<IStrategyFactory<IPatientStrategy>, StrategyFactory<IPatientStrategy>>();

            services.AddScoped<IPatientStrategy, EyeMedPatientStrategy>();
            services.AddScoped<IPatientStrategy, VspPatientStrategy>();

            services.AddScoped<IBenefitContext, BenefitContext>();
            services.AddScoped<IStrategyFactory<IBenefitStrategy>, StrategyFactory<IBenefitStrategy>>();

            services.AddScoped<IBenefitStrategy, EyeMedBenefitStrategy>();
            services.AddScoped<IBenefitStrategy, VspBenefitStrategy>();
        }
    }
}
