using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}