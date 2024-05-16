namespace Apphud.Unity.Domain
{
    public abstract class ApphudPurchaseResult
    {
        /// <summary>
        /// Autorenewable subscription object. May be null if error occurred or if non renewing product purchased instead.
        /// </summary>
        public ApphudSubscription Subscription { get; protected set; }

        /// <summary>
        /// Standard in-app purchase (non-consumable, consumable or non-renewing subscription) object. May be null if error occurred or if auto-renewable subscription purchased instead.
        /// </summary>
        public ApphudNonRenewingPurchase NonRenewingPurchase { get; protected set; }

#if UNITY_ANDROID
        /// <summary>
        /// Purchase from Play Market. May be null, if no was purchase made. For example, if there was no internet connection.
        /// </summary>
        public Purchase Purchase { get; protected set; }
#endif

#if UNITY_IOS
        /// <summary>
        ///  Transaction from StoreKit. May be null, if no transaction made. For example, if couldn't sign promo offer or couldn't get App Store receipt.
        /// </summary>
        public SKPaymentTransaction Transaction { get; protected set; }
#endif

        /// <summary>
        /// This error can be of three types. Check for error class.
        /// From StoreKit - This is a system error when purchasing transaction.
        /// From HTTP Client - This is a network/server issue when uploading receipt to Apphud.
        /// Custom `ApphudError` without codes. For example, if couldn't sign promo offer or couldn't get App Store receipt.
        /// </summary>
        public ApphudError Error { get; protected set; }

#if UNITY_ANDROID
        public bool UserCanceled { get; protected set; }
#endif
    }
}