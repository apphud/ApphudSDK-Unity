#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudPlacement : ApphudPlacement
    {
        internal AndroidApphudPlacement(AndroidJavaObject javaObject)
        {
            Identifier = javaObject.Get<string>("identifier");
            AndroidJavaObject javaPaywall = javaObject.Get<AndroidJavaObject>("paywall");
            Paywall = javaPaywall != null ? new AndroidApphudPaywall(javaPaywall) : null;
        }
    }
}

#endif