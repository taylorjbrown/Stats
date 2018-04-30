using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public interface IStatsCalc
    {
        Task<decimal> mean(List<decimal> nums);
        Task<decimal> median(List<decimal> nums);
        Task<List<decimal>> mode(List<decimal> nums);
        Task<Stats> CalcAsync(List<decimal> nums);
    }
}
