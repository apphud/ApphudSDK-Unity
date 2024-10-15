#if UNITY_IOS

using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudPlacementJson
    {
        public IOSApphudPaywallJson paywall;
        public string identifier;
    }

    internal sealed class IOSApphudPlacement : ApphudPlacement
    {
        internal IOSApphudPlacement(IOSApphudPlacementJson json)
        {
            Identifier = json.identifier;
            Paywall = json.paywall != null ? new IOSApphudPaywall(json.paywall, Identifier) : null;
        }
    }
}

#endif