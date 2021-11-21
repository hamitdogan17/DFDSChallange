using MediatR;

namespace DFDS.Challange.Customer.Business.Commands.CreateCustomer
{
    public class Request : IRequest<Response>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public int NationalityRef { get; set; }
        public int StatusRef { get; set; }
    }
}
