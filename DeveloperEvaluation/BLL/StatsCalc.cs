using DeveloperEvaluation.Model;
using System.Collections.Generic;

namespace DeveloperEvaluation.BLL
{
    public class StatsCalc : IStatsCalc
    {


        public float mean(List<int> nums)
        {
            float res = 1.2222f;
            return res;
        }
        public float median(List<int> nums)
        {
            float res = 1.2222f;
            return res;
        }
        public float mode(List<int> nums)
        {
            float res = 1.2222f;
            return res;
        }
        public Stats Calc(List<int> nums)
        {
            float calcMean = mean(nums);
            float calcMedian = median(nums);
            float calcMode = mode(nums);

            Stats result = new Stats(calcMean, calcMedian, calcMode);

            return result;
        }
    }
}