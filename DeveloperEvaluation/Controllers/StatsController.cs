using DeveloperEvaluation.BLL;
using DeveloperEvaluation.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace DeveloperEvaluation.Controllers
{
    [RoutePrefix("Api")]
    public class StatsController : ApiController
    {
        private readonly IStatsCalc _statsCalc;

        [HttpPost]
        [Route("CalcStats")]
        public IHttpActionResult CreateStats([FromBody]List<int> nums)
        {
                Stats res = _statsCalc.Calc(nums); 
                return Ok(res);
        }
    }
}
