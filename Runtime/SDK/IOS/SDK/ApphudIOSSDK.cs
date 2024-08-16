#if UNITY_IOS

using System;
using System.Collections.Generic;
using Apphud.Unity.Common;
using Apphud.Unity.Common.Utils;
using Apphud.Unity.Domain;
using Apphud.Unity.IOS.Common;
using Apphud.Unity.IOS.Domain;
using Newtonsoft.Json;

namespace Apphud.Unity.IOS.SDK
{
    public sealed class ApphudIOSSDK : IApphudSDK
    {
        public string UserId => ApphudIOSInternal.ApphudUnity_getUserId();
        public string DeviceId => ApphudIOSInternal.ApphudUnity_getDeviceId();

        public ApphudIOSSDK()
        {
            IOSCallbackAction.InitializeOnce();
            ApphudIOSInternal.ApphudUnity_setHeaders();
        }

        public void Start(string apiKey, Action<ApphudUser> callback, bool observerMode)
        {
            ApphudIOSInternal.Start(apiKey, json => callback(new IOSApphudUser(json)), observerMode);
        }

        public void Start(string apiKey, string userId, Action<ApphudUser> callback, bool observerMode)
        {
            ApphudIOSInternal.Start(apiKey, userId, json => callback(new IOSApphudUser(json)), observerMode);
        }

        public void LogOut() => ApphudIOSInternal.ApphudUnity_logOut();

        public void UpdateUserId(string userId) => ApphudIOSInternal.ApphudUnity_updateUserId(userId);

        public void FetchPlacements(Action<List<ApphudPlacement>, ApphudError> callback, int maxAttempts)
        {
            ApphudIOSInternal.FetchPlacements(maxAttempts, (placementsJson, error) => callback(
                placementsJson.ToListFromJson<ApphudPlacement, IOSApphudPlacementJson>(json => new IOSApphudPlacement(json)),
                error != null ? new IOSApphudError(error) : null)
            );
        }

        public void PaywallsDidLoadCallback(Action<List<ApphudPaywall>, ApphudError> callback, int maxAttempts)
        {
            ApphudIOSInternal.PaywallsDidLoadCallback(maxAttempts, (paywallsJson, error) => callback(
                paywallsJson.ToListFromJson<ApphudPaywall, IOSApphudPaywallJson>(json => new IOSApphudPaywall(json, null)),
                error != null ? new IOSApphudError(error) : null)
            );
        }

        public List<ApphudSubscription> Subscriptions()
        {
            string json = ApphudIOSInternal.ApphudUnity_subscriptions();

            return json.ToListFromJson<ApphudSubscription, IOSApphudSubscriptionJson>(
                json => new IOSApphudSubscription(json)
            );
        }

        public List<ApphudNonRenewingPurchase> NonRenewingPurchases()
        {
            string json = ApphudIOSInternal.ApphudUnity_nonRenewingPurchases();

            return json.ToListFromJson<ApphudNonRenewingPurchase, IOSApphudNonRenewingPurchaseJson>(
                json => new IOSApphudNonRenewingPurchase(json)
            );
        }

        public void PaywallShown(ApphudPaywall paywall)
        {
            ApphudIOSInternal.ApphudUnity_paywallShown(paywall.Identifier, paywall.PlacementIdentifier);
        }

        public void PaywallClosed(ApphudPaywall paywall)
        {
            ApphudIOSInternal.ApphudUnity_paywallClosed(paywall.Identifier, paywall.PlacementIdentifier);
        }

        public void Purchase(ApphudProduct product, string offerIdToken = null, string oldToken = null, int? replacementMode = null, bool consumableInAppProduct = false, Action<ApphudPurchaseResult> callback = null)
        {
            ApphudIOSInternal.Purchase(
                product.ProductId,
                product.PlacementIdentifier,
                product.PaywallIdentifier,
                (json) => callback?.Invoke(new IOSApphudPurchaseResult(json))
            );
        }

