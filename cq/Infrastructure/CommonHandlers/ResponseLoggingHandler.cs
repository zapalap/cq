using cq.Infrastructure.MediatorPipeline;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace cq.Infrastructure.CommonHandlers
{
    public class ResponseLoggingHandler<TRequest, TResponse> : IPostRequestHandler<TRequest, TResponse>
    {
        public void Handle(TRequest request, TResponse response)
        {
            var logEntry = $"{typeof(TRequest).Name} in {JsonConvert.SerializeObject(request)} out {JsonConvert.SerializeObject(response)}";

            Debug.Write(logEntry);
        }
    }
}