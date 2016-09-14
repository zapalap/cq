using MediatR;
using Ninject;
using Ninject.Components;
using Ninject.Infrastructure;
using Ninject.Planning.Bindings;
using Ninject.Planning.Bindings.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Ninject.Extensions.Conventions;
using cq.Features.Review.Queries;
using cq.Infrastructure.MediatorPipeline;
using FluentValidation;
using cq.Infrastructure.CommonHandlers;

namespace cq.App_Start
{
    public static class MediatrConfig
    {
        public static void BuildMediator(IKernel kernel)
        {
            kernel.Components.Add<IBindingResolver, ContravariantBindingResolver>();
            kernel.Bind(scan => scan.FromAssemblyContaining<IMediator>().SelectAllClasses().BindDefaultInterface());

            kernel.Bind(scan => scan
              .FromAssemblyContaining<ListReviewsQuery>()
              .SelectAllClasses()
              .InheritedFrom(typeof(IRequestHandler<,>))
              .BindAllInterfaces()
              .Configure(c => c.WhenInjectedExactlyInto(typeof(MediatorPipeline<,>))));

            kernel.Bind(scan => scan
              .FromAssemblyContaining<ListReviewsQuery>()
              .SelectAllClasses()
              .InheritedFrom(typeof(IValidator<>))
              .BindAllInterfaces().Configure(c => c.WhenInjectedExactlyInto(typeof(ValidatorHandler<>))));

            kernel.Bind(typeof(IRequestHandler<,>)).To(typeof(MediatorPipeline<,>));

            kernel.Bind(
                 x =>
                     x.FromAssemblyContaining<ListReviewsQuery>()
                         .SelectAllClasses()
                         .InheritedFrom(typeof(IPreRequestHandler<>)).BindAllInterfaces()
                 );

            kernel.Bind(
                x =>
                    x.FromAssemblyContaining<ListReviewsQuery>()
                        .SelectAllClasses()
                        .InheritedFrom(typeof(IPostRequestHandler<,>)).BindAllInterfaces()
                );

            kernel.Bind<SingleInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.Get(t));
            kernel.Bind<MultiInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.GetAll(t));
        }
    }

    public class ContravariantBindingResolver : NinjectComponent, IBindingResolver
    {
        /// <summary>
        /// Returns any bindings from the specified collection that match the specified service.
        /// </summary>
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, Type service)
        {
            if (service.IsGenericType)
            {
                var genericType = service.GetGenericTypeDefinition();
                var genericArguments = genericType.GetGenericArguments();
                if (genericArguments.Count() == 1
                 && genericArguments.Single().GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant))
                {
                    var argument = service.GetGenericArguments().Single();
                    var matches = bindings.Where(kvp => kvp.Key.IsGenericType
                                                           && kvp.Key.GetGenericTypeDefinition().Equals(genericType)
                                                           && kvp.Key.GetGenericArguments().Single() != argument
                                                           && kvp.Key.GetGenericArguments().Single().IsAssignableFrom(argument))
                        .SelectMany(kvp => kvp.Value);
                    return matches;
                }
            }

            return Enumerable.Empty<IBinding>();
        }
    }

}