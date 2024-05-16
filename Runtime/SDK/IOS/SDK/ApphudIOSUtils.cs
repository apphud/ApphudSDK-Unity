using Apphud.Unity.IOS.Common;

namespace Apphud.Unity.IOS.SDK
{
    public sealed class ApphudIOSUtils : IApphudUtils
    {
        public void EnableAllLogs() => ApphudIOSInternal.ApphudUnity_enableAllLogs();

        public ApphudIOSUtils()
        {
            IOSCallbackAction.InitializeOnce();
        }
    }
}