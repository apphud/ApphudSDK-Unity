#if UNITY_ANDROID

using System.Collections.Generic;
using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudPaywall : ApphudPaywall
    {
        private static readonly Dictionary<string, AndroidJavaObject> _javaObjects = new Dictionary<string, AndroidJavaObject>();

        internal static AndroidJavaObject GetJavaObject(ApphudPaywall paywall) => _javaObjects[paywall.Identifier];

        internal AndroidApphudPaywall(AndroidJavaObject javaObject)
        {
            Name = javaObject.Get<string>("name");
            Identifier = javaObject.Get<string>("identifier");
            Default = javaObject.Get<bool>("default");
            ExperimentName = javaObject.Get<string>("experimentName");
            Products = new JavaList<ApphudProduct>(
                javaObject.Get<AndroidJavaObject>("products"),
                javaApphudProduct => new AndroidApphudProduct(javaApphudProduct)
            );
            Json = javaObject.GetDictionary<string, string, AndroidJavaObject, object>("json", key => key, value => value.ToObject());
            VariationName = javaObject.Get<string>("variationName");
            ParentPaywallIdentifier = javaObject.Get<string>("parentPaywallIdentifier");
            PlacementIdentifier = javaObject.Get<string>("placementIdentifier");

            _javaObjects[Identifier] = javaObject;
        }
    }
}

#endif