#if UNITY_IOS

using System;
using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudSubscriptionJson
    {
        public string productId;
        public long expiresAt;
        public long startedAt;
        public long? canceledAt;
        public bool isInRetryBilling;
        public bool isAutorenewEnabled;
        public bool isIntroductoryActivated;
        public bool isActive;
        public string status;
    }

    internal sealed class IOSApphudSubscription : ApphudSubscription
    {
        internal IOSApphudSubscription(IOSApphudSubscriptionJson json)
        {
            ProductId = json.productId;
            ExpiresAt = json.expiresAt;
            StartedAt = json.startedAt;
            CanceledAt = json.canceledAt;
            IsInRetryBilling = json.isInRetryBilling;
            IsAutoRenewEnabled = json.isAutorenewEnabled;
            IsIntroductoryActivated = json.isIntroductoryActivated;
            IsActive = json.isActive;
            Status = Enum.Parse<ApphudSubscriptionStatus>(json.status, true);
        }
    }
}

#endif