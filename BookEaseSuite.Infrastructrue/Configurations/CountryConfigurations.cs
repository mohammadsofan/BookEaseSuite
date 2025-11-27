using BookEaseSuite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookEaseSuite.Infrastructrue.Configurations
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(country => country.Id);
        }
    }
}
