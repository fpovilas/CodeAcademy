using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Database.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Account")]
        public int? AccountID { get; set; }

        public Account? Account { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}
