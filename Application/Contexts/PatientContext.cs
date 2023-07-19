using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;
using InsuranceAPIv2.Shared.Helpers;

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
            // Pending to update using Result<T>
            IPatientStrategy patientStrategy = patientStrategyFactory.GetStrategy((Carrier)carrierId);

            DtoPatient patient = await patientStrategy.FindPatientById(patientId);

            return patient;
        }
    }
}
