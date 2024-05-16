using UnityEngine;

namespace Apphud.Unity.Android
{
    internal static class AndroidApp
    {
        private static AndroidJavaObject _currentActivity;
        internal static AndroidJavaObject CurrentActivity
        {
            get
            {
                if (_currentActivity == null)
                {
                    using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                    {
                        _currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                    }
                }

                return _currentActivity;
            }
        }
    }
}