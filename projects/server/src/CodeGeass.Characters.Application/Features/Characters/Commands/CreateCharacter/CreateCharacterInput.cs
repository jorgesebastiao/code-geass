using CodeGeass.Application.Common;

namespace CodeGeass.Characters.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCharacterInput : BaseCommandInput
    {
        public string Name { get; set; }
        public string NickName { get; set; }
    }
}
