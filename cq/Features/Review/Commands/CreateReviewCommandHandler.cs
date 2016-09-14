using AutoMapper;
using cq.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private CqEntities Db;
        private IMapper Mapper;

        public CreateReviewCommandHandler(CqEntities db, IMapper mapper)
        {
            Mapper = mapper;
            Db = db;
        }

        public ReviewDto Handle(CreateReviewCommand message)
        {
            if (string.IsNullOrEmpty(message.Name))
            {
                throw new ArgumentNullException("message.Name");
            }

            if (message.ScheduleAt < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Cannot schedule in the past");
            }

            var review = new Review
            {
                Name = message.Name,
                ScheduledAt = message.ScheduleAt
            };

            Db.Reviews.Add(review);
            Db.SaveChanges();

            return Mapper.Map<ReviewDto>(review);
        }
    }
}