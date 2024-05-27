using Atm.Model;
using System;

namespace Atm.Dto
{
    public record TransactionDto(string AccountNo, Account Account, float Amount, string Type, DateTime Date);
}
