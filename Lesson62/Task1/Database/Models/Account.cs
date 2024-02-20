using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Database.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Password { get; set; }
        public double MoneyInAccount { get; set; }
        public string CardNumber { get; }
        public bool IsBlocked { get; set; }
        
        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; }
    }
}