#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidPricingPhase : PricingPhase
    {
        internal AndroidPricingPhase(AndroidJavaObject javaObject)
        {
            BillingPeriod = javaObject.Get<string>("billingPeriod");
            PriceCurrencyCode = javaObject.Get<string>("priceCurrencyCode");
            FormattedPrice = javaObject.Get<string>("formattedPrice");
            PriceAmountMicros = javaObject.Get<long>("priceAmountMicros");
            RecurrenceMode = javaObject.GetEnum<RecurrenceMode>("recurrenceMode");
            BillingCycleCount = javaObject.Get<int>("billingCycleCount");
        }
    }
}

#endif