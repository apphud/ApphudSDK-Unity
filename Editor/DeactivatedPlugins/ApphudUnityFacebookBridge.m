#import "UnityFramework/UnityFramework-Swift.h"
#import "ApphudUnityUtilities.h"

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_addFBAttribution(UnityAction callback) {
    [ApphudUnityFacebookWrapper addFBAttributionWithCallback:^(BOOL value) {
        SendCallbackBoolToUnity(callback, value);
    }];
}

#ifdef __cplusplus
}
#endif
