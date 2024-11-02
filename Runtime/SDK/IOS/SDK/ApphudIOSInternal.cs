using System;
using System.Runtime.InteropServices;
using Apphud.Unity.Common.Utils;
using Apphud.Unity.Domain;

namespace Apphud.Unity.IOS.SDK
{
    internal static class ApphudIOSInternal
    {

        [DllImport("__Internal")]
        internal static extern string ApphudUnity_getUserId();

        [DllImport("__Internal")]
        internal static extern string ApphudUnity_getDeviceId();

        [DllImport("__Internal")]
        private static extern void ApphudUnity_startWithApiKey(string apiKey, bool observerMode, IntPtr callback);
        internal static void Start(string apiKey, Action<string> callback, bool observerMode) => ApphudUnity_startWithApiKey(apiKey, observerMode, callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_startWithApiKeyAndUserId(string apiKey, string userId, bool observerMode, IntPtr callback);
        internal static void Start(string apiKey, string userId, Action<string> callback, bool observerMode) => ApphudUnity_startWithApiKeyAndUserId(apiKey, userId, observerMode, callback.ToIntPtr());

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_deferPlacements();

        [DllImport("__Internal")]
        private static extern void ApphudUnity_forceFlushUserProperties(IntPtr callback);
        internal static void ForceFlushUserProperties(Action<bool> completion) => ApphudUnity_forceFlushUserProperties(completion.ToIntPtr());

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_logOut();

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_updateUserId(string userId);

        [DllImport("__Internal")]
        private static extern void ApphudUnity_fetchPlacementsWithCallback(int maxAttempts, IntPtr callback);
        internal static void FetchPlacements(int maxAttempts, Action<string, string> callback) => ApphudUnity_fetchPlacementsWithCallback(maxAttempts, callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_paywallsDidLoadCallback(int maxAttempts, IntPtr callback);
        internal static void PaywallsDidLoadCallback(int maxAttempts, Action<string, string> callback) => ApphudUnity_paywallsDidLoadCallback(maxAttempts, callback.ToIntPtr());

        [DllImport("__Internal")]
        internal static extern string ApphudUnity_subscriptions();

        [DllImport("__Internal")]
        internal static extern string ApphudUnity_nonRenewingPurchases();

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_paywallShown(string placementIdentifier, string paywallIdentifier);

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_paywallClosed(string placementIdentifier, string paywallIdentifier);

        [DllImport("__Internal")]
        private static extern void ApphudUnity_purchase(string productId, string placementIdentifier, string paywallIdentifier, IntPtr callback);
        internal static void Purchase(string productId, string placementIdentifier, string paywallIdentifier, Action<string> callback) => ApphudUnity_purchase(productId, placementIdentifier, paywallIdentifier, callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_restorePurchases(IntPtr callback);
        internal static void RestorePurchases(Action<string, string, string> callback) => ApphudUnity_restorePurchases(callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_grantPromotional(int daysCount, string productId, IntPtr callback);
        internal static void GrantPromotional(int daysCount, string productId, Action<bool> callback) => ApphudUnity_grantPromotional(daysCount, productId, callback.ToIntPtr());

        [DllImport("__Internal")]
        internal static extern bool ApphudUnity_hasPremiumAccess();

        [DllImport("__Internal")]
        internal static extern bool ApphudUnity_hasActiveSubscription();

        [DllImport("__Internal")]
        internal static extern bool ApphudUnity_isNonRenewingPurchaseActive(string productId);

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_enableDebugLogs();

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_enableAllLogs();

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_optOutOfTracking();

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_setUserProperty(string key, string valueJson, bool setOnce);

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_incrementUserProperty(string key, string byJson);

        [DllImport("__Internal")]
        private static extern void ApphudUnity_addAttribution(string provider, string dataJson, string identifer, IntPtr callback);
        internal static void AddAttribution(ApphudAttributionProvider provider, string dataJson, string identifer, Action<bool> callback) => ApphudUnity_addAttribution(provider.ToString(), dataJson, identifer, callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_attributeFromWeb(string dataJson, IntPtr callback);
        internal static void AttributeFromWeb(string dataJson, Action<bool, string> callback) => ApphudUnity_attributeFromWeb(dataJson, callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_addFBAttribution(IntPtr callback);
        internal static void AddFBAttribution(Action<bool> callback) => ApphudUnity_addFBAttribution(callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_trackAppleSearchAds(IntPtr callback);
        internal static void TrackAppleSearchAds(Action<bool> callback) => ApphudUnity_trackAppleSearchAds(callback.ToIntPtr());

        [DllImport("__Internal")]
        private static extern void ApphudUnity_loadFallbackPaywallsWithCallback(IntPtr callback);
        internal static void LoadFallbackPaywallsWithCallback(Action<string, string> callback) => ApphudUnity_loadFallbackPaywallsWithCallback(callback.ToIntPtr());

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_willPurchaseProductFrom(string paywallIdentifier, string placementIdentifier);

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_setDeviceIdentifiers(string idfa, string idfv);

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_setPaywallsCacheTimeout(double value);

        [DllImport("__Internal")]
        private static extern void ApphudUnity_submitPushNotificationsTokenString(string str, IntPtr callback);
        internal static void SubmitPushNotificationsTokenString(string str, Action<bool> callback) => ApphudUnity_submitPushNotificationsTokenString(str, callback.ToIntPtr());

        [DllImport("__Internal")]
        internal static extern void ApphudUnity_setHeaders();
    }
}