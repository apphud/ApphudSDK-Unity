#if UNITY_ANDROID

using UnityEngine;

namespace Apphud.Unity.Android.SDK
{
    public class ApphudAndroidUtils : IApphudUtils
    {
        public void EnableAllLogs()
        {
            using (AndroidJavaClass apphudUtils = new AndroidJavaClass("com.apphud.sdk.ApphudUtils"))
            {
                AndroidJavaObject instance = apphudUtils.GetStatic<AndroidJavaObject>("INSTANCE");
                instance.Call("enableAllLogs");
            }
        }
    }
}

#endif