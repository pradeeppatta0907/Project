using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public interface ISwallow
    {
        double GetAirspeedVelocity();
    }

    public static class SwallowFactory
    {
        public static ISwallow GetSwallow(SwallowType type, SwallowLoad load = SwallowLoad.None) =>
            (type, load) switch
            {
                (SwallowType.African, SwallowLoad.None) => new AfricanSwallow(),
                (SwallowType.African, SwallowLoad.Coconut) => new AfricanSwallowWithCoconut(),
                (SwallowType.European, SwallowLoad.None) => new EuropeanSwallow(),
                (SwallowType.European, SwallowLoad.Coconut) => new EuropeanSwallowWithCoconut(),
                _ => throw new InvalidOperationException($"Unsupported combination: {type} carrying {load}")
            };
    }

    public class AfricanSwallow : ISwallow
    {
        public double GetAirspeedVelocity() => 22;
    }

    public class AfricanSwallowWithCoconut : ISwallow
    {
        public double GetAirspeedVelocity() => 18;
    }

    public class EuropeanSwallow : ISwallow
    {
        public double GetAirspeedVelocity() => 20;
    }

    public class EuropeanSwallowWithCoconut : ISwallow
    {
        public double GetAirspeedVelocity() => 16;
    }
}