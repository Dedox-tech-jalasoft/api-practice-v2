using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IStrategy
    {
        public Carrier SupportedCarrier { get; }
    }
}
