using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCharacterInput : BaseCommandInput
    {
        public Guid CustomerId { get; set; }
    }
}
