using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    public abstract class ApphudGroup
    {
        public string Name { get; protected set; }
        public List<ApphudProduct> Products { get; protected set; }
        public abstract bool HasAccess { get; }
    }
}