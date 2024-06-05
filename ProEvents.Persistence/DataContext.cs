﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProEvents.Domain;
using ProEvents.Domain.Identity;

namespace ProEvents.Persistence
{
    public class DataContext : IdentityDbContext<User, Role, int,
                                                    IdentityUserClaim<int>, UserRole,
                                                    IdentityUserLogin<int>, IdentityRoleClaim<int>,
                                                    IdentityUserToken<int>>
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

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(x => new { x.UserId, x.RoleId });
                userRole.HasOne(x => x.Role)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.RoleId)
                        .IsRequired();

                userRole.HasOne(x => x.User)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.UserId)
                        .IsRequired();
            });

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
