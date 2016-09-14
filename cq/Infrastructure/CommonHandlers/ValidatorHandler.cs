using cq.Infrastructure.MediatorPipeline;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cq.Infrastructure.CommonHandlers
{
    public class ValidatorHandler<TRequest> : IPreRequestHandler<TRequest> 
    {
        private readonly IValidator<TRequest>[] Validators;

        public ValidatorHandler(IValidator<TRequest>[] validators)
        {
            Validators = validators;
        }

        public void Handle(TRequest message)
        {
            var context = new ValidationContext(message);

            var failures = Validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }
    }
}