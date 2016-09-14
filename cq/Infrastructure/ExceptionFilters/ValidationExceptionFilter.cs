using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace cq.Infrastructure.ExceptionFilters
{
    public class ValidationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ValidationException)
            {
                var exception = actionExecutedContext.Exception as ValidationException;

                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent(JsonConvert.SerializeObject(exception.Errors)),
                };

                actionExecutedContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
    }
}