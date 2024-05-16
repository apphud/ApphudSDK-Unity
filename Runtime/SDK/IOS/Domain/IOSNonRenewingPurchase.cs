#if UNITY_IOS

using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudNonRenewingPurchaseJson
    {
        public string productId;
        public long purchasedAt;
        public long? canceledAt;
        public bool isActive;
    }

    internal sealed class IOSApphudNonRenewingPurchase : ApphudNonRenewingPurchase
    {
        internal IOSApphudNonRenewingPurchase(IOSApphudNonRenewingPurchaseJson json)
        {
            ProductId = json.productId;
            PurchasedAt = json.purchasedAt;
            CanceledAt = json.canceledAt;
            IsActive = json.isActive;
        }
    }
}

#endif