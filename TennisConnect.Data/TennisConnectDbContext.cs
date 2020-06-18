using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace TennisConnect.Data
{
    public class TennisConnectDbContext : DbContext
    {
        public TennisConnectDbContext(){ }
        public TennisConnectDbContext(DbContextOptions options) : base(options){ }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Rating>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<FriendRequestFlag>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(a => new { a.EmailAddress })
                .IsUnique();

            builder.Entity<Address>()
                .HasIndex(a => new { a.UniqueIdentifier })
                .IsUnique();

            builder.Entity<Friend>()
                .HasKey(a => new { a.RequestedById, a.RequestedToId });

            builder.Entity<Friend>()
                .HasOne(a => a.RequestedBy)
                .WithMany(b => b.SentFriendRequests)
                .HasForeignKey(c => c.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friend>()
                .HasOne(a => a.RequestedTo)
                .WithMany(b => b.ReceivedFriendRequests)
                .HasForeignKey(c => c.RequestedToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasPostgresEnum<Rating>();
            builder.HasPostgresEnum<FriendRequestFlag>();
        }
    }
}
