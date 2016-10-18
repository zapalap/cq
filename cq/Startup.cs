using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using cq.App_Start;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(cq.Startup))]

namespace cq
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ServicesConfig.BuildContainer();
            var apiConfig = WebApiConfig.BuildConfig();

            apiConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            app.UseWebApi(apiConfig);
        }
    }
}
