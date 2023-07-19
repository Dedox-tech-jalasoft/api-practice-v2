using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IBenefitContext
    {
        public Task<Result<IEnumerable<DtoBenefit>>> RetrievePatientBenefits(int carrierId, int patientId);
    }
}
