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
using SimpleInjector.Advanced;

namespace cq.App_Start
{
    public static class MediatrConfig
    {
        public static void BuildMediator(Container container)
        {
            var assemblies = GetAssemblies().ToArray();

            container.RegisterSingleton<IMediator, Mediator>();

            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.RegisterDecorator(typeof(IRequestHandler<,>), typeof(MediatorPipeline<,>));

            container.RegisterCollection(typeof(IValidator<>), assemblies);

            var options = new TypesToRegisterOptions { IncludeGenericTypeDefinitions = true };

            var preTypes = container.GetTypesToRegister(typeof(IPreRequestHandler<>), assemblies, options);
            container.RegisterCollection(typeof(IPreRequestHandler<>), preTypes);
            
            var postTypes = container.GetTypesToRegister(typeof(IPostRequestHandler<,>), assemblies, options);
            container.RegisterCollection(typeof(IPostRequestHandler<,>), postTypes);

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