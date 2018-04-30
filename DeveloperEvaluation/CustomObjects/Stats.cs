using System.Collections.Generic;

namespace DeveloperEvaluation.Model
{
    public class Stats
    {
        public Stats() { }

        public Stats(decimal mean, decimal median, List<decimal> mode)
        {
            Mean = mean;
            Median = median;
            Mode = mode;
        }
        public decimal Mean { get; set; }
        public decimal Median { get; set; }
        public List<decimal> Mode { get; set; }
    }
}