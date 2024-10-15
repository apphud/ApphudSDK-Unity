#if UNITY_IOS
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Apphud.Unity.Domain
{
    [Preserve]
    public sealed class Locale
    {
        [JsonProperty("currencyCode")]
        [Preserve]
        public string CurrencyCode { get; private set; }

        [JsonProperty("currencySymbol")]
        [Preserve]
        public string CurrencySymbol { get; private set; }
    }

    [Preserve]
    public sealed class SKProductDiscount
    {
        [JsonProperty("price")]
        [Preserve]
        public decimal Price { get; private set; }

        [JsonProperty("priceLocale")]
        [Preserve]
        public Locale PriceLocale { get; private set; }
    }

    [Preserve]
    public sealed class SKProductSubscriptionPeriod
    {
        [JsonProperty("numberOfUnits")]
        [Preserve]
        public int NumberOfUnits { get; private set; }

        [JsonProperty("unit")]
        [Preserve]
        public int Unit { get; private set; }
    }

    [Preserve]
    public sealed class SKProduct
    {
        [JsonProperty("productIdentifier")]
        [Preserve]
        public string ProductIdentifier { get; private set; }

        [JsonProperty("localizedTitle")]
        [Preserve]
        public string LocalizedTitle { get; private set; }

        [Preserve]
        [JsonProperty("localizedDescription")]
        public string LocalizedDescription { get; private set; }

        [JsonProperty("priceLocale")]
        [Preserve]
        public Locale PriceLocale { get; private set; }

        [JsonProperty("price")]
        [Preserve]
        public decimal Price { get; private set; }

        [JsonProperty("subscriptionPeriod")]
        [Preserve]
        public SKProductSubscriptionPeriod SubscriptionPeriod { get; private set; }

        [JsonProperty("introductoryPrice")]
        [Preserve]
        public SKProductDiscount IntroductoryPrice { get; private set; }

        [JsonProperty("isFamilyShareable")]
        [Preserve]
        public bool IsFamilyShareable { get; private set; }

        [JsonProperty("subscriptionGroupIdentifier")]
        [Preserve]
        public string SubscriptionGroupIdentifier { get; private set; }

        [JsonProperty("discounts")]
        [Preserve]
        public SKProductDiscount[] Discounts { get; private set; }
    }
}
#endif