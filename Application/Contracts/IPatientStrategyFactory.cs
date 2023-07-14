namespace InsuranceAPIv2.Application.Contracts
{
    public interface IPatientStrategyFactory
    {
        public IPatientStrategy GetPatientStrategy(int carrierId);
    }
}
