namespace Apphud.Unity.Domain
{
    public abstract class ApphudPlacement
    {
        public string Identifier { get; protected set; }
        public ApphudPaywall Paywall { get; protected set; }
    }
}