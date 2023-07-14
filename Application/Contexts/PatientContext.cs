using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contexts
{
    public class PatientContext : IPatientContext
    {
        private readonly IEnumerable<IPatientStrategy> patientStrategies;

        public PatientContext(IEnumerable<IPatientStrategy> patientStrategies)
        {
            this.patientStrategies = patientStrategies;
        }

        public async Task<DtoPatient> RetrievePatientById(int carrierId, int patientId)
        {
            // Asumming that we obtain the correct service based on carrierId
            // Something like service = getServices(carrierId)
            // And then result = service.FindPatientById()
            IPatientStrategy patientStrategy = patientStrategies
                .FirstOrDefault(strategy => strategy.SupportedCarrier == carrierId);

            DtoPatient patient = await patientStrategy.FindPatientById(patientId);

            return patient;
        }
    }
}
