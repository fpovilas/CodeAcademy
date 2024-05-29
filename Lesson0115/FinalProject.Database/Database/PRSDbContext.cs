using FinalProject.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Database.Database
{
    public class PRSDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<PlaceOfResidence> PlaceOfResidences { get; set; }
        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Schemes for PK incrementation
            modelBuilder.HasSequence<int>("UserIndex", schema: "dbo")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>("PIIndex", schema: "dbo")
                .StartsAt(100)
                .IncrementsBy(5);

            modelBuilder.HasSequence<int>("PORIndex", schema: "dbo")
                .StartsAt(7)
                .IncrementsBy(7);

            modelBuilder.HasSequence<int>("PPIndex", schema: "dbo")
                .StartsAt(2)
                .IncrementsBy(4);

            // Assigning incrementation schemes
            modelBuilder.Entity<User>()
                .Property(uID => uID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.UserIndex");

            modelBuilder.Entity<PersonalInformation>()
                .Property(piID => piID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.PIIndex");

            modelBuilder.Entity<User>()
                .Property(porID => porID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.PORIndex");

            modelBuilder.Entity<User>()
                .Property(ppID => ppID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.PPIndex");

            // Assigning entity property lengths
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(20);

            modelBuilder.Entity<PersonalInformation>()
                .Property(pi => pi.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<PersonalInformation>()
                .Property(pi => pi.Gender)
                .HasMaxLength(7);

            // Assigning relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.PersonalInformations)
                .WithOne(pi => pi.User)
                .HasForeignKey(pi => pi.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalInformation>()
                .HasOne(pi => pi.ProfilePhoto)
                .WithOne(pp => pp.PersonalInformation)
                .HasForeignKey<ProfilePhoto>(pp => pp.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalInformation>()
                .HasOne(pi => pi.PlaceOfResidence)
                .WithOne(por => por.PersonalInformation)
                .HasForeignKey<PlaceOfResidence>(por => por.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}