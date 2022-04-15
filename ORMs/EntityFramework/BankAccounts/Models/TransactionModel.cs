using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Display(Name = "Deposit/Withdraw")]
        [Range(-10000.00, 10000.00)]
        [ValidAmount(ErrorMessage ="Transactions must not be $0.00")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }
        
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User AccountHolder { get; set; }

    }
    public class ValidAmount : ValidationAttribute
    {
        public override bool IsValid(object Amount)
        {
            return (decimal)Amount!=0;
        }
    }
    
}