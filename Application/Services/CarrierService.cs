using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Services
{
    public class CarrierService : ICarrierService
    {
        public bool DoesCarrierExist(int carrierId)
        {
            return Enum.IsDefined(typeof(Carrier), carrierId);
        }

        public Carrier GetCarrierById(int carrierId)
        {
            return (Carrier)carrierId;
        }
    }
}
