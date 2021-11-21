using MediatR;

namespace DFDS.Challange.Customer.Business.Commands.DeleteCustomer
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
