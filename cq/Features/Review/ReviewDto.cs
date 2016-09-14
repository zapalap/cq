using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ScheduledAt { get; set; }
    }
}