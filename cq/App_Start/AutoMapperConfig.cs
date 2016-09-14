using AutoMapper;
using cq.Features.Review;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.App_Start
{
    public static class AutoMapperConfig
    {
        public static void BuildMapper(IKernel kernel)
        {
            var config = new MapperConfiguration(CreateMapper);
            var mapper = config.CreateMapper();

            kernel.Bind<IMapper>().ToConstant(mapper);
            kernel.Bind<IConfigurationProvider>().ToConstant(config);
        }

        private static void CreateMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<Review, ReviewDto>();
        }
    }
}