using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User
    {
        // ====================== User Table Model
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
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%^&*<>()|+@\-_\[\]]).\S{8,32}$", ErrorMessage ="Password must be 8-32 chars including Nums, Upper, Lower, and Special Chars")]
        public string Password { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ====================== Nav Prop for Guest list 
        public List<Guest> WeddingsAttending { get; set; }

        // ====================== Not Mapped - Validation purposes only
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPass {get;set;}
    }
}