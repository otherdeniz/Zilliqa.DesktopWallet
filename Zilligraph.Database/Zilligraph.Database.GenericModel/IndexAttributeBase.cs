namespace Zilligraph.Database.Contract
{
    public abstract class IndexAttributeBase : Attribute
    {
        public int OverrideMaxChainLength { get; set; } = -1;

        public bool LowDistinctOptimization { get; set; }

        public bool CaseInsensitive { get; set; }

        public override string ToString()
        {
            var state = $"OverrideMaxChainLength:{OverrideMaxChainLength}|LowDistinctOptimization:{LowDistinctOptimization}";
            if (CaseInsensitive)
            {
                state += "|CaseInsensitive";
            }
            return state;
        }
    }
}
