using MediatR;
using System.Collections.Generic;

namespace DFDS.Challange.Customer.Business.Queries.GetQualifiedCustomerFromCountryRef
{
    public class Request : IRequest<List<Response>>
    {
        public int CountryRef { get; set; }
    }
}
