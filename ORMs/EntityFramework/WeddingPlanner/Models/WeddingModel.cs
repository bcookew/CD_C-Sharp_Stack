using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        // ====================== Wedding Table Model
        [Key]
        public int WeddingId{ get; set; }

        [Required]
        [Display(Name ="Nearlywed 1")]
        [MinLength(3, ErrorMessage ="Minimum 3 Chars")]
        public string NearlyWed1 { get; set; }
        
        [Required]
        [Display(Name ="Nearlywed 2")]
        [MinLength(3, ErrorMessage ="Minimum 3 Chars")]
        public string NearlyWed2 { get; set; }

        [Required]
        [FutureDate]
        [Display(Name ="Wedding Date")]
        [DataType(DataType.Date)]

        public DateTime EventDate { get; set; }
        
        [Required]
        [Display(Name ="Cermony Time")]
        [DataType(DataType.Time)]
        public DateTime EventTime { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Minimum 3 Chars")]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set; }=DateTime.Now;

        // ====================== fKey for event host
        [Required]
        public int UserId { get; set; }
        // ====================== Nav Pro for event host
        public User Creator { get; set; }

        // ====================== Nav Prop for Guest List
        public List<Guest> GuestsAttending { get; set; }

        
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        private DateTime _Now;
        private string _Message;
        public FutureDateAttribute() : base()
        {
            _Now = DateTime.Now;
            _Message = "Dates must be in the future!";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime EventDate = (DateTime)value;
            if (DateTime.Compare(_Now, EventDate) >= 0)
            {
                return new ValidationResult("Choose a Future Date!");
            }

            return ValidationResult.Success;
        }
    }
}