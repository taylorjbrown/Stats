namespace DeveloperEvaluation.Model
{
    public class Stats
    {
        public Stats() { }

        public Stats(float mean, float median, float mode)
        {
            Mean = mean;
            Median = median;
            Mode = mode;
        }
        public float Mean { get; set; }
        public float Median { get; set; }
        public float Mode { get; set; }
    }
}