#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidPricingPhases : PricingPhases
    {
        internal AndroidPricingPhases(AndroidJavaObject javaObject)
        {
            PricingPhaseList = new JavaList<PricingPhase>(
                javaObject.Get<AndroidJavaObject>("pricingPhaseList"),
                javaPricingPhase => new AndroidPricingPhase(javaPricingPhase)
            );
        }
    }
}

#endif