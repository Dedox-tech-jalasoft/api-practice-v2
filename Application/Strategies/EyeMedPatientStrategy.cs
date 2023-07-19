using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.Services;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Strategies
{
    public class EyeMedPatientStrategy : IPatientStrategy
    {
        public Carrier SupportedCarrier => Carrier.EyeMed;

        private readonly EyeMedPatientService eyeMedPatientService;

        public EyeMedPatientStrategy(EyeMedPatientService eyeMedPatientService)
        {
            this.eyeMedPatientService = eyeMedPatientService;
        }

        public async Task<DtoPatient> FindPatientById(int patiendId)
        {
            EyeMedDtoPatient patient = await eyeMedPatientService.GetPatientById(patiendId);

            return new DtoPatient
            {
                Id = patient.Id,
                FullName = patient.Name,
                Company = patient.Enterprise
            };

        }
    }
}
