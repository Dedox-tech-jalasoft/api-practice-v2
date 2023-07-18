using InsuranceAPIv2.Application.Contracts;

namespace InsuranceAPIv2.Application.Factories
{
    public class BenefitStrategyFactory : StrategyFactory<IBenefitStrategy>
    {
        public BenefitStrategyFactory(IEnumerable<IBenefitStrategy> strategies) : base(strategies)
        {
        }
    }
}
