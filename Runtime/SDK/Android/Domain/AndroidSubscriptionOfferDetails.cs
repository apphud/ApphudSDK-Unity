#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidSubscriptionOfferDetails : SubscriptionOfferDetails
    {
        internal AndroidSubscriptionOfferDetails(AndroidJavaObject javaObject)
        {
            PricingPhases = javaObject.GetJavaNulableObject<PricingPhases>(
                "pricingPhases",
                (javaPricingPhases) => new AndroidPricingPhases(javaPricingPhases)
            );
            BasePlanId = javaObject.Get<string>("basePlanId");
            OfferId = javaObject.Get<string>("offerId");
            OfferToken = javaObject.Get<string>("offerToken");
            OfferTags = new JavaBaseList<string>(javaObject.Get<AndroidJavaObject>("offerTags"));
        }
    }
}

#endif