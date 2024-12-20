#if UNITY_ANDROID

using System;
using System.Collections.Generic;
using Apphud.Unity.Domain;
using Apphud.Unity.Common;

namespace Apphud.Unity.Android.SDK
{
    public sealed class ApphudAndroidSDK : IApphudSDK
    {
        public string UserId => ApphudAndroidInternal.UserId;
        public string DeviceId => ApphudAndroidInternal.DeviceId;

        public ApphudAndroidSDK()
        {
            ApphudAndroidInternal.SetHeaders();
        }

        public void Start(string apiKey, Action<ApphudUser> callback, bool observerMode) => ApphudAndroidInternal.Start(apiKey, callback, observerMode);
        public void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode) => ApphudAndroidInternal.Start(apiKey, userId, callback, observerMode);

        public void DeferPlacements() => ApphudAndroidInternal.DeferPlacements();
        public void ForceFlushUserProperties(Action<bool> completion) => ApphudAndroidInternal.ForceFlushUserProperties(completion);

        public void LogOut() => ApphudAndroidInternal.LogOut();
        public void UpdateUserId(string userId) => ApphudAndroidInternal.UpdateUserId(userId, (user) => { });

        public void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int maxAttempts) => ApphudAndroidInternal.FetchPlacements(callback, maxAttempts);

        public void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int maxAttempts) => ApphudAndroidInternal.PaywallsDidLoadCallback(callback, maxAttempts);

        public List<ApphudSubscription> Subscriptions() => ApphudAndroidInternal.Subscriptions();

        public List<ApphudNonRenewingPurchase> NonRenewingPurchases() => ApphudAndroidInternal.NonRenewingPurchases();

        public void PaywallShown(ApphudPaywall paywall) => ApphudAndroidInternal.PaywallShown(paywall);

        public void PaywallClosed(ApphudPaywall paywall) => ApphudAndroidInternal.PaywallClosed(paywall);

        public void Purchase(ApphudProduct product, string offerIdToken = null, string oldToken = null, int? replacementMode = null, bool consumableInAppProduct = false, Action<ApphudPurchaseResult> callback = null)
        {
            ApphudAndroidInternal.Purchase(product, offerIdToken, oldToken, replacementMode, consumableInAppProduct, callback);
        }

        public void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback)
        {
            ApphudAndroidInternal.RestorePurchases(callback);
        }

        public void GrantPromotional(int daysCount, Action<bool> callback)
        {
            ApphudAndroidInternal.GrantPromotional(daysCount, callback);
        }

        public void RefreshUserData(Action<ApphudUser> callback) => ApphudAndroidInternal.RefreshUserData(callback);

        public bool HasPremiumAccess() => ApphudAndroidInternal.HasPremiumAccess();
        public bool HasActiveSubscription() => ApphudAndroidInternal.HasActiveSubscription();
        public bool IsNonRenewingPurchaseActive(string productId) => ApphudAndroidInternal.IsNonRenewingPurchaseActive(productId);

        public void EnableDebugLogs() => ApphudAndroidInternal.EnableDebugLogs();
        public void CollectDeviceIdentifiers() => ApphudAndroidInternal.CollectDeviceIdentifiers();
        public void OptOutOfTracking() => ApphudAndroidInternal.OptOutOfTracking();

        public void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce) => ApphudAndroidInternal.SetUserProperty(key, value, setOnce);

        public void IncrementUserProperty(ApphudUserPropertyKey key, object by) => ApphudAndroidInternal.IncrementUserProperty(key, by);

        public void AddAttribution(ApphudAttributionProvider provider, Dictionary<string, object> data = null, string identifier = null)
        {
            ApphudAndroidInternal.AddAttribution(provider, data, identifier);
        }

        public void AttributeFromWeb(Dictionary<string, object> data, Action<bool, ApphudUser> callback)
        {
            ApphudAndroidInternal.AttributeFromWeb(data, callback);
        }

#if APPHUD_FB
        public void AddFacebookAttribution(Action<string> onError = null)
        {
            ApphudFacebookAttribution.Add(onError);
        }
#endif
        public void LoadFallbackPaywalls(Action<List<ApphudPaywall>, ApphudError> callback)
        {
            ApphudAndroidInternal.LoadFallbackPaywalls(callback);
        }

        public bool IsFallbackMode()
        {
            return ApphudAndroidInternal.IsFallbackMode();
        }

        public void InvalidatePaywallsCache()
        {
            ApphudAndroidInternal.InvalidatePaywallsCache();
        }

        public void TrackPurchase(string productID, string offerIdToken, string paywallIdentifier, string placementIdentifier)
        {
            ApphudAndroidInternal.TrackPurchase(productID, offerIdToken, paywallIdentifier, placementIdentifier);
        }
    }
}

#endif