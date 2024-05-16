using System.Collections.Generic;

namespace Apphud.Unity.Domain
{
    public abstract class ApphudPaywall
    {
        /// <summary>
        /// Paywall name, from Apphud Dashboard.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Your custom paywall identifier from Apphud Dashboard.
        /// </summary>
        public string Identifier { get; protected set; }

        /// <summary>
        /// It's possible to make a paywall default – it's a special alias name, that can be assigned to only ONE paywall at a time.
        /// There can be no default paywalls at all. It's up to you whether you want to have them or not.
        /// </summary>
        public bool Default { get; protected set; }

        /// <summary>
        /// A/B test experiment name, if user is included in the experiment.
        /// You can use it for additional analytics.
        /// </summary>
        public string ExperimentName { get; protected set; }

        /// <summary>
        /// Array of products.
        /// </summary>
        public List<ApphudProduct> Products { get; protected set; }

        /// <summary>
        ///  Custom JSON from your paywall config.
        ///  It could be titles, descriptions, localisations, font, background and color parameters, URLs to media content, etc.
        /// </summary>
        public Dictionary<string, object> Json { get; protected set; }

        /// <summary>
        /// A/B Experiment Variation Name
        /// </summary>
        public string VariationName { get; protected set; }

        /// <summary>
        /// Represents the identifier of a parent paywall from which an experiment variation was derived in A/B Experiments.
        /// This property is populated only if the 'Use existing paywall' option was selected
        /// during the setup of the experiment variation.
        /// </summary>
        public string ParentPaywallIdentifier { get; protected set; }

        /// <summary>
        /// Current paywall's placement identifier, if available.
        /// </summary>
        public string PlacementIdentifier { get; protected set; }
    }
}