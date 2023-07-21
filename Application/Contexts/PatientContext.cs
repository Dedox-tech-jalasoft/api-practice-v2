using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.DTOs;
using InsuranceAPIv2.Shared.Abstractions;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Contexts
{
    public class PatientContext : IPatientContext
    {
        private readonly IStrategyFactory<IPatientStrategy> patientStrategyFactory;
        private readonly ICarrierService carrierService;

        public PatientContext(IStrategyFactory<IPatientStrategy> patientStrategyFactory, ICarrierService carrierService)
        {
            this.patientStrategyFactory = patientStrategyFactory;
            this.carrierService = carrierService;
        }

        public async Task<Result<DtoPatient>> RetrievePatientById(int carrierId, int patientId)
        {
            if (!carrierService.DoesCarrierExist(carrierId))
            {
                Error error = new() { Code = Code.BadRequest, Message = "Invalid Carrier Id" };

                return new Result<DtoPatient> { Error = error };
            }

            Carrier carrier = carrierService.GetCarrierById(carrierId);

            IPatientStrategy patientStrategy = patientStrategyFactory.GetStrategy(carrier);

            DtoPatient? patient = await patientStrategy.FindPatientById(patientId);

            if (patient == null)
            {
                Error error = new() { Code = Code.NotFound, Message = "Patient not found" };

                return new Result<DtoPatient> { Error = error };
            }

            return new Result<DtoPatient> { Data = patient};
        }
    }
}
