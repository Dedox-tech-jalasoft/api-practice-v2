using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IBenefitContext
    {
        public Task<IEnumerable<DtoBenefit>> RetrievePatientBenefits(int carrierId, int patientId);
    }
}
