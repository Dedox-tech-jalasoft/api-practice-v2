using InsuranceAPIv2.Application.Contracts;

namespace InsuranceAPIv2.Application.Factories
{
    public class PatientStrategyFactory : StrategyFactory<IPatientStrategy>
    {
        public PatientStrategyFactory(IEnumerable<IPatientStrategy> strategies) : base(strategies)
        {
        }
    }
}
