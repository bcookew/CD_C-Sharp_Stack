using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Guest
    {
        // ====================== Weddings_Has_Users Joining Table
        [Key]
        public int GuestId { get; set; }

        [Range(1,int.MaxValue)]
        public int UserId { get; set; }
        [Range(1,int.MaxValue)]
        public int WeddingId { get; set; }


        // ====================== Nav Props for User and Wedding
        public User User { get; set; }
        public Wedding Wedding { get; set; }
    }
}