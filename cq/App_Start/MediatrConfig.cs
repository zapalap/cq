using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using cq.Features.Review.Queries;
using cq.Infrastructure.MediatorPipeline;
using FluentValidation;
using cq.Infrastructure.CommonHandlers;
using SimpleInjector;

namespace cq.App_Start
{
    public static class MediatrConfig
    {
        public static void BuildMediator(Container container)
        {
            var assemblies = GetAssemblies().ToArray();

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.RegisterCollection(typeof(IPreRequestHandler<>), assemblies);
            container.RegisterCollection(typeof(IPostRequestHandler<,>), assemblies);
            container.RegisterCollection(typeof(IValidator<>), assemblies);

            container.RegisterDecorator(typeof(IRequestHandler<,>), typeof(MediatorPipeline<,>));
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(ListReviewsQuery).GetTypeInfo().Assembly;
        }
    }
}