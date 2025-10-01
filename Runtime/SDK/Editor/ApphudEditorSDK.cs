#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using Apphud.Unity.Domain;
using Apphud.Unity.Common;

namespace Apphud.Unity.Editor
{
    public sealed class ApphudEditorSDK : IApphudSDK
    {
        public string UserId
        {
            get
            {
                ApphudEditorUtils.LogNotSupportedWarning();
                return null;
            }
        }

        public string DeviceId
        {
            get
            {
                ApphudEditorUtils.LogNotSupportedWarning();
                return null;
            }
        }

        public void Start(string apiKey, Action<ApphudUser> callback, bool observerMode) => ApphudEditorUtils.LogNotSupportedWarning();
        public void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode) => ApphudEditorUtils.LogNotSupportedWarning();

        public void DeferPlacements() => ApphudEditorUtils.LogNotSupportedWarning();
        public void ForceFlushUserProperties(Action<bool> completion) => ApphudEditorUtils.LogNotSupportedWarning();

        public void LogOut() => ApphudEditorUtils.LogNotSupportedWarning();
        public void UpdateUserId(string userId) => ApphudEditorUtils.LogNotSupportedWarning();

        public void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int maxAttempts) => ApphudEditorUtils.LogNotSupportedWarning();

        public void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int maxAttempts) => ApphudEditorUtils.LogNotSupportedWarning();

        public List<ApphudSubscription> Subscriptions()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
            return null;
        }

        public List<ApphudNonRenewingPurchase> NonRenewingPurchases()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
            return null;
        }

        public void PaywallShown(ApphudPaywall paywall) => ApphudEditorUtils.LogNotSupportedWarning();

        public void PaywallClosed(ApphudPaywall paywall) => ApphudEditorUtils.LogNotSupportedWarning();

        public void Purchase(ApphudProduct product, string offerIdToken = null, string oldToken = null, int? replacementMode = null, bool consumableInAppProduct = false, Action<ApphudPurchaseResult> callback = null)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void GrantPromotional(int daysCount, Action<bool> callback)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void RefreshUserData(Action<ApphudUser> callback) => ApphudEditorUtils.LogNotSupportedWarning();

        public bool HasPremiumAccess()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
            return false;
        }

        public bool HasActiveSubscription()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
            return false;
        }

        public bool IsNonRenewingPurchaseActive(string productId)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
            return false;
        }

        public void EnableDebugLogs() => ApphudEditorUtils.LogNotSupportedWarning();
        public void CollectDeviceIdentifiers() => ApphudEditorUtils.LogNotSupportedWarning();
        public void OptOutOfTracking() => ApphudEditorUtils.LogNotSupportedWarning();

        public void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce) => ApphudEditorUtils.LogNotSupportedWarning();

        public void IncrementUserProperty(ApphudUserPropertyKey key, object by) => ApphudEditorUtils.LogNotSupportedWarning();

        public void SetAttribution(ApphudAttributionProvider provider, ApphudAttributionData data = null, string identifier = null)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void AttributeFromWeb(Dictionary<string, object> data, Action<bool, ApphudUser> callback)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

#if APPHUD_FB
        public void AddFacebookAttribution(Action<string> onError = null)
        {
            string warning = ApphudEditorUtils.LogNotSupportedWarning();
            onError?.Invoke(warning);
        }
#endif

        public void LoadFallbackPaywalls(Action<List<ApphudPaywall>, ApphudError> callback)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void TrackAppleSearchAds()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void SetDeviceIdentifiers(string idfa, string idfv)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public bool IsFallbackMode()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
            return false;
        }

        public void InvalidatePaywallsCache()
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void SubmitPushNotificationsTokenString(string str, Action<bool> callback)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void WillPurchaseProductFrom(string paywallIdentifier, string placementIdentifier)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }

        public void TrackPurchase(string productID, string offerIdToken, string paywallIdentifier, string placementIdentifier)
        {
            ApphudEditorUtils.LogNotSupportedWarning();
        }
    }
}

#endif