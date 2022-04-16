using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        [Range(1,int.MaxValue)]
        public int UserId { get; set; }
        [Range(1,int.MaxValue)]
        public int WeddingId { get; set; }

        public User User { get; set; }
        public Wedding Wedding { get; set; }
    }
}