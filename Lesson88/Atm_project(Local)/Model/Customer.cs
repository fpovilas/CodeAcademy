using System.ComponentModel.DataAnnotations;

namespace Atm.Model
{
    public class Customer
    {
        [Key]
        public Guid CustomerKey { get; set; }

        [StringLength(11)]
        public string? PersonalId { get; set; }
        [StringLength(30)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        [StringLength(80)]
        public string? Address { get; set; }
        [StringLength(6)]
        public string? UserId { get; set; }
        [StringLength(24)]
        public string? Password { get; set; }

        public virtual List<Account> Accounts { get; set; } = [];
    }
}