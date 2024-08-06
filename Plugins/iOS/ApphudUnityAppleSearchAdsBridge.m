#import "UnityFramework/UnityFramework-Swift.h"
#import "ApphudUnityUtilities.h"

#ifdef __cplusplus
extern "C" {
#endif

void ApphudUnity_trackAppleSearchAds(UnityAction callback) {
    [ApphudUnityAppleSearchAdsWrapper trackAppleSearchAdsWithCallback:^(BOOL value) {
        SendCallbackBoolToUnity(callback, value);
    }];
}

#ifdef __cplusplus
}
#endif
