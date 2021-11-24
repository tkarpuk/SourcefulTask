using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Persistence.Models;

namespace Users.Persistence.Configurations
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfoModel>
    {
        public void Configure(EntityTypeBuilder<UserInfoModel> builder)
        {
            builder.ToTable("UsersInfo");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Age).HasDefaultValue(0);
        }
    }
}
