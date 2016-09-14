using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands
{
    public class CreateReviewCommand : IRequest<ReviewDto>
    {
        public DateTime ScheduleAt { get; set; }
        public string Name { get; set; }
    }
}