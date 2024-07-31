using System;
using System.Collections.Generic;
using Apphud.Unity.Domain;

namespace Apphud.Unity.Common
{
    public interface IApphudSDK
    {
        string UserId { get; }
        string DeviceId { get; }
        void Start(string apiKey, Action<ApphudUser> callback, bool observerMode);
        void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode);
        void LogOut();
        void UpdateUserId(string userId);

        void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int maxAttempts);
        void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int maxAttempts);
        List<ApphudSubscription> Subscriptions();
        List<ApphudNonRenewingPurchase> NonRenewingPurchases();
        void PaywallShown(ApphudPaywall paywall);
        void PaywallClosed(ApphudPaywall paywall);
        void Purchase(ApphudProduct product, string offerIdToken = null, string oldToken = null, int? replacementMode = null, bool consumableInAppProduct = false, Action<ApphudPurchaseResult> callback = null);
        void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback);
        void GrantPromotional(int daysCount, string productId, ApphudGroup permissionGroup, Action<bool> callback);

        bool HasPremiumAccess();
        bool HasActiveSubscription();
        bool IsNonRenewingPurchaseActive(string productId);
        void EnableDebugLogs();

        void OptOutOfTracking();
        void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce);
        void IncrementUserProperty(ApphudUserPropertyKey key, object by);
        void AddAttribution(ApphudAttributionProvider provider, Dictionary<string, object> data = null, string identifier = null);
#if APPHUD_FB
        void AddFacebookAttribution();
#endif
        void LoadFallbackPaywalls(Action<List<ApphudPaywall>, ApphudError> callback);

#if UNITY_ANDROID
        bool IsFallbackMode();
        void RefreshUserData();
        void CollectDeviceIdentifiers();
        void InvalidatePaywallsCache();
        void TrackPurchase(string productID, string offerIdToken, string paywallIdentifier, string placementIdentifier);
#elif UNITY_IOS
        void TrackAppleSearchAds();
        void WillPurchaseProductFrom(string paywallIdentifier, string placementIdentifier);
        void SetDeviceIdentifiers(string idfa, string idfv);
        void SetPaywallsCacheTimeout(double value);
        void SubmitPushNotificationsTokenString(string str, Action<bool> callback);
#endif
    }
}