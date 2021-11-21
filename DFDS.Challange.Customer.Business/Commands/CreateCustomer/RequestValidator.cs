using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDS.Challange.Customer.Business.Commands.CreateCustomer
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.StatusRef).GreaterThan(0);
            RuleFor(x => x.NationalityRef).GreaterThan(0);
        }
    }
}
