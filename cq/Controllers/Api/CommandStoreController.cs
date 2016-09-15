using cq.Features.CommandStore.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace cq.Controllers.Api
{
    public class CommandStoreController : ApiController
    {
        IMediator Mediator;

        public CommandStoreController(IMediator mediator)
        {
            Mediator = mediator;
        }
       
        [Route("api/commandstore")]
        public IHttpActionResult Get()
        {
            var result = Mediator.Send(new ListStoredCommandsQuery());
            return Json(result);
        }
    }
}