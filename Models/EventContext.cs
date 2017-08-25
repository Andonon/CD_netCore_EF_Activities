using Microsoft.EntityFrameworkCore;
 
namespace Activities.Models
{
    public class EventContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}