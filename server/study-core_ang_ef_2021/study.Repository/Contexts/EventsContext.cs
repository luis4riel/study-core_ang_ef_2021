using Microsoft.EntityFrameworkCore;
using study.Domain;

namespace study.Repository.Contexts
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

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialNetworks)
                .WithOne(sn => sn.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.SocialNetworks)
                .WithOne(sn => sn.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}