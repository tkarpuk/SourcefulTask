using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Persistence.Models;

namespace Users.Persistence.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<FilmModel>
    {
        public void Configure(EntityTypeBuilder<FilmModel> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(f => f.Id);
            builder.HasOne<UserInfoModel>(f => f.User).WithMany(u => u.Films)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(f => f.Name).IsRequired().HasMaxLength(100);
        }
    }
}
