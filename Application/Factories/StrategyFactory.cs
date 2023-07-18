using InsuranceAPIv2.Application.Contracts;

namespace InsuranceAPIv2.Application.Factories
{
    public abstract class StrategyFactory<T> : IStrategyFactory<T> where T : IStrategy
    {
        private readonly IEnumerable<T> strategies;

        protected StrategyFactory(IEnumerable<T> strategies)
        {
            this.strategies = strategies;
        }

        public T GetStrategy(int carrierId)
        {
            T? strategy = strategies.FirstOrDefault(strategy => strategy.SupportedCarrier == carrierId);

            if (strategy == null)
            {
                throw new NotSupportedException($"Not supported strategy found for carrierId {carrierId}");
            }

            return strategy;
        }
    }
}
