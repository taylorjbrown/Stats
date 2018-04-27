using DeveloperEvaluation.Model;
using System.Collections.Generic;

namespace DeveloperEvaluation.BLL
{
    public interface IStatsCalc
    {
        float mean(List<int> nums);
        float median(List<int> nums);
        float mode(List<int> nums);
        Stats Calc(List<int> nums);
    }
}
