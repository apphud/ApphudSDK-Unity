#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal struct AndroidApphudAttributionData
    {
        internal static AndroidJavaObject _emptyMap = new("java.util.HashMap");

        internal AndroidJavaObject JavaObject { get; private set; }

        internal AndroidApphudAttributionData(ApphudAttributionData data)
        {
            var rawMap = data?.RawData?.ToJavaMap(false);

            JavaObject = new AndroidJavaObject(
                "com.apphud.sdk.ApphudAttributionData",
                rawMap ?? _emptyMap,
                data?.AdNetwork,
                data?.Channel,
                data?.Campaign,
                data?.AdSet,
                data?.Creative,
                data?.Keyword,
                data?.Custom1,
                data?.Custom2
            );
        }
    }
}

#endif