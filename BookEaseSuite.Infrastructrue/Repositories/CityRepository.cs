using Bidaya.Infrastructure.Repositories;
using BookEaseSuite.Application.Interfaces;
using BookEaseSuite.Domain.Entities;
using BookEaseSuite.Infrastructrue.Data;
using Microsoft.Extensions.Logging;

namespace BookEaseSuite.Infrastructrue.Repositories
{
    public class CityRepository : GenericRepository<City>,ICityRepository
    {
        public CityRepository(AppDbContext context, ILogger<GenericRepository<City>> logger) : base(context, logger)
        {
        }
    }
}
