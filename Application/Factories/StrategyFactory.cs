using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Shared.Helpers;

namespace InsuranceAPIv2.Application.Factories
{
    public class StrategyFactory<T> : IStrategyFactory<T> where T : IStrategy
    {
        private readonly IEnumerable<T> strategies;

        public StrategyFactory(IEnumerable<T> strategies)
        {
            this.strategies = strategies;
        }

        public T GetStrategy(Carrier carrier)
        {
            T? strategy = strategies.FirstOrDefault(strategy => strategy.SupportedCarrier == carrier);

            if (strategy == null)
            {
                throw new NotSupportedException($"Not supported strategy found for carrierId {carrier}");
            }

            return strategy;
        }
    }
}
