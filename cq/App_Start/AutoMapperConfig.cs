using AutoMapper;
using cq.Features.Review;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.App_Start
{
    public static class AutoMapperConfig
    {
        public static void BuildMapper(Container container)
        {
            var config = new MapperConfiguration(CreateMapper);
            var mapper = config.CreateMapper();

            container.RegisterSingleton<IMapper>(mapper);
            container.RegisterSingleton<IConfigurationProvider>(config);
        }

        private static void CreateMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<Review, ReviewDto>();
        }
    }
}