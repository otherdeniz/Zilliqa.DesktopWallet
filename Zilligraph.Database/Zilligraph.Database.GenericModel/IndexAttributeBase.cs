namespace Zilligraph.Database.Contract
{
    public abstract class IndexAttributeBase : Attribute
    {
        /// <summary>
        /// default = 16
        /// RAM usage: 16 = 512KB, 18 = 2MB, 20 = 8MB
        /// </summary>
        public int HeadBitLength { get; set; } = 16; //TODO: check for validity.

        /// <summary>
        /// true = queries are sortable by this column
        /// false (default) = better distribution in head-file (faster) but not sortable column
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        /// default chain length for String and DateTime = 5000
        /// </summary>
        public int OverrideMaxChainLength { get; set; } = -1;

        /// <summary>
        /// default = false
        /// </summary>
        public bool LowDistinctOptimization { get; set; }

        /// <summary>
        /// default = false
        /// </summary>
        public bool CaseInsensitive { get; set; }

        /// <summary>
        /// default = false
        /// </summary>
        public bool CountStatistic { get; set; }

        public override string ToString()
        {
            var state = HeadBitLength == 16 ? "" : $"HeadBitLength:{HeadBitLength}|";
            state += $"OverrideMaxChainLength:{OverrideMaxChainLength}|LowDistinctOptimization:{LowDistinctOptimization}";
            if (Sortable)
            {
                state += "|Sortable";
            }
            if (CaseInsensitive)
            {
                state += "|CaseInsensitive";
            }
            return state;
        }
    }
}
