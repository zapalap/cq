using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Queries
{
    public class ListReviewsQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public string Name { get; set; }
    }
}