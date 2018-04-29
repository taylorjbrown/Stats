namespace DeveloperEvaluation.Model
{
    public class Stats
    {
        public Stats() { }

        public Stats(double mean, double median, double mode)
        {
            Mean = mean;
            Median = median;
            Mode = mode;
        }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Mode { get; set; }
    }
}