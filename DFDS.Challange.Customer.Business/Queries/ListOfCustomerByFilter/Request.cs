using MediatR;
using System.Collections.Generic;

namespace DFDS.Challange.Customer.Business.Queries.ListOfCustomerByFilter
{
    public class Request : IRequest<List<Response>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
