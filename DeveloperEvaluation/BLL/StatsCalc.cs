﻿using DeveloperEvaluation.Model;
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
                List<decimal> two = nums.OrderBy(n => n).Skip( (nums.Count / 2)-1).Take(2).ToList();
                return ((two[0] + two[1]) / 2M);
            }
        }

        public async Task<List<decimal>> mode(List<decimal> nums)
        {

            var keycounts = nums.GroupBy(n => n)
               .Select(g => new { val = g.Key, count = g.Count() })
               .OrderByDescending(n => n.count)
               .ToList();

            int maxCount = keycounts[0].count;

            List<decimal> result = keycounts
                .Where(x => x.count == maxCount)
                .Select(x=>x.val)
                .ToList();

            int numsCount = nums.Count;
            nums.Clear();

            return (result.Count != numsCount) ? result : nums;
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