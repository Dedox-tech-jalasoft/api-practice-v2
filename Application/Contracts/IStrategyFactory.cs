using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Contracts
{
    public interface IStrategyFactory<T> where T: IStrategy
    {
        public T GetStrategy(Carrier carrier);
    }
}
