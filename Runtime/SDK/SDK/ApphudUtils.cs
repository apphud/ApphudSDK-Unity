#if UNITY_EDITOR
using Apphud.Unity.Editor;
#elif UNITY_ANDROID
using Apphud.Unity.Android.SDK;
#elif UNITY_IOS
using Apphud.Unity.IOS.SDK;
#endif

namespace Apphud.Unity.SDK
{
    public static class ApphudUtils
    {
#if UNITY_EDITOR
        private static readonly IApphudUtils _utils = new ApphudEditorUtils();
#elif UNITY_ANDROID
        private static readonly IApphudUtils _utils = new ApphudAndroidUtils();
#elif UNITY_IOS
        private static readonly IApphudUtils _utils = new ApphudIOSUtils();
#endif

        public static void EnableAllLogs() => _utils.EnableAllLogs();
    }
}