using Atm.Model;
namespace Atm.Dto
{
    public record CustomerDto(string PersonalId, string FirstName, string LastName, string PhoneNumber, string Address, Guid CustomerKey, List<Account> Accounts);
}
