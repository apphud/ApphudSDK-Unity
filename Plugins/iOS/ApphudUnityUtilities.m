#import "ApphudUnityUtilities.h"
#import <Foundation/Foundation.h>

static CallbackBoolDelegate _callbackBoolDelegate = NULL;
static CallbackDelegate _callbackDelegate = NULL;
static Callback2Delegate _callback2Delegate = NULL;
static Callback3Delegate _callback3Delegate = NULL;

NSString *cstringToString(const char *str) {
    return str ? [NSString stringWithUTF8String:str] : nil;
}

const char *cstringFromString(NSString *str) {
    return str ? [str cStringUsingEncoding:NSUTF8StringEncoding] : nil;
}

char *makeStringCopy(const char *string) {
    if (string == NULL) {
        return NULL;
    }

    char *res = (char *)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

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
