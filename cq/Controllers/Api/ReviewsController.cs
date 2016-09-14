using cq.Features.Review.Commands;
using cq.Features.Review.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace cq.Controllers.Api
{
    public class ReviewsController : ApiController
    {
        private IMediator Mediator;

        public ReviewsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [Route("api/reviews")]
        public IHttpActionResult Get([FromUri]ListReviewsQuery query)
        {
            var result = Mediator.Send(query);
            return Json(result);
        }

        [Route("api/reviews")]
        public IHttpActionResult Post(CreateReviewCommand command)
        {
            var result = Mediator.Send(command);
            return Json(result);
        }

        [Route("api/reviews")]
        public IHttpActionResult Put(UpdateReviewCommand command)
        {
            var result = Mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }
    }
}