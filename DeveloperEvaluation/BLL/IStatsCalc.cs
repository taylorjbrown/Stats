using StatsApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatsApi.BLL
{
    public interface IStatsCalc
    {
        Task<decimal> Mean(List<decimal> nums);
        Task<decimal> Median(List<decimal> nums);
        Task<List<decimal>> Mode(List<decimal> nums);
        Task<Stats> CalcAsync(List<decimal> nums);
    }
}
