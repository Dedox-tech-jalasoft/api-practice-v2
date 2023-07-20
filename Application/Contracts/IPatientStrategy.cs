using InsuranceAPIv2.Application.DTOs;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IPatientStrategy : IStrategy
    {
        public Task<DtoPatient?> FindPatientById(int patiendId);
    }
}
