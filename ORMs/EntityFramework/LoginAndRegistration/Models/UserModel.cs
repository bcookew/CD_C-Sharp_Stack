using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndRegistration
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Names must be at least 3 chars")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Names must be at least 3 chars")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        // ====================== RegEx from https://www.ocpsoft.org/tutorials/regular-expressions/password-regular-expression/
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\]).{8,32}$", ErrorMessage ="Password must be 8-32 chars including Nums, Upper, Lower, and Special Chars")]
        public string Password { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ====================== Not Mapped - Validation purposes only
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPass {get;set;}
    }
}