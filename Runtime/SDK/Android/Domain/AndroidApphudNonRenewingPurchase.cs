#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudNonRenewingPurchase : ApphudNonRenewingPurchase
    {
        private readonly AndroidJavaObject _javaObject;
        internal AndroidApphudNonRenewingPurchase(AndroidJavaObject javaObject)
        {
            _javaObject = javaObject;

            ProductId = javaObject.Get<string>("productId");
            PurchasedAt = javaObject.Get<long>("purchasedAt");
            CanceledAt = javaObject.GetNullableLong("cancelledAt");
            IsConsumable = javaObject.Get<bool>("isConsumable");
            PurchaseToken = javaObject.Get<string>("purchaseToken");
            IsActive = _javaObject.Call<bool>("isActive");
        }
    }
}

#endif