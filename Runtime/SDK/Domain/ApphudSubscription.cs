namespace Apphud.Unity.Domain
{
    public abstract class ApphudSubscription
    {
        /// <summary>
        /// Status of the subscription. It can only be in one state at any moment.
        /// 
        /// Possible values:
        /// * `trial`: Free trial period.
        /// * `intro`: Paid introductory period.
        /// * `promo`: Custom promotional offer.
        /// * `regular`: Regular paid subscription.
        /// * `grace`: Custom grace period.Configurable in web.
        /// * `refunded`: Subscription was revoked.
        /// * `expired`: Subscription has expired because has been canceled manually by user or had unresolved billing issues.
        /// </summary>
        public ApphudSubscriptionStatus Status { get; protected set; }

        /// <summary>
        /// Product identifier.
        /// </summary>
        public string ProductId { get; protected set; }

        /// <summary>
        /// Expiration date of current subscription period.
        /// </summary>
        public long ExpiresAt { get; protected set; }

        /// <summary>
        /// Date when user has purchased the subscription.
        /// </summary>
        public long StartedAt { get; protected set; }

        /// <summary>
        /// Canceled date of subscription, i.e. refund date. Null if subscription is not refunded.
        /// </summary>
        public long? CanceledAt { get; protected set; }

        /// <summary>
        /// Whether or not subscription is in billing issue state.
        /// </summary>
        public bool IsInRetryBilling { get; protected set; }

        /// <summary>
        /// False value means that user has turned off subscription renewal from Google Play settings.
        /// </summary>
        public bool IsAutoRenewEnabled { get; protected set; }

        /// <summary>
        /// True value means that user has already used introductory or free trial offer.
        /// </summary>
        public bool IsIntroductoryActivated { get; protected set; }

#if UNITY_ANDROID
        public ApphudKind? Kind { get; protected set; }
        public string GroupId { get; protected set; }
        public string PurchaseToken { get; protected set; }
        public string BasePlanId { get; protected set; }
        public string Platform { get; protected set; }
#endif

        /// <summary>
        /// Use this function to detect whether to give or not premium content to the user.
        /// - Returns: If value is `true` then user should have access to premium content.
        /// </summary>
        public bool IsActive { get; protected set; }
    }
}