namespace Apphud.Unity.Domain
{
    public enum ApphudAttributionProvider
    {
        APPSFLYER,
        ADJUST,
#if APPHUD_FB
        FACEBOOK,
#endif
        FIREBASE,
        CUSTOM,
        BRANCH,
        SINGULAR,
        TENJIN,
        TIKTOK,
        VOLUMUM
    }
}