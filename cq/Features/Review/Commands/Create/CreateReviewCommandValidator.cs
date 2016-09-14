using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand> 
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.ScheduleAt).GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}