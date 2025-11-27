using BookEaseSuite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookEaseSuite.Infrastructrue.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Email).IsUnique();
            builder.HasIndex(user => user.UserName).IsUnique();
            builder.HasOne(user => user.City)
                .WithMany(city => city.Users)
                .HasForeignKey(user => user.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(user => user.Country)
                .WithMany(country => country.Users)
                .HasForeignKey(user => user.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
