using Xunit;

namespace DeveloperSample.ClassRefactoring
{
    public class ClassRefactorTest
    {
        [Fact]
        public void AfricanSwallowHasCorrectSpeed()
        {
            var swallow = SwallowFactory.GetSwallow(SwallowType.African, SwallowLoad.None);
            Assert.Equal(22, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenAfricanSwallowHasCorrectSpeed()
        {
            var swallow = SwallowFactory.GetSwallow(SwallowType.African, SwallowLoad.Coconut);
            Assert.Equal(18, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void EuropeanSwallowHasCorrectSpeed()
        {
            var swallow = SwallowFactory.GetSwallow(SwallowType.European, SwallowLoad.None);
            Assert.Equal(20, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenEuropeanSwallowHasCorrectSpeed()
        {
            var swallow = SwallowFactory.GetSwallow(SwallowType.European, SwallowLoad.Coconut);
            Assert.Equal(16, swallow.GetAirspeedVelocity());
        }
    }
}