using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands.Update
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(r => r.ScheduleAt).GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}