using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contexts
{
    public class BenefitContext : IBenefitContext
    {
        private readonly IStrategyFactory<IBenefitStrategy> benefitStrategyFactory;

        public BenefitContext(IStrategyFactory<IBenefitStrategy> benefitStrategyFactory)
        {
            this.benefitStrategyFactory = benefitStrategyFactory;
        }

        public async Task<IEnumerable<DtoBenefit>> RetrievePatientBenefits(int carrierId, int patientId)
        {
            IBenefitStrategy strategy = benefitStrategyFactory.GetStrategy(carrierId);

            IEnumerable<DtoBenefit> benefits = await strategy.FindPatientBenefits(patientId);

            return benefits;
        }
    }
}
