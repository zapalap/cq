using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject;
using System.Reflection;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(cq.Startup))]

namespace cq
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = CreateKernel();

            var apiConfig = WebApiConfig.BuildConfig();

            app
                .UseNinjectMiddleware(() => kernel)
                .UseNinjectWebApi(apiConfig);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }


}
