namespace Apphud.Unity.Domain
{
    public abstract class OneTimePurchaseOfferDetails
    {
        public long PriceAmountMicros { get; protected set; }
        public string FormattedPrice { get; protected set; }
        public string PriceCurrencyCode { get; protected set; }
        public string OfferIdToken { get; protected set; }
    }
}