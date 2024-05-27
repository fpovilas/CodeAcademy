using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atm.Model
{
    public class Account
    {
        [Key]
        [StringLength(34)]
        public string? Number { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerKey { get; set; }
        public Customer? Customer { get; set; }
        [DefaultValue(1000)]
        public float Balance { get; set; }

    }
}
