using Microsoft.EntityFrameworkCore;
using Npgsql;
using TennisConnect.Data.Models;

namespace TennisConnect.Data
{
    public class TennisConnectDbContext : DbContext
    {
        public TennisConnectDbContext(){ }
        public TennisConnectDbContext(DbContextOptions options) : base(options){ }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ContactDetails> ContactDetails { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Rating>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresEnum<Rating>();
        }
    }
}
