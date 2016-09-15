using AutoMapper;
using cq.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ReviewDto>
    {
        private CqEntities Db;
        private IMapper Mapper;

        public UpdateReviewCommandHandler(CqEntities db, IMapper mapper)
        {
            Db = db;
            Mapper = mapper;
        }

        public ReviewDto Handle(UpdateReviewCommand message)
        {
            var review = Db.Reviews.FirstOrDefault(r => r.Id == message.Id);

            if (review == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(message.Name))
            {
                review.Name = message.Name;
            }

            if (message.ScheduleAt != null && message.ScheduleAt > DateTime.MinValue)
            {
                review.ScheduledAt = message.ScheduleAt;
            }

            Db.Entry(review).State = EntityState.Modified;
            Db.SaveChanges();

            return Mapper.Map<ReviewDto>(review);
        }
    }
}