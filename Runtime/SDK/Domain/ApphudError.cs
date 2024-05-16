namespace Apphud.Unity.Domain
{
    public abstract class ApphudError
    {
        public string Message { get; protected set; }
        public string SecondErrorMessage { get; protected set; }
        public int? ErrorCode { get; protected set; }
    }
}