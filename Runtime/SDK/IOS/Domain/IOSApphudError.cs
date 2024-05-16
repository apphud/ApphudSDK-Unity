#if UNITY_IOS

using Apphud.Unity.Domain;

namespace Apphud.Unity.IOS.Domain
{
    internal sealed class IOSApphudError : ApphudError
    {
        internal IOSApphudError(string error)
        {
            Message = error;
        }
    }
}

#endif