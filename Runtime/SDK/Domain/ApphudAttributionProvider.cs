namespace Apphud.Unity.Domain
{
    public enum ApphudAttributionProvider
    {
        appsFlyer,
        adjust,
#if APPHUD_FB
        facebook,
#endif
        firebase
    }
}