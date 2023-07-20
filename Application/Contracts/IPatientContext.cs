using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IPatientContext
    {
        public Task<Result<DtoPatient>> RetrievePatientById(int carrierId, int patientId);
    }
}
