using StatsApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatsApi.BLL
{
    public interface IStatsCalc
    {
        decimal Mean(List<decimal> nums);
        decimal Median(List<decimal> nums);
        List<decimal> Mode(List<decimal> nums);
        Stats CalcAsync(List<decimal> nums);
    }
}
