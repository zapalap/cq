using cq.Features.Review;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cq.Data
{
    public class CqEntities : DbContext
    {
        public CqEntities() : base("CqEntities")
        {

        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}