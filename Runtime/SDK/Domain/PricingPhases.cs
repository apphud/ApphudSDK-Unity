using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    public abstract class PricingPhases
    {
        public List<PricingPhase> PricingPhaseList { get; protected set; }
    }
}