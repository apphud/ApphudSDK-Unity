#if UNITY_ANDROID

using System.Collections.Generic;
using Apphud.Unity.Domain;
using UnityEngine;

namespace Apphud.Unity.Android.Domain
{
    internal sealed class AndroidApphudProduct : ApphudProduct
    {
        private static readonly Dictionary<string, AndroidJavaObject> _javaObjects = new Dictionary<string, AndroidJavaObject>();

        internal static AndroidJavaObject GetJavaObject(ApphudProduct product) => _javaObjects[product.ProductId];

        internal AndroidApphudProduct(AndroidJavaObject javaObject)
        {
            ProductId = javaObject.Get<string>("productId");
            Name = javaObject.Get<string>("name");
            Store = javaObject.Get<string>("store");
            BasePlanId = javaObject.Get<string>("basePlanId");
            PlacementIdentifier = javaObject.Get<string>("placementIdentifier");
            PaywallIdentifier = javaObject.Get<string>("paywallIdentifier");

            ProductType = javaObject.CallNullableEnum<ApphudProductType>("type");
            StoreProductId = javaObject.Call<string>("productId");
            ProductTitle = javaObject.Call<string>("title");
            ProductDescription = javaObject.Call<string>("description");
            PriceCurrencyCode = javaObject.Call<string>("priceCurrencyCode");
            PriceAmountMicros = javaObject.Call<string>("priceAmountMicros");

            OneTimePurchaseOfferDetails = javaObject.CallJavaNulableObject(
                "oneTimePurchaseOfferDetails",
                javaObject => new AndroidOneTimePurchaseOfferDetails(javaObject)
            );

            SubscriptionOfferDetails = javaObject.CallJavaNulableList<SubscriptionOfferDetails>(
                "subscriptionOfferDetails",
                (offerJavaObject) => new AndroidSubscriptionOfferDetails(offerJavaObject));

            _javaObjects[ProductId] = javaObject;
        }
    }
}

#endif