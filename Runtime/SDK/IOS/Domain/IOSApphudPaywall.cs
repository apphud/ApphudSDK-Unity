#if UNITY_IOS

using System.Collections.Generic;
using Apphud.Unity.Domain;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Apphud.Unity.IOS.Domain
{
    [Preserve]
    internal sealed class IOSApphudPaywallJson
    {
        public string name;
        public string identifier;
        public string variationName;
        public string experimentName;
        public string fromPaywall;
        public List<IOSApphudProductJson> items;
        public string json;

        [JsonProperty("default")]
        public bool isDefault;
    }

    internal sealed class IOSApphudPaywall : ApphudPaywall
    {
        internal IOSApphudPaywall(IOSApphudPaywallJson json, string placementIdentifier)
        {
            Name = json.name;
            Identifier = json.identifier;
            Default = json.isDefault;
            ExperimentName = json.experimentName;
            VariationName = json.variationName;
            ParentPaywallIdentifier = json.fromPaywall;
            PlacementIdentifier = placementIdentifier;

            Products = new List<ApphudProduct>();

            for (int i = 0; i < json.items.Count; i++)
            {
                Products.Add(new IOSApphudProduct(json.items[i], Identifier, PlacementIdentifier));
            }

            Json = json.json != null ? JsonConvert.DeserializeObject<Dictionary<string, object>>(json.json) : null;
        }
    }
}

#endif