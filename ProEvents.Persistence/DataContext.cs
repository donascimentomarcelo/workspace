using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;

namespace ProEvents.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerParty> SpeakersParties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerParty>()
                .HasKey(SP => new { SP.PartyId, SP.SpeakerId });

            modelBuilder.Entity<Party>()
                .HasMany(s => s.SocialNetworks)
                .WithOne(s => s.Party)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.SocialNetworks)
                .WithOne(s => s.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
