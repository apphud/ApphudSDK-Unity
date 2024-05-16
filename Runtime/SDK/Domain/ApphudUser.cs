namespace Apphud.Unity.Domain
{
    public abstract class ApphudUser
    {
        public string UserId { get; protected set; }
        public string CurrencyCode { get; protected set; }
        public string CountryCode { get; protected set; }
    }
}