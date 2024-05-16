#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    public static class AndroidApphudUserPropertyKey
    {
        public static AndroidJavaObject GetJavaObject(this ApphudUserPropertyKey apphudUserPropertyKey)
        {
            return new AndroidJavaObject("com.apphud.sdk.ApphudUserPropertyKey$CustomProperty", apphudUserPropertyKey.key);
        }
    }
}

#endif