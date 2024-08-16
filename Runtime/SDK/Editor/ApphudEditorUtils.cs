#if UNITY_EDITOR

using UnityEngine;

namespace Apphud.Unity.Editor
{
    public sealed class ApphudEditorUtils : IApphudUtils
    {
        internal static string LogNotSupportedWarning()
        {
            string warning = "Apphud SDK is not supported in editor, please use it with android/ios build";
            Debug.LogWarning(warning);
            return warning;
        }

        public void EnableAllLogs() => LogNotSupportedWarning();
    }
}

#endif