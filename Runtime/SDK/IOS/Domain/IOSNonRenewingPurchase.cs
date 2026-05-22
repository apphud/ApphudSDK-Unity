#if UNITY_IOS

using Apphud.Unity.Domain;
using Newtonsoft.Json;
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
        internal IOSApphudNonRenewingPurchase(string json) : this(JsonConvert.DeserializeObject<IOSApphudNonRenewingPurchaseJson>(json)) { }

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