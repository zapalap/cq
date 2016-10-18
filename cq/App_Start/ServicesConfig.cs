using cq.Data;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace cq.App_Start
{
    public static class ServicesConfig 
    {
        public static Container BuildContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<CqEntities>(Lifestyle.Scoped);

            MediatrConfig.BuildMediator(container);
            AutoMapperConfig.BuildMapper(container);

            container.Verify();

            return container; 
        }
    }
}