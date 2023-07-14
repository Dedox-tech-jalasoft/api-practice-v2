namespace InsuranceAPIv2.Application.Contracts
{
    public interface IBenefitStrategyFactory
    {
        public IBenefitStrategy GetBenefitStrategy(int carrierId);
    }
}
