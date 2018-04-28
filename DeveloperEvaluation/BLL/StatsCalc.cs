using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public class StatsCalc : IStatsCalc
    {

        public async Task<float> mean(List<int> nums)
        {
            float res = 1.2222f;
            return res;
        }
        public async Task<float> median(List<int> nums)
        {
            float res = 1.2222f;
            return res;
        }
        public async Task<float> mode(List<int> nums)
        {
            float res = 1.2222f;
            return res;
        }
        public async Task<Stats> CalcAsync(List<int> nums)
        {
            Task<float> calcMean = mean(nums);
            Task<float> calcMedian = median(nums);
            Task<float> calcMode = mode(nums);

            await Task.WhenAll(calcMean, calcMedian, calcMode);

            Stats result = new Stats(calcMean.Result, calcMedian.Result, calcMode.Result);

            return result;
        }
    }
}