        public void RestorePurchases(Action<List<ApphudSubscription>, List<ApphudNonRenewingPurchase>, ApphudError> callback)
        {
            ApphudIOSInternal.RestorePurchases((subscriptionsJson, nonRenewingPurchasesJson, error) =>
            {
                callback(
                    subscriptionsJson.ToListFromJson<ApphudSubscription, IOSApphudSubscriptionJson>(
                    json => new IOSApphudSubscription(json)
                    ),
                    nonRenewingPurchasesJson.ToListFromJson<ApphudNonRenewingPurchase, IOSApphudNonRenewingPurchaseJson>(
                        json => new IOSApphudNonRenewingPurchase(json)
                    ),
                    error != null ? new IOSApphudError(error) : null
                );
            });
        }

        public void GrantPromotional(int daysCount, string productId, ApphudGroup permissionGroup, Action<bool> callback)
        {
            ApphudIOSInternal.GrantPromotional(daysCount, productId, callback);
        }

        public bool HasPremiumAccess() => ApphudIOSInternal.ApphudUnity_hasPremiumAccess();

        public bool HasActiveSubscription() => ApphudIOSInternal.ApphudUnity_hasActiveSubscription();

        public bool IsNonRenewingPurchaseActive(string productId) => ApphudIOSInternal.ApphudUnity_isNonRenewingPurchaseActive(productId);

        public void EnableDebugLogs()
        {
            IOSCallbackAction.DebugLogsEnabled = true;
            ApphudIOSInternal.ApphudUnity_enableDebugLogs();
        }

        public void OptOutOfTracking() => ApphudIOSInternal.ApphudUnity_optOutOfTracking();

        public void SetUserProperty(ApphudUserPropertyKey key, object value, bool setOnce)
        {
            ApphudIOSInternal.ApphudUnity_setUserProperty(key.key, value.ToIOSAnyJson(), setOnce);
        }

        public void IncrementUserProperty(ApphudUserPropertyKey key, object by)
        {
            ApphudIOSInternal.ApphudUnity_incrementUserProperty(key.key, by.ToIOSAnyJson());
        }

        public void AddAttribution(ApphudAttributionProvider provider, Dictionary<string, object> data = null, string identifer = null)
        {
            string jsonData = null;

            if (data != null)
            {
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                jsonData = JsonConvert.SerializeObject(data, Formatting.Indented, serializerSettings);
            }

            ApphudIOSInternal.AddAttribution(provider, jsonData, identifer, status => { });
        }

#if APPHUD_FB
        public void AddFacebookAttribution(Action<string> onError)
        {
            ApphudIOSInternal.AddFBAttribution((status) => { });
        }
#endif

        public void TrackAppleSearchAds()
        {
            ApphudIOSInternal.TrackAppleSearchAds(status => { });
        }

        public void LoadFallbackPaywalls(Action<List<ApphudPaywall>, ApphudError> callback)
        {
            ApphudIOSInternal.LoadFallbackPaywallsWithCallback((paywallsJson, error) => callback(
                paywallsJson.ToListFromJson<ApphudPaywall, IOSApphudPaywallJson>(json => new IOSApphudPaywall(json, null)),
                error != null ? new IOSApphudError(error) : null)
            );
        }

        public void InvalidatePaywallsCache()
        {
            ApphudIOSInternal.ApphudUnity_setPaywallsCacheTimeout(0);
        }

        public void SetDeviceIdentifiers(string idfa, string idfv)
        {
            ApphudIOSInternal.ApphudUnity_setDeviceIdentifiers(idfa, idfv);
        }

        public void SubmitPushNotificationsTokenString(string str, Action<bool> callback)
        {
            ApphudIOSInternal.SubmitPushNotificationsTokenString(str, callback);
        }

        public void WillPurchaseProductFrom(string paywallIdentifier, string placementIdentifier)
        {
            ApphudIOSInternal.ApphudUnity_willPurchaseProductFrom(paywallIdentifier, placementIdentifier);
        }
    }
}

#endif