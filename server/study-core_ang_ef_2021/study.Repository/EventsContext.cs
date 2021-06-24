using Microsoft.EntityFrameworkCore;
using study.Domain;

namespace study.Repository
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>().HasKey(SE => new { SE.EventId, SE.SpeakerId });
        }
    }
}