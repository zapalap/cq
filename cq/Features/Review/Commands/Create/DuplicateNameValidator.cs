using cq.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Features.Review.Commands.Create
{
    public class DuplicateNameValidator : AbstractValidator<CreateReviewCommand>
    {
        private CqEntities Db;

        public DuplicateNameValidator(CqEntities db)
        {
            Db = db;
            RuleFor(c => c.Name)
                .Must(n => !Db.Reviews.Any(r => r.Name == n))
                .WithMessage("Name must be unique");
        }
    }
}