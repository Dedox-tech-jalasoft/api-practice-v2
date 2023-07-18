namespace InsuranceAPIv2.Application.Contracts
{
    public interface IStrategyFactory<T> where T: IStrategy
    {
        public T GetStrategy(int carrierId);
    }
}
