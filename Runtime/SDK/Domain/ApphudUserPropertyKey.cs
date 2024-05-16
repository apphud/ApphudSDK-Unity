namespace Apphud.Unity.Domain
{
    public sealed class ApphudUserPropertyKey
    {
        public readonly string key;
        private ApphudUserPropertyKey(string key)
        {
            this.key = key;
        }

        public static ApphudUserPropertyKey Email => new ApphudUserPropertyKey("$email");
        public static ApphudUserPropertyKey Name => new ApphudUserPropertyKey("$name");
        public static ApphudUserPropertyKey Phone => new ApphudUserPropertyKey("$phone");
        public static ApphudUserPropertyKey Cohort => new ApphudUserPropertyKey("$cohort");
        public static ApphudUserPropertyKey Age => new ApphudUserPropertyKey("$age");
        public static ApphudUserPropertyKey Gender => new ApphudUserPropertyKey("$gender");

        public static ApphudUserPropertyKey CustomProperty(string key) => new ApphudUserPropertyKey(key);
    }
}