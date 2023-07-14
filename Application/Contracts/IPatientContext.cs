using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IPatientContext
    {
        public Task<DtoPatient> RetrievePatientById(int carrierId, int patientId);
    }
}
