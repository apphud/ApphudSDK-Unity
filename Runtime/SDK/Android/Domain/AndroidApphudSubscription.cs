#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudSubscription : ApphudSubscription
    {
        private readonly AndroidJavaObject _javaObject;
        internal AndroidApphudSubscription(AndroidJavaObject javaObject)
        {
            _javaObject = javaObject;

            Status = _javaObject.GetEnum<ApphudSubscriptionStatus>("status");
            ProductId = _javaObject.Get<string>("productId");
            ExpiresAt = _javaObject.Get<long>("expiresAt");
            StartedAt = _javaObject.Get<long>("startedAt");
            CanceledAt = _javaObject.GetNullableLong("cancelledAt");
            IsInRetryBilling = _javaObject.Get<bool>("isInRetryBilling");
            IsAutoRenewEnabled = _javaObject.Get<bool>("isAutoRenewEnabled");
            IsIntroductoryActivated = _javaObject.Get<bool>("isIntroductoryActivated");
            Kind = _javaObject.GetEnum<ApphudKind>("kind");
            GroupId = _javaObject.Get<string>("groupId");
            PurchaseToken = javaObject.Get<string>("purchaseToken");
            BasePlanId = javaObject.Get<string>("basePlanId");
            Platform = javaObject.Get<string>("platform");
            IsActive = _javaObject.Call<bool>("isActive");
        }
    }
}

#endif