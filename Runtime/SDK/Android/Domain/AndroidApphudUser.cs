#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudUser : ApphudUser
    {
        internal AndroidApphudUser(AndroidJavaObject javaObject)
        {
            UserId = javaObject.Get<string>("userId");
            CurrencyCode = javaObject.Get<string>("currencyCode");
            CountryCode = javaObject.Get<string>("countryCode");
        }
    }
}

#endif