using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Users.Domain.Entities;

namespace Users.Persistence.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(f => f.Id);
            builder.HasOne<UserInfo>(f => f.User).WithMany(u => u.Films)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.Name).IsRequired().HasMaxLength(100);
            builder.Property(f => f.DateComeUp).HasDefaultValue(new DateTime(1900, 1, 1));
        }
    }
}
