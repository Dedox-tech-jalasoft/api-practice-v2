using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface ICarrierService
    {
        public bool DoesCarrierExist(int carrierId);
        public Carrier GetCarrierById(int carrierId);
    }
}
