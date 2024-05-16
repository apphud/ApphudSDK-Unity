#ifndef ApphudUnityPluginCallback_h
#define ApphudUnityPluginCallback_h

typedef const void* UnityAction;

typedef void (*CallbackBoolDelegate)(UnityAction action, bool data);

typedef void (*CallbackDelegate)(UnityAction action, const char *data);

typedef void (*Callback2Delegate)(UnityAction action, const char *data, const char *data2);

typedef void (*Callback3Delegate)(UnityAction action, const char *data, const char *data2, const char *data3);

#endif /* ApphudUnityPluginCallback_h */
