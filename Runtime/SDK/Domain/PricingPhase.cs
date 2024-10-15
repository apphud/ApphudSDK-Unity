#if UNITY_ANDROID
namespace Apphud.Unity.Domain
{
    public abstract class PricingPhase
    {
        public string BillingPeriod { get; protected set; }
        public string PriceCurrencyCode { get; protected set; }
        public string FormattedPrice { get; protected set; }
        public long PriceAmountMicros { get; protected set; }
        public RecurrenceMode RecurrenceMode { get; protected set; }
        public int BillingCycleCount { get; protected set; }
    }
}
#endif