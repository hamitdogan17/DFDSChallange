using DFDS.Challange.Customer.Data.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DFDS.Challange.Customer.Business.Queries.ListOfCustomerByFilter
{
    public class Handler : IRequestHandler<Request, List<Response>>
    {
        private readonly CustomerDbContext _customerDbContext;
        public Handler(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
                
        public async Task<List<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var query = _customerDbContext.tb_Customer
                .Include(c => c.NationalityRefNavigation)
                .Include(c => c.StatusRefNavigation)
                .Select(s => new Response
                {
                    Name = s.Name,
                    Surname = s.Surname,
                    Age = s.Age,
                    Address = s.Address,
                    Nationality = s.NationalityRefNavigation.Country,
                    Status = s.StatusRefNavigation.Status,
                });

            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(c => c.Name == request.Name);
            if (!string.IsNullOrEmpty(request.Surname)) query = query.Where(c => c.Surname == request.Surname);

            var customers = await query.ToListAsync();

            return customers;
        }
    }
}
