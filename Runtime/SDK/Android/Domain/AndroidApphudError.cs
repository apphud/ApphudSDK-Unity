#if UNITY_ANDROID

using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudError : ApphudError
    {
        internal AndroidApphudError(AndroidJavaObject javaObject)
        {
            Message = javaObject.Get<string>("message");
            SecondErrorMessage = javaObject.Get<string>("secondErrorMessage");
            ErrorCode = javaObject.GetNullableInt("errorCode");
        }
    }
}

#endif