#if UNITY_IOS

using System.Collections.Generic;
using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudPlacementJson
    {
        public List<IOSApphudPaywallJson> paywalls;
        public string identifier;
    }

    internal sealed class IOSApphudPlacement : ApphudPlacement
    {
        internal IOSApphudPlacement(IOSApphudPlacementJson json)
        {
            Identifier = json.identifier;
            Paywall = json.paywalls.Count > 0 ? new IOSApphudPaywall(json.paywalls[0], Identifier) : null;
        }
    }
}

#endif