using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    public abstract class Purchase
    {
        public abstract int GetPurchaseState();
        public abstract int GetQuantity();
        public abstract long GetPurchaseTime();
        public abstract string GetDeveloperPayload();
        public abstract string GetOrderId();
        public abstract string GetOriginalJson();
        public abstract string GetPackageName();
        public abstract string GetPurchaseToken();
        public abstract string GetSignature();
        public abstract List<string> GetSkus();
        public abstract List<string> GetProducts();
        public abstract bool IsAcknowledged();
        public abstract bool IsAutoRenewing();
    }
}