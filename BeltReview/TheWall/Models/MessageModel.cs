using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Message
    {
        // ====================== Message Table Model
        [Key]
        public int MessageId { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        [Display(Name ="Post a message")]
        [MinLength(3, ErrorMessage ="Min 3 Chars")]
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ====================== Nav Properties
        public User Author { get; set; }
        public List<Comment> CommentsOnMessage { get; set; }
    }
}