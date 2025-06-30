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

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

       public double GetAirspeedVelocity() =>
    (Type, Load) switch
    {
        (SwallowType.African, SwallowLoad.None) or
        (SwallowType.European, SwallowLoad.None) => Type == SwallowType.African ? 22 : 20,

        (SwallowType.African, SwallowLoad.Coconut) or
        (SwallowType.European, SwallowLoad.Coconut) => Type == SwallowType.African ? 18 : 16,

        _ => throw new InvalidOperationException($"Unknown combination: {Type} carrying {Load}")
    };
    }
}