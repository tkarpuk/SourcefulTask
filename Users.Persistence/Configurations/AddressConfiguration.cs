using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Persistence.Models;

namespace Users.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(a => a.Id);
            builder.HasOne<UserInfoModel>(a => a.User).WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Street).IsRequired().HasMaxLength(100);
        }
    }
}
