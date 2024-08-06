
#ifndef ApphudUnityUtilities_h
#define ApphudUnityUtilities_h

#include <Foundation/Foundation.h>
#include "ApphudUnityPluginCallback.h"

NSString *cstringToString(const char *str);
const char *cstringFromString(NSString *str);
char *makeStringCopy(const char *string);

void SendCallbackBoolToUnity(UnityAction action, bool data);
void SendCallbackToUnity(UnityAction action, NSString *data);
void SendCallback2ToUnity(UnityAction action, NSString *data, NSString *data2);
void SendCallback3ToUnity(UnityAction action, NSString *data, NSString *data2, NSString *data3);

#endif /* ApphudUnityUtilities_h */
