#if UNITY_IOS

using System.Collections.Generic;
using Apphud.Unity.Domain;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudPaywallJson
    {
        public string identifier;
        public string variationName;
        public string experimentName;
        public string parentPaywallIdentifier;
        public IOSApphudProductJson[] products;
        public Dictionary<string, object> json;
        public bool isDefault;
    }

    internal sealed class IOSApphudPaywall : ApphudPaywall
    {
        internal IOSApphudPaywall(IOSApphudPaywallJson json, string placementIdentifier)
        {
            Identifier = json.identifier;
            Default = json.isDefault;
            ExperimentName = json.experimentName;
            VariationName = json.variationName;
            ParentPaywallIdentifier = json.parentPaywallIdentifier;
            PlacementIdentifier = placementIdentifier;

            Products = new List<ApphudProduct>();

            for (int i = 0; i < json.products.Length; i++)
            {
                Products.Add(new IOSApphudProduct(json.products[i], Identifier, PlacementIdentifier));
            }

            Json = json.json;
        }
    }
}

#endif