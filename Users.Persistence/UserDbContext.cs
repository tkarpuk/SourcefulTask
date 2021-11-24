using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;
using Users.Persistence.Configurations;

namespace Users.Persistence
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Film> Films { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
