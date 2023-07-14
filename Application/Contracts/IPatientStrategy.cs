using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IPatientStrategy
    {
        public int SupportedCarrier { get; }
        public Task<DtoPatient> FindPatientById(int patiendId);
    }
}
