#if UNITY_ANDROID && APPHUD_FB
using System;
using System.Collections.Generic;
using System.Text;
using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.SDK
{
    internal static class ApphudFacebookAttribution
    {
        private const string AndroidUtilityClass = "com.facebook.internal.Utility";
        private const string AndroidAppEventsLoggerClass = "com.facebook.appevents.AppEventsLogger";
        private const string AndroidJSONObjectClass = "org.json.JSONObject";

        internal static void Add(Action<string> onError = null)
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                using (AndroidJavaObject jsonObject = new AndroidJavaObject(AndroidJSONObjectClass))
                {
                    StringBuilder errorBuilder = new StringBuilder();

                    string extInfo = "";
                    try
                    {
                        using (AndroidJavaClass utilityClass = new AndroidJavaClass(AndroidUtilityClass))
                        {
                            utilityClass.CallStatic("setAppEventExtendedDeviceInfoParameters", jsonObject, activity);
                        }

                        extInfo = jsonObject.Call<string>("get", "extinfo");
                    }
                    catch (Exception ex)
                    {
                        errorBuilder.AppendLine($"Error on getting extinfo: {ex.Message}");
                    }

                    string anonID = "";
                    try
                    {
                        using (AndroidJavaClass appEventsLoggerClass = new AndroidJavaClass(AndroidAppEventsLoggerClass))
                        {
                            anonID = appEventsLoggerClass.CallStatic<string>("getAnonymousAppDeviceGUID", activity);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorBuilder.AppendLine($"Error on getting anonID: {ex.Message}");
                    }

                    string error = errorBuilder.ToString();

                    if (error.Length > 0)
                    {
                        onError?.Invoke(error);
                        return;
                    }

                    Dictionary<string, object> attributionData = new Dictionary<string, object>
                    {
                        { "fb_anon_id", anonID },
                        { "extinfo", extInfo }
                    };

                    ApphudAndroidInternal.AddAttribution(ApphudAttributionProvider.facebook, attributionData, anonID);
                }
            }
        }
    }
}
#endif