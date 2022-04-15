using System;
using System.Collections.Generic;

namespace BankAccounts.Models
{
    public class Account
    {
        public User user { get; set; }
        public Transaction transaction { get; set; }
        public List<Transaction> Transactions { get; set; }
    } 
}