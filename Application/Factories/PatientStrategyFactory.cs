using InsuranceAPIv2.Application.Contracts;

namespace InsuranceAPIv2.Application.Factories
{
    public class PatientStrategyFactory : IPatientStrategyFactory
    {
        private readonly IEnumerable<IPatientStrategy> patientStrategies;

        public PatientStrategyFactory(IEnumerable<IPatientStrategy> patientStrategies)
        {
            this.patientStrategies = patientStrategies;
        }

        public IPatientStrategy GetPatientStrategy(int carrierId)
        {
            IPatientStrategy? patientStrategy = patientStrategies
                .FirstOrDefault(strategy => strategy.SupportedCarrier == carrierId);

            if (patientStrategy == null)
            {
                throw new NotSupportedException($"No supported strategy found for carrierId {carrierId}");
            }

            return patientStrategy;
        }
    }
}
