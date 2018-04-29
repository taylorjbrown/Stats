using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public class StatsCalc : IStatsCalc
    {

        public async Task<decimal> mean(List<decimal> nums)
        {
            return nums.Average(x => x);
        }

        public async Task<decimal> median(List<decimal> nums)
        {
            return nums.OrderBy(n => n)
                .Skip(nums.Count / 2).First();
        }

        public async Task<decimal> mode(List<decimal> nums)
        {
            return nums.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key).FirstOrDefault();
        }

        public async Task<Stats> CalcAsync(List<decimal> nums)
        {
            Task<decimal> calcMean = mean(nums);
            Task<decimal> calcMedian = median(nums);
            Task<decimal> calcMode = mode(nums);

            await Task.WhenAll(calcMean, calcMedian, calcMode);

            Stats result = new Stats(calcMean.Result, calcMedian.Result, calcMode.Result);

            return result;
        }
    }
}