using cq.Infrastructure.MediatorPipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace cq.Infrastructure.CommonHandlers
{
    public class QueryLoggingHandler<TRequest> : IPreRequestHandler<TRequest> where TRequest : IQuery
    {
        public void Handle(TRequest request)
        {
            Debug.Write("A query!");
        }
    }
}