using System;
using System.Collections.Generic;

namespace Activities.Models
{
    public class Event : BaseEntity
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public int Duration { get; set; }
        public string DurationType { get; set; }
        public int CreatedById { get; set; }
        public string CreatedByFirstName { get; set; }
        public string Description { get; set; }
        public List<Participant> Participants { get; set; }
        public Event()
        {
            Participants = new List<Participant>();
        }     
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}