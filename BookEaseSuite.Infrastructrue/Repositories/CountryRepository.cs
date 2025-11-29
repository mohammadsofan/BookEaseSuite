using Bidaya.Infrastructure.Repositories;
using BookEaseSuite.Application.Interfaces;
using BookEaseSuite.Domain.Entities;
using BookEaseSuite.Infrastructrue.Data;
using Microsoft.Extensions.Logging;

namespace BookEaseSuite.Infrastructrue.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context, ILogger<GenericRepository<Country>> logger) : base(context, logger)
        {
        }
    }
}
