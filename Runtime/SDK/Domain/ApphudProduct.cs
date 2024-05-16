using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    public abstract class ApphudProduct
    {
        /// <summary>
        /// Product Identifier from Google Play or App Store Connect..
        /// </summary>
        public string ProductId { get; protected set; }

        /// <summary>
        /// Product name from Apphud Dashboard
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Always `play_store` in Android and 'app_store' in iOS.
        /// </summary>
        public string Store { get; protected set; }

#if UNITY_ANDROID
        /// <summary>
        /// Base Plan Id of the product from Google Play Console
        /// </summary>
        public string BasePlanId { get; protected set; }
#endif

        /// <summary>
        /// Placement Identifier, if any.
        /// </summary>
        public string PlacementIdentifier { get; protected set; }

        /// <summary>
        /// User Generated Paywall Identifier
        /// </summary>
        public string PaywallIdentifier { get; protected set; }

#if UNITY_ANDROID
        public ApphudProductType? ProductType { get; protected set; }

        public string StoreProductId { get; protected set; }

        public string ProductTitle { get; protected set; }

        public string ProductDescription { get; protected set; }

        public string PriceCurrencyCode { get; protected set; }

        public string PriceAmountMicros { get; protected set; }

        public OneTimePurchaseOfferDetails OneTimePurchaseOfferDetails { get; protected set; }

        public List<SubscriptionOfferDetails> SubscriptionOfferDetails { get; protected set; }
#endif
    }
}