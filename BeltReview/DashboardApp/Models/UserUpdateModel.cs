using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardApp.Models
{
    public class UserUpdate
    {
        public UpdateProfile Profile { get; set; }
        public UpdatePassword Password { get; set; }
        public UpdateDescription Description { get; set; }
    }
    public class UpdateProfile
    {
        public int UserId { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Names must be at least 3 chars!")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name ="Last Name")]
        [MinLength(3, ErrorMessage = "Names must be at least 3 chars!")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="User Level")]
        public int UserLevel { get; set; }
    }
    public class UpdatePassword
    {
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        // = RegEx sourced from from https://www.ocpsoft.org/tutorials/regular-expressions/password-regular-expression/ then modified with https://RegExr.com
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%^&*<>()|+@\-_\[\]]).\S{8,32}$", ErrorMessage ="Password must be 8-32 chars including Nums, Upper, Lower, and Special Chars")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Passwords did not match!")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPass {get;set;}
    }

    public class UpdateDescription
    {
        public int UserId { get; set; }

        [Display(Name ="About Me")]
        public string Description { get; set; }
    }
}