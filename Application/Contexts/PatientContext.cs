using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contexts
{
    public class PatientContext : IPatientContext
    {
        private readonly IPatientStrategyFactory patientStrategyFactory;

        public PatientContext(IPatientStrategyFactory patientStrategyFactory)
        {
            this.patientStrategyFactory = patientStrategyFactory;
        }

        public async Task<DtoPatient> RetrievePatientById(int carrierId, int patientId)
        {
            IPatientStrategy patientStrategy = patientStrategyFactory.GetPatientStrategy(carrierId);

            DtoPatient patient = await patientStrategy.FindPatientById(patientId);

            return patient;
        }
    }
}
