using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardApp.Models
{
    public class Comment
    {
        // ====================== Comment Table Model
        [Key]
        public int CommentId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MessageId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Min 3 Chars")]
        [Display(Name ="Post a Comment")]
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ====================== Nav Properties
        public User CommentAuthor { get; set; }
        public Message CommentedMessage { get; set; }
    }
}