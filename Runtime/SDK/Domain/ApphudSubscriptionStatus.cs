namespace Apphud.Unity.Domain
{
    public enum ApphudSubscriptionStatus
    {
        NONE,
        /// <summary>
        /// Free trial period.
        /// </summary>
        TRIAL,
        /// <summary>
        /// Paid introductory period.
        /// </summary>
        INTRO,
        /// <summary>
        /// Custom promotional offer.
        /// </summary>
        PROMO,
        /// <summary>
        /// Regular paid subscription.
        /// </summary>
        REGULAR,
        /// <summary>
        /// Custom grace period.Configurable in web.
        /// </summary>
        GRACE,
        /// <summary>
        /// Subscription was revoked.
        /// </summary>
        REFUNDED,
        /// <summary>
        /// Subscription has expired because has been canceled manually by user or had unresolved billing issues.
        /// </summary>
        EXPIRED
    }
}