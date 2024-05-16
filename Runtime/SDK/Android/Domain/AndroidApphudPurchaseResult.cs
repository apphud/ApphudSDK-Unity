#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudPurchaseResult : ApphudPurchaseResult
    {
        private AndroidJavaObject _javaObject;
        internal AndroidApphudPurchaseResult(AndroidJavaObject javaObject)
        {
            _javaObject = javaObject;

            Purchase = javaObject.GetJavaNulableObject<Purchase>(
                "purchase",
                (javaPurchase) => new AndroidPurchase(javaPurchase)
            );

            Subscription = javaObject.GetJavaNulableObject<ApphudSubscription>(
                "subscription",
                (javaSubscription) => new AndroidApphudSubscription(javaSubscription)
            );

            NonRenewingPurchase = javaObject.GetJavaNulableObject<ApphudNonRenewingPurchase>(
                "nonRenewingPurchase",
                (javaSubscription) => new AndroidApphudNonRenewingPurchase(javaSubscription)
            );

            Error = javaObject.GetJavaNulableObject<ApphudError>(
                "error",
                (javaApphudError) => new AndroidApphudError(javaApphudError)
            );

            UserCanceled = _javaObject.Call<bool>("userCanceled");
        }
    }
}

#endif