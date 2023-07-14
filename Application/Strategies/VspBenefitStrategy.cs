using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.Vsp.Services;
using InsuranceAPIv2.Shared.Constants;

namespace InsuranceAPIv2.Application.Strategies
{
    public class VspBenefitStrategy : IBenefitStrategy
    {
        public int SupportedCarrier => CarriersIdsConstants.Vsp;

        private readonly VspBenefitService vspBenefitService;
        
        public VspBenefitStrategy(VspBenefitService vspBenefitService)
        {
            this.vspBenefitService = vspBenefitService;
        }

        public async Task<IEnumerable<DtoBenefit>> FindPatientBenefits(int patientId)
        {
            IEnumerable<VspDtoBenefit> benefits = await vspBenefitService.GetPatientBenefits(patientId);

            IEnumerable<DtoBenefit> genericBenefits = benefits.Select(benefit => new DtoBenefit()
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Description = benefit.Description,
                Frequency = benefit.Frequency
            });

            return genericBenefits;
        }
    }
}
