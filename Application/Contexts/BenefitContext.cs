using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Contexts
{
    public class BenefitContext : IBenefitContext
    {
        private readonly IStrategyFactory<IBenefitStrategy> benefitStrategyFactory;
        private readonly ICarrierService carrierService;

        public BenefitContext(IStrategyFactory<IBenefitStrategy> benefitStrategyFactory, ICarrierService carrierService)
        {
            this.benefitStrategyFactory = benefitStrategyFactory;
            this.carrierService = carrierService;
        }

        public async Task<Result<IEnumerable<DtoBenefit>>> RetrievePatientBenefits(int carrierId, int patientId)
        {
            if (!carrierService.DoesCarrierExist(carrierId))
            {
                Error error = new() { Code = Code.BadRequest, Message = "Invalid Carrier Id" };

                return new Result<IEnumerable<DtoBenefit>> { Error = error };
            }
            
            Carrier carrier = carrierService.GetCarrierById(carrierId);
            
            IBenefitStrategy strategy = benefitStrategyFactory.GetStrategy(carrier);

            IEnumerable<DtoBenefit> benefits = await strategy.FindPatientBenefits(patientId);

            return new Result<IEnumerable<DtoBenefit>> { Data = benefits };
        }
    }
}
