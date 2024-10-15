#if UNITY_ANDROID
namespace Apphud.Unity.Domain
{
    public enum RecurrenceMode
    {
        FINITE_RECURRING = 2,
        INFINITE_RECURRING = 1,
        NON_RECURRING = 3,
        UNDEFINED = 0
    }
}
#endif