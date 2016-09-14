using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands
{
    public class UpdateReviewCommand : IRequest<ReviewDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ScheduleAt { get; set; }
    }
}