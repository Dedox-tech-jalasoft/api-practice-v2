using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.DTOs;
using InsuranceAPIv2.Infrastructure.ExternalApis.EyeMed.Services;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Strategies
{
    public class EyeMedBenefitStrategy : IBenefitStrategy
    {
        public Carrier SupportedCarrier => Carrier.EyeMed;

        private readonly EyeMedBenefitService eyeMedBenefitService;

        public EyeMedBenefitStrategy(EyeMedBenefitService eyeMedBenefitService)
        {
            this.eyeMedBenefitService = eyeMedBenefitService;
        }

        public async Task<IEnumerable<DtoBenefit>> FindPatientBenefits(int patientId)
        {
            IEnumerable<EyeMedDtoBenefit> benefits = await eyeMedBenefitService.GetPatientBenefits(patientId);

            IEnumerable<DtoBenefit> genericBenefits = benefits.Select(benefit => new DtoBenefit()
            {
                Id = benefit.Id,
                Name = benefit.Name,
                Frequency = benefit.Frequency,
                IsFullCoverage = benefit.IsFullCoverage
            });

            return genericBenefits;
        }
    }
}
