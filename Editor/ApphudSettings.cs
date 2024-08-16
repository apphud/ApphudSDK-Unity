using System.IO;
using UnityEditor;
using UnityEditor.Build;

namespace Apphud.Editor
{
    internal static class ApphudSettings
    {
        [MenuItem("Apphud/IOS/ActivateFacebookSDK", true)]
        public static bool ValidateActivateFacebookSDK()
        {
            return !CheckFacebookSDKDefine(NamedBuildTarget.iOS);
        }

        [MenuItem("Apphud/IOS/ActivateFacebookSDK")]
        public static void ActivateFacebookSDK()
        {
            UpdateFacebookSDKStatus(NamedBuildTarget.iOS, true);
        }

        [MenuItem("Apphud/IOS/DeactivateFacebookSDK", true)]
        public static bool ValidateDeactivateFacebookSDK()
        {
            return CheckFacebookSDKDefine(NamedBuildTarget.iOS);
        }

        [MenuItem("Apphud/IOS/DeactivateFacebookSDK")]
        public static void DeactivateFacebookSDK()
        {
            UpdateFacebookSDKStatus(NamedBuildTarget.iOS, false);
        }

        [MenuItem("Apphud/Android/ActivateFacebookSDK", true)]
        public static bool ValidateActivateFacebookSDKAndroid()
        {
            return !CheckFacebookSDKDefine(NamedBuildTarget.Android);
        }

        [MenuItem("Apphud/Android/ActivateFacebookSDK")]
        public static void ActivateFacebookSDKAndroid()
        {
            UpdateFacebookSDKStatus(NamedBuildTarget.Android, true);
        }

        [MenuItem("Apphud/Android/DeactivateFacebookSDK", true)]
        public static bool ValidateDeactivateFacebookSDKAndroid()
        {
            return CheckFacebookSDKDefine(NamedBuildTarget.Android);
        }

        [MenuItem("Apphud/Android/DeactivateFacebookSDK")]
        public static void DeactivateFacebookSDKAndroid()
        {
            UpdateFacebookSDKStatus(NamedBuildTarget.Android, false);
        }

        private static void UpdateFacebookSDKStatus(NamedBuildTarget namedBuildTarget, bool isEnabled)
        {
            if (namedBuildTarget == NamedBuildTarget.iOS)
            {
                UpdateIncludingFileInBuild("ApphudUnityFacebookBridge", "Plugins/iOS", isEnabled);
                UpdateIncludingFileInBuild("ApphudUnityFacebookWrapper", "Plugins/iOS", isEnabled);
                UpdateIncludingFileInBuild("ApphudFacebookIOSDependencies", "Editor", isEnabled);
            }
            else
            {
                UpdateIncludingFileInBuild("ApphudFacebookAndroidDependencies", "Editor", isEnabled);
            }

            if (isEnabled)
            {
                AddFacebookSDKDefine(namedBuildTarget);
            }
            else
            {
                RemoveFacebookSDKDefine(namedBuildTarget);
            }

            AssetDatabase.Refresh();
        }

        private static void UpdateIncludingFileInBuild(string name, string includeFolderPath, bool isIncluded)
        {
            string rootFodler = "Assets/Apphud";

            string asset = AssetDatabase.FindAssets(name)[0];
            string path = AssetDatabase.GUIDToAssetPath(asset);
            string fileName = Path.GetFileName(path);

            string targetFolder = $"{rootFodler}/{includeFolderPath}";

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            string targetPath = $"{targetFolder}/{fileName}";

            if (isIncluded)
            {
                File.Copy(path, targetPath);
            }
            else
            {
                File.Delete(targetPath);
            }
        }

        private static bool CheckFacebookSDKDefine(NamedBuildTarget namedBuildTarget)
        {
            return PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget).Contains("APPHUD_FB");
        }

        private static void AddFacebookSDKDefine(NamedBuildTarget namedBuildTarget)
        {
            string newDefines = string.Join(";", new[]{
                PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget),
                "APPHUD_FB"
            });
            PlayerSettings.SetScriptingDefineSymbols(namedBuildTarget, newDefines);
        }

        private static void RemoveFacebookSDKDefine(NamedBuildTarget namedBuildTarget)
        {
            string defines = PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget);
            defines = defines.Replace("APPHUD_FB", "");

            PlayerSettings.SetScriptingDefineSymbols(namedBuildTarget, defines);
        }
    }
}
