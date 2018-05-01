using StatsApi.BLL;
using StatsApi.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace StatsApi.Controllers
{
    [RoutePrefix("Api")]
    public class StatsController : ApiController
    {
        private readonly IStatsCalc _statsCalc;

        public StatsController(IStatsCalc statsCalc)
        {
            _statsCalc = statsCalc;
        }

        [HttpPost]
        [Route("CalcStats")]
        public IHttpActionResult CreateStats([FromBody]List<decimal> nums)
        {
                Stats res = _statsCalc.CalcAsync(nums);

                return Created(Request.RequestUri.ToString(), res);
        }
    }
}
