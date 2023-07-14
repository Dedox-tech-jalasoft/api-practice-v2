using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IBenefitStrategy
    {
        public int SupportedCarrier { get ; }
        public Task<IEnumerable<DtoBenefit>> FindPatientBenefits(int patientId);
    }
}
