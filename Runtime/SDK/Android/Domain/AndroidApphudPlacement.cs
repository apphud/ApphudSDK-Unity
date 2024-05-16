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
            Paywall = new AndroidApphudPaywall(javaObject.Get<AndroidJavaObject>("paywall"));
        }
    }
}

#endif