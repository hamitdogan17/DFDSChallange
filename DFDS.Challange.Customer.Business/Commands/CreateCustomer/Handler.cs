using DFDS.Challange.Customer.Data;
using DFDS.Challange.Customer.Data.EF;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DFDS.Challange.Customer.Business.Commands.CreateCustomer
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
            var customer = new tb_Customer
            {
                Name = request.Name,
                Surname = request.Surname,
                Mail = request.Mail,
                Age = request.Age,
                StatusRef = request.StatusRef,
                NationalityRef = request.NationalityRef,
            };

            await _customerDbContext.tb_Customer.AddAsync(customer, cancellationToken);
            await _customerDbContext.SaveChangesAsync(cancellationToken);

            return new Response();
        }
    }
}
