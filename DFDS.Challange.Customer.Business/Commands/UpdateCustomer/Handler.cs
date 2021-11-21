using DFDS.Challange.Customer.Data.EF;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DFDS.Challange.Customer.Business.Commands.UpdateCustomer
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly CustomerDbContext _customerDbContext;
        public Handler(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
                
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var customer = _customerDbContext.tb_Customer.Where(c => c.Id == request.Id).FirstOrDefault();

            if (!string.IsNullOrEmpty(request.Name)) customer.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Surname)) customer.Surname = request.Surname;
            if (!string.IsNullOrEmpty(request.Mail)) customer.Mail = request.Mail;
            if (request.NationalityRef > 0) customer.NationalityRef = request.NationalityRef;
            if (request.StatusRef > 0) customer.StatusRef = request.StatusRef;

            await _customerDbContext.SaveChangesAsync(cancellationToken);

            return new Response();
        }
    }
}
