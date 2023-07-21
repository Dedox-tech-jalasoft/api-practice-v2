using InsuranceAPIv2.Application.Contracts;
using InsuranceAPIv2.Application.Factories;
using InsuranceAPIv2.Shared.Helpers;
using Xunit;

namespace InsuranceAPIv2.Test.Application.Factories
{
    public class StrategyFactoryTest
    {
        [Fact]
        public void GetStrategy_ThrowsException_OnUnsupportedCarrier()
        {
            IEnumerable<IDummyStrategy> strategies = new List<IDummyStrategy> { new DummyStrategy() };

            StrategyFactory<IDummyStrategy> strategyFactory = new(strategies);

            Assert.Throws<NotSupportedException>(() => strategyFactory.GetStrategy(Carrier.Vsp));
        }

        [Fact]
        public void GetStrategy_ThrowsException_OnEmptyStrategyList()
        {
            IEnumerable<IDummyStrategy> strategies = new List<IDummyStrategy>() { };

            StrategyFactory<IDummyStrategy> strategyFactory = new(strategies);

            Assert.Throws<NotSupportedException>(() => strategyFactory.GetStrategy(Carrier.Vsp));
        }

        [Fact]
        public void GetStrategy_ReturnValidStrategy_OnSupportedCarrier()
        {
            IEnumerable<IDummyStrategy> strategies = new List<IDummyStrategy> { new DummyStrategy() };

            StrategyFactory<IDummyStrategy> strategyFactory = new(strategies);

            IDummyStrategy strategy = strategyFactory.GetStrategy(Carrier.EyeMed);

            Assert.Equal(Carrier.EyeMed, strategy.SupportedCarrier);
        }
    }

    public interface IDummyStrategy: IStrategy
    {

    }

    public class DummyStrategy : IDummyStrategy
    {
        public Carrier SupportedCarrier => Carrier.EyeMed;
    }
}
