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
    public class ConsoleLoggingHandler<TRequest, TResponse> : IPostRequestHandler<TRequest, TResponse>
    {
        public void Handle(TRequest request, TResponse response)
        {
            var logEntry = $"{typeof(TRequest).Name} => {JsonConvert.SerializeObject(response)}";

            Debug.Write(logEntry);
        }
    }
}