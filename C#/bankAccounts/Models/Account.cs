using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bankAccounts.Models
{
    public class Account : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int HolderId { get; set; }
        public int Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }
    }
}