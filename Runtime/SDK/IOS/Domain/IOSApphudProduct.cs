#if UNITY_IOS

using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudProductJson
    {
        public string productId;
        public string name;
        public string store;
        public SKProduct skProduct;
    }

    internal sealed class IOSApphudProduct : ApphudProduct
    {
        internal IOSApphudProduct(IOSApphudProductJson json, string paywallIdentifier, string placementIdentifier)
        {
            ProductId = json.productId;
            Name = json.name;
            Store = json.store;
            PaywallIdentifier = paywallIdentifier;
            PlacementIdentifier = placementIdentifier;
            SKProduct = json.skProduct;
        }
    }
}

#endif