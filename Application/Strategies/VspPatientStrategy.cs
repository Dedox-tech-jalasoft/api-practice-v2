using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Constants;

namespace InsuranceAPIv2.Application.Strategies
{
    public class VspPatientStrategy : IPatientStrategy
    {
        public int SupportedCarrier => CarriersIdsConstants.Vsp;

        public Task<DtoPatient> FindPatientById(int patiendId)
        {
            Task<DtoPatient> task = Task.FromResult(new DtoPatient
            {
                Id = 100,
                FullName = "Vsp patient name",
                Company = "Wonderful company"
            });

            return task;
        }
    }
}
