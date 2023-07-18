using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contexts
{
    public class PatientContext : IPatientContext
    {
        private readonly IStrategyFactory<IPatientStrategy> patientStrategyFactory;

        public PatientContext(IStrategyFactory<IPatientStrategy> patientStrategyFactory)
        {
            this.patientStrategyFactory = patientStrategyFactory;
        }

        public async Task<DtoPatient> RetrievePatientById(int carrierId, int patientId)
        {
            IPatientStrategy patientStrategy = patientStrategyFactory.GetStrategy(carrierId);

            DtoPatient patient = await patientStrategy.FindPatientById(patientId);

            return patient;
        }
    }
}
