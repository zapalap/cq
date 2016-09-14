using cq.Data;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.App_Start
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Kernel.Bind<CqEntities>().ToSelf().InRequestScope();

            MediatrConfig.BuildMediator(Kernel);
            AutoMapperConfig.BuildMapper(Kernel);

        }
    }
}