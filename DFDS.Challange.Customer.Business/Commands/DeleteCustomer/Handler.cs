using DFDS.Challange.Customer.Business.Exceptions;
using DFDS.Challange.Customer.Data;
using DFDS.Challange.Customer.Data.EF;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DFDS.Challange.Customer.Business.Commands.DeleteCustomer
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
            if (customer == null)
            {
                throw new NotFoundException("customer", request.Id);
            }

            customer.IsDeleted = true;
            await _customerDbContext.SaveChangesAsync(cancellationToken);

            return new Response();
        }
    }
}
