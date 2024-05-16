#if UNITY_IOS

using Apphud.Unity.Domain;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudPurchaseResultJson
    {
        public IOSApphudSubscriptionJson subscription;
        public IOSApphudNonRenewingPurchaseJson nonRenewingPurchase;
        public string error;
        public IOSSKPaymentTransactionJson transaction;
    }

    internal sealed class IOSApphudPurchaseResult : ApphudPurchaseResult
    {
        internal IOSApphudPurchaseResult(string json) : this(JsonConvert.DeserializeObject<IOSApphudPurchaseResultJson>(json)) { }

        internal IOSApphudPurchaseResult(IOSApphudPurchaseResultJson json)
        {
            Subscription = json.subscription != null ? new IOSApphudSubscription(json.subscription) : null;
            NonRenewingPurchase = json.nonRenewingPurchase != null ? new IOSApphudNonRenewingPurchase(json.nonRenewingPurchase) : null;
            Error = json.error != null ? new IOSApphudError(json.error) : null;
            Transaction = json.transaction != null ? new IOSSKPaymentTransaction(json.transaction) : null;
        }
    }
}

#endif