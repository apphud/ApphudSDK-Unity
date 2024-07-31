#if UNITY_EDITOR

using UnityEngine;

namespace Apphud.Unity.Editor
{
    public sealed class ApphudEditorUtils : IApphudUtils
    {
        internal static void LogNotSupportedWarning()
        {
            Debug.LogWarning("Apphud SDK is not supported in editor, please use it with android/ios build");
        }

        public void EnableAllLogs() => LogNotSupportedWarning();
    }
}

#endif