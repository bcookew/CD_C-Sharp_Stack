using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        // ====================== Wedding Table Model
        [Key]
        public int WeddingId{ get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Minimum 3 Chars")]
        public string NearlyWed1 { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage ="Minimum 3 Chars")]
        public string NearlyWed2 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        
        [Required]
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
        public List<User> Guests { get; set; }

        
    }
}