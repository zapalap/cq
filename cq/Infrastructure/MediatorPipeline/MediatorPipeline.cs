using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Infrastructure.MediatorPipeline
{
    public class MediatorPipeline<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IRequestHandler<TRequest, TResponse> Inner;
        private readonly IEnumerable<IPreRequestHandler<TRequest>> PreRequestHandlers;
        private readonly IEnumerable<IPostRequestHandler<TRequest, TResponse>> PostRequestHandlers;

        public MediatorPipeline(IRequestHandler<TRequest, TResponse> inner, IEnumerable<IPreRequestHandler<TRequest>> preRequestHandlers, IEnumerable<IPostRequestHandler<TRequest, TResponse>> postRequestHandlers)
        {
            Inner = inner;
            PreRequestHandlers = preRequestHandlers;
            PostRequestHandlers = postRequestHandlers;
        } 

        public TResponse Handle(TRequest message)
        {
            foreach (var preRequestHandler in PreRequestHandlers)
            {
                preRequestHandler.Handle(message);
            }

            var result = Inner.Handle(message);

            foreach (var postRequestHandler in PostRequestHandlers)
            {
                postRequestHandler.Handle(message, result);
            }

            return result;
        }
    }
}