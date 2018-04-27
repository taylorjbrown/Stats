using DeveloperEvaluation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            string input = nums.ToString();

            Stats result = new Stats();
            result.input = input;
            result.Mean = calcMean;
            result.Median = calcMedian;
            result.Mode = calcMode;

            return result;
        }
    }
}