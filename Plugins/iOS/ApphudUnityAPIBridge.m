@import ApphudSDK;

#import <Foundation/Foundation.h>
#import "UnityFramework/UnityFramework-Swift.h"
#import "ApphudUnityUtilities.h"

#ifdef __cplusplus
extern "C" {
#endif

const char * ApphudUnity_getUserId(void) {
    return makeStringCopy(cstringFromString([Apphud userID]));
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

const char * ApphudUnity_getDeviceId(void) {
    return makeStringCopy(cstringFromString([Apphud deviceID]));
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_startWithApiKeyAndUserId(const char *apiKey,const char *userId, BOOL observerMode, UnityAction callback) {
    [ApphudUnityAPIWrapper startWithApiKey:cstringToString(apiKey) userID:cstringToString(userId) observerMode:observerMode callback:^(NSString * _Nonnull result) {
        SendCallbackToUnity(callback, result);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_startWithApiKey(const char *apiKey, BOOL observerMode, UnityAction callback) {
    [ApphudUnityAPIWrapper startWithApiKey:cstringToString(apiKey) observerMode:observerMode callback:^(NSString * _Nonnull result) {
        SendCallbackToUnity(callback, result);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_logOut(void) {
    [Apphud logoutWithCompletionHandler:^{}];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_updateUserId(const char *userId) {
    [Apphud updateUserID:cstringToString(userId)];
}

#ifdef __cplusplus
}
#endif


#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_fetchPlacementsWithCallback(int maxAttempts, UnityAction callback) {
    [ApphudUnityAPIWrapper fetchPlacementsWithMaxAttempts:maxAttempts callback:^(NSString * _Nonnull placements, NSString * _Nullable error) {
        SendCallback2ToUnity(callback, placements, error);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_paywallsDidLoadCallback(int maxAttempts, UnityAction callback) {
    [ApphudUnityAPIWrapper paywallsDidLoadCallbackWithMaxAttempts:maxAttempts callback:^(NSString * _Nonnull paywalls, NSString * _Nullable error) {
        SendCallback2ToUnity(callback, paywalls, error);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

const char * ApphudUnity_subscriptions(void) {
    return makeStringCopy(cstringFromString([ApphudUnityAPIWrapper subscriptions]));
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

const char * ApphudUnity_nonRenewingPurchases(void) {
    return makeStringCopy(cstringFromString([ApphudUnityAPIWrapper nonRenewingPurchases]));
}

#ifdef __cplusplus
}
#endif


#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_paywallShown(const char *paywallIdentifier, const char *placementIdentifier) {
    [ApphudUnityAPIWrapper paywallShownWithIdentifier:cstringToString(paywallIdentifier) placementIdentifier:cstringToString(placementIdentifier)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_paywallClosed(const char *paywallIdentifier, const char *placementIdentifier) {
    [ApphudUnityAPIWrapper paywallClosedWithIdentifier:cstringToString(paywallIdentifier) placementIdentifier:cstringToString(placementIdentifier)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_purchase(const char *productId,const char *placementIdentifier,const char *paywallIdentifier, UnityAction callback) {
    [ApphudUnityAPIWrapper purchaseWithProductId:cstringToString(productId) placementIdentifier:cstringToString(placementIdentifier) paywallIdentifier:cstringToString(paywallIdentifier) callback:^(NSString * _Nonnull purchaseResult) {
        SendCallbackToUnity(callback, purchaseResult);
    }];
}
    
#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_restorePurchases(UnityAction callback) {
    [ApphudUnityAPIWrapper restorePurchasesWithCallback:^(NSString * _Nullable subscriptions, NSString * _Nullable nonRenewingPurchases, NSString * _Nullable error) {
        SendCallback3ToUnity(callback, subscriptions, nonRenewingPurchases, error);
    }];
}

#ifdef __cplusplus
}
#endif
    
#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_grantPromotional(int daysCount, const char *productId, UnityAction callback) {
    [Apphud grantPromotionalWithDaysCount:daysCount productId:cstringToString(productId) permissionGroup:Nil callback:^(BOOL value) {
        SendCallbackBoolToUnity(callback, value);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

bool ApphudUnity_hasPremiumAccess(void) {
    return [Apphud hasPremiumAccess];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

bool ApphudUnity_hasActiveSubscription(void) {
    return [Apphud hasActiveSubscription];
}

#ifdef __cplusplus
}
#endif


#ifdef __cplusplus
extern "C" {
#endif

bool ApphudUnity_isNonRenewingPurchaseActive(const char *productId) {
    return [ApphudUnityAPIWrapper isNonRenewingPurchaseActiveWithProductIdentifier:cstringToString(productId)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_enableDebugLogs(void) {
    [Apphud enableDebugLogs];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_enableAllLogs(void) {
    [ApphudUtils enableAllLogs];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_optOutOfTracking(void) {
    [Apphud optOutOfTracking];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_setUserProperty(const char *key, const char *valueJson, bool setOnce ) {
    [ApphudUnityAPIWrapper setUserPropertyWithKey:cstringToString(key) valueJson:cstringToString(valueJson) setOnce:setOnce];
}

#ifdef __cplusplus
}
#endif


#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_incrementUserProperty(const char *key, const char *byJson) {
    [ApphudUnityAPIWrapper incrementUserPropertyWithKey:cstringToString(key) byJson:cstringToString(byJson)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_addAttribution(const char *provider, const char *dataJson, const char *identifer, UnityAction callback) {
    [ApphudUnityAPIWrapper addAttributionWithProvider:cstringToString(provider) dataJson:cstringToString(dataJson) identifer:cstringToString(identifer) callback:^(BOOL value) {
        SendCallbackBoolToUnity(callback, value);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_loadFallbackPaywallsWithCallback(UnityAction callback) {
    [ApphudUnityAPIWrapper loadFallbackPaywallsWithCallback: ^(NSString * _Nonnull paywalls, NSString * _Nullable error) {
        SendCallback2ToUnity(callback, paywalls, error);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_setDeviceIdentifiers(const char *idfa, const char *idfv) {
    [Apphud setDeviceIdentifiersWithIdfa:cstringToString(idfa) idfv:cstringToString(idfv)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_setHeaders() {
    [ApphudUnityAPIWrapper setHeaders];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_setPaywallsCacheTimeout(double value) {
    [Apphud setPaywallsCacheTimeout:value];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_submitPushNotificationsTokenString(const char *string, UnityAction callback) {
    [Apphud submitPushNotificationsTokenStringWithString:cstringToString(string) callback:^(BOOL value) {
        SendCallbackBoolToUnity(callback, value);
    }];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_willPurchaseProductFrom(const char *paywallIdentifier, const char *placementIdentifier) {
    [Apphud willPurchaseProductFromPaywallIdentifier:cstringToString(paywallIdentifier) placementIdentifier:cstringToString(placementIdentifier)];
}

#ifdef __cplusplus
}
#endif
