using StatsApi.BLL;
using StatsApi.Controllers;
using StatsApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Results;

namespace DeveloperEvaluation.Tests
{
    [TestClass]
    public class StatsApiControllerTests
    {
        [TestMethod]
        public void PostCalcStats_Created()
        {
            
            var mockIStatsCalc = new Mock<IStatsCalc>();
            var controller = new StatsController(mockIStatsCalc.Object);

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:50960/Api/CalcStats");
            var route = config.Routes.MapHttpRoute("default", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "test" } });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;

            List<decimal> fackInput = new List<decimal>
            {
                1.222M,
                1.2222M
            };
            List<decimal> fakemode = new List<decimal>
            {
                1.222M
            };
            Stats fackResult = new Stats(1.222M,1.222M, fakemode);

            mockIStatsCalc.Setup(x => x.CalcAsync(fackInput)).Returns(Task.FromResult(fackResult));

            IHttpActionResult actionresult = controller.CreateStats(fackInput);
            var result = actionresult as CreatedNegotiatedContentResult<Stats>;

            Assert.IsInstanceOfType(actionresult, typeof(CreatedNegotiatedContentResult<Stats>));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, fackResult);
 
        }
    }
}
