using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.Services;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Strategies
{
    public class VspPatientStrategy : IPatientStrategy
    {
        public Carrier SupportedCarrier => Carrier.Vsp;

        private readonly VspPatientService vspPatientService;

        public VspPatientStrategy(VspPatientService vspPatientService)
        {
            this.vspPatientService = vspPatientService;
        }

        public async Task<DtoPatient> FindPatientById(int patiendId)
        {
            VspDtoPatient patient = await vspPatientService.GetPatientById(patiendId);

            return new DtoPatient
            {
                Id = patient.Id,
                FullName = patient.FirstName + " " + patient.LastName,
                Company = patient.Corporation
            };
        }
    }
}
