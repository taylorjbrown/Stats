using DeveloperEvaluation.BLL;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace DeveloperEvaluation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            

 
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IStatsCalc, StatsCalc>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            app.UseWebApi(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
