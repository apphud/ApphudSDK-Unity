#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidOneTimePurchaseOfferDetails : OneTimePurchaseOfferDetails
    {
        internal AndroidOneTimePurchaseOfferDetails(AndroidJavaObject javaObject)
        {
            PriceAmountMicros = javaObject.Get<long>("priceAmountMicros");
            FormattedPrice = javaObject.Get<string>("formattedPrice");
            PriceCurrencyCode = javaObject.Get<string>("priceCurrencyCode");
            OfferIdToken = javaObject.Get<string>("offerIdToken");
        }
    }
}

#endif