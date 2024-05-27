using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atm.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public string? AccountNo { get; set; }
        public Account? Account { get; set; }
        public float Amount { get; set; }
        [StringLength(10)]
        public string? Type { get; set; }
        public DateTime Date { get; set; }
    }
}
