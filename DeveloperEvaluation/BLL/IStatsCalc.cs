using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperEvaluation.BLL
{
    public interface IStatsCalc
    {
        Task<double> mean(List<double> nums);
        Task<double> median(List<double> nums);
        Task<double> mode(List<double> nums);
        Task<Stats> CalcAsync(List<double> nums);
    }
}
