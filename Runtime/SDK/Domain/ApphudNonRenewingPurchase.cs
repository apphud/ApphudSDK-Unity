namespace Apphud.Unity.Domain
{
    public abstract class ApphudNonRenewingPurchase
    {
        public string ProductId { get; protected set; }
        public long PurchasedAt { get; protected set; }
        public long? CanceledAt { get; protected set; }
        public bool? IsConsumable { get; protected set; }
#if UNITY_ANDROID
        public string PurchaseToken { get; protected set; }
#endif
        public bool IsActive { get; protected set; }
    }
}