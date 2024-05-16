@import ApphudSDK;

#import <Foundation/Foundation.h>
#include "ApphudUnityPluginCallback.h"
#include "UnityFramework/UnityFramework-Swift.h"

static NSString * cstringToString(const char *str) {
    return str ? [NSString stringWithUTF8String:str] : nil;
}

static const char * cstringFromString(NSString *str) {
    return str ? [str cStringUsingEncoding:NSUTF8StringEncoding] : nil;
}

static char * makeStringCopy(const char *string) {
    if (string == NULL) {
        return NULL;
    }

    char *res = (char *)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

static CallbackBoolDelegate _callbackBoolDelegate = NULL;
static CallbackDelegate _callbackDelegate = NULL;
static Callback2Delegate _callback2Delegate = NULL;
static Callback3Delegate _callback3Delegate = NULL;

void SendCallbackBoolToUnity(UnityAction action, bool data) {
    if (action == NULL) {
        return;
    }

    dispatch_async(dispatch_get_main_queue(), ^{
        if (_callbackBoolDelegate != NULL) {
            _callbackBoolDelegate(action, data);
        }
    });
}

void SendCallbackToUnity(UnityAction action, NSString *data) {
    if (action == NULL) {
        return;
    }

    dispatch_async(dispatch_get_main_queue(), ^{
        if (_callbackDelegate != NULL) {
            _callbackDelegate(action, cstringFromString(data));
        }
    });
}

void SendCallback2ToUnity(UnityAction action, NSString *data, NSString *data2) {
    if (action == NULL) {
        return;
    }

    dispatch_async(dispatch_get_main_queue(), ^{
        if (_callback2Delegate != NULL) {
            _callback2Delegate(action, cstringFromString(data), cstringFromString(data2));
        }
    });
}

void SendCallback3ToUnity(UnityAction action, NSString *data, NSString *data2, NSString *data3) {
    if (action == NULL) {
        return;
    }

    dispatch_async(dispatch_get_main_queue(), ^{
        if (_callback3Delegate != NULL) {
            _callback3Delegate(action, cstringFromString(data), cstringFromString(data2), cstringFromString(data3));
        }
    });
}

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_registerCallbackHandler(CallbackBoolDelegate callbackBoolDelegate,CallbackDelegate callbackDelegate, Callback2Delegate callback2Delegate, Callback3Delegate callback3Delegate) {
    _callbackBoolDelegate = callbackBoolDelegate;
    _callbackDelegate = callbackDelegate;
    _callback2Delegate = callback2Delegate;
    _callback3Delegate = callback3Delegate;
}

#ifdef __cplusplus
}
#endif

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
    [ApphudUnityWrapper startWithApiKey:cstringToString(apiKey) userID:cstringToString(userId) observerMode:observerMode callback:^(NSString * _Nonnull result) {
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
    [ApphudUnityWrapper startWithApiKey:cstringToString(apiKey) observerMode:observerMode callback:^(NSString * _Nonnull result) {
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
    [ApphudUnityWrapper fetchPlacementsWithMaxAttempts:maxAttempts callback:^(NSString * _Nonnull placements, NSString * _Nullable error) {
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
    [ApphudUnityWrapper paywallsDidLoadCallbackWithMaxAttempts:maxAttempts callback:^(NSString * _Nonnull paywalls, NSString * _Nullable error) {
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
    return makeStringCopy(cstringFromString([ApphudUnityWrapper subscriptions]));
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

const char * ApphudUnity_nonRenewingPurchases(void) {
    return makeStringCopy(cstringFromString([ApphudUnityWrapper nonRenewingPurchases]));
}

#ifdef __cplusplus
}
#endif


#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_paywallShown(const char *paywallIdentifier, const char *placementIdentifier) {
    [ApphudUnityWrapper paywallShownWithIdentifier:cstringToString(paywallIdentifier) placementIdentifier:cstringToString(placementIdentifier)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_paywallClosed(const char *paywallIdentifier, const char *placementIdentifier) {
    [ApphudUnityWrapper paywallClosedWithIdentifier:cstringToString(paywallIdentifier) placementIdentifier:cstringToString(placementIdentifier)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_purchase(const char *productId,const char *placementIdentifier,const char *paywallIdentifier, UnityAction callback) {
    [ApphudUnityWrapper purchaseWithProductId:cstringToString(productId) placementIdentifier:cstringToString(placementIdentifier) paywallIdentifier:cstringToString(paywallIdentifier) callback:^(NSString * _Nonnull purchaseResult) {
        SendCallbackToUnity(callback, purchaseResult);
    }];
}
    
#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_restorePurchases(UnityAction callback) {
    [ApphudUnityWrapper restorePurchasesWithCallback:^(NSString * _Nullable subscriptions, NSString * _Nullable nonRenewingPurchases, NSString * _Nullable error) {
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
    return [ApphudUnityWrapper isNonRenewingPurchaseActiveWithProductIdentifier:cstringToString(productId)];
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
    [ApphudUnityWrapper setUserPropertyWithKey:cstringToString(key) valueJson:cstringToString(valueJson) setOnce:setOnce];
}

#ifdef __cplusplus
}
#endif


#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_incrementUserProperty(const char *key, const char *byJson) {
    [ApphudUnityWrapper incrementUserPropertyWithKey:cstringToString(key) byJson:cstringToString(byJson)];
}

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_addAttribution(const char *provider, const char *dataJson, const char *identifer) {
    [ApphudUnityWrapper addAttributionWithProvider:cstringToString(provider) dataJson:cstringToString(dataJson) identifer:cstringToString(identifer)];
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
    [ApphudUnityWrapper setHeaders];
}

#ifdef __cplusplus
}
#endif