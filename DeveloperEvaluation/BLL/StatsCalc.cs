using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public class StatsCalc : IStatsCalc
    {

        public async Task<double> mean(List<double> nums)
        {
            return nums.Average(x => x);
        }

        public async Task<double> median(List<double> nums)
        {
            return nums.OrderBy(n => n)
                .Skip(nums.Count / 2).First();
        }

        public async Task<double> mode(List<double> nums)
        {
            return nums.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key).FirstOrDefault();
        }

        public async Task<Stats> CalcAsync(List<double> nums)
        {
            Task<double> calcMean = mean(nums);
            Task<double> calcMedian = median(nums);
            Task<double> calcMode = mode(nums);

            await Task.WhenAll(calcMean, calcMedian, calcMode);

            Stats result = new Stats(calcMean.Result, calcMedian.Result, calcMode.Result);

            return result;
        }
    }
}