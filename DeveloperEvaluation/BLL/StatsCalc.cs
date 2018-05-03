using StatsApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace StatsApi.BLL
{
    public class StatsCalc : IStatsCalc
    {
        public StatsCalc() { }
        public decimal Mean(List<decimal> nums)
        {

            return nums.Average(x => x);
        }

        public decimal Median(List<decimal> nums)
        {
                if (nums.Count % 2 != 0)
                {
                    return nums.OrderBy(n => n).Skip(nums.Count / 2).First();
                }
                else
                {
                    List<decimal> two = nums.OrderBy(n => n).Skip((nums.Count / 2) - 1).Take(2).ToList();
                    return ((two[0] + two[1]) / 2M);
                }
        }

        public List<decimal> Mode(List<decimal> nums)
        {

                var keycounts = nums.GroupBy(n => n)
                   .Select(g => new { val = g.Key, count = g.Count() })
                   .OrderByDescending(n => n.count)
                   .ToList();

                int maxCount = keycounts[0].count;

                List<decimal> result = keycounts
                    .Where(x => x.count == maxCount)
                    .Select(x => x.val)
                    .ToList();

                int numsCount = nums.Count;
                nums.Clear();

                return (result.Count != numsCount) ? result : nums;
        }

        public Stats CalcAsync(List<decimal> nums)
        {
            decimal calcMean = Mean(nums);
            decimal calcMedian = Median(nums);
            List<decimal> calcMode = Mode(nums);

            Stats result = new Stats(calcMean, calcMedian, calcMode);

            return result;
        }
    }
}