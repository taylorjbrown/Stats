using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public class StatsCalc : IStatsCalc
    {
        public StatsCalc() { }
        public async Task<decimal> mean(List<decimal> nums)
        {
            return nums.Average(x => x);
        }

        public async Task<decimal> median(List<decimal> nums)
        {
            if (nums.Count % 2 != 0)
            {
                return nums.OrderBy(n => n).Skip(nums.Count / 2).First();
            }
            else
            {
                List<decimal> two = nums.OrderBy(n => n).Skip( (nums.Count / 2)-1).Take(2).ToList<decimal>();
                return ((two[0] + two[1]) / 2M);
            }
        }

        public async Task<List<decimal>> mode(List<decimal> nums)
        {
            var keycounts = nums.GroupBy(n => n)
               .Select(g => new { val = g.Key, count = g.Count() })
               .OrderByDescending(n => n.count)
               .Where(n=> n.count > 1)
               .ToList();

            List<decimal> result = new List<decimal>();

            if (keycounts.Count == 0)
            {
                return result;
            }

            var prev = keycounts[0].count;

          
            result.Add(keycounts[0].val);

            foreach (var item in keycounts.Skip(1))
            {
                if(prev == item.count)
                {
                    result.Add(item.val);
                }
            }

            if (result.Count != nums.Count)
            {
                return result;
            }
            else
            {
                return new List<decimal>();
            }
        }

        public async Task<Stats> CalcAsync(List<decimal> nums)
        {
            Task<decimal> calcMean = mean(nums);
            Task<decimal> calcMedian = median(nums);
            Task<List<decimal>> calcMode = mode(nums);

            await Task.WhenAll(calcMean, calcMedian, calcMode);

            Stats result = new Stats(calcMean.Result, calcMedian.Result, calcMode.Result);

            return result;
        }
    }
}