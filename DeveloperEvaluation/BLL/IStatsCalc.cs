using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public interface IStatsCalc
    {
        Task<float> mean(List<int> nums);
        Task<float> median(List<int> nums);
        Task<float> mode(List<int> nums);
        Task<Stats> CalcAsync(List<int> nums);
    }
}
