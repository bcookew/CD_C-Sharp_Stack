using System;
using System.Collections.Generic;

namespace TheWall.Models
{
    public class Dashboard
    {
        public Message NewMessage { get; set; }
        public List<Message> Messages { get; set; }
        public User User { get; set; }
    }
}
