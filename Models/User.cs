using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public List<Participant> Participants { get; set; }
        public User()
        {
            Participants = new List<Participant>();
        }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }      
    }
}