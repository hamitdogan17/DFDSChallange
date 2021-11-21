using FluentValidation;

namespace DFDS.Challange.Customer.Business.Commands.UpdateCustomer
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
