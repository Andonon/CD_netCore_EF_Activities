using System;
namespace Activities.Models
{
    public class Participant : BaseEntity
    {
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
        public Event EventDetail { get; set; }
        public int UserId { get; set; }
        public User UserDetail { get; set; }
    }
}