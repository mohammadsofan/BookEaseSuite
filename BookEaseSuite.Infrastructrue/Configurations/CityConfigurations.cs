using BookEaseSuite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookEaseSuite.Infrastructrue.Configurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(city => city.Id);
            builder.HasOne(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(city => city.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
