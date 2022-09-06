namespace Zilligraph.Database.Contract
{
    public abstract class IndexAttributeBase : Attribute
    {
        public int OverrideMaxChainLength { get; set; } = -1;

        public bool LowDistinctOptimization { get; set; }
    }
}
