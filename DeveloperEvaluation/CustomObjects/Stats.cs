namespace DeveloperEvaluation.Model
{
    public class Stats
    {
        public Stats() { }

        public Stats(decimal mean, decimal median, decimal mode)
        {
            Mean = mean;
            Median = median;
            Mode = mode;
        }
        public decimal Mean { get; set; }
        public decimal Median { get; set; }
        public decimal Mode { get; set; }
    }
}