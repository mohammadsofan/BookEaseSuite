using BookEaseSuite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookEaseSuite.Infrastructrue.Data.DBInitializer
{
    public class DBInitializer
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DBInitializer> _logger;

        public DBInitializer(AppDbContext context, ILogger<DBInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Initialize()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding initial data.");
                throw;
            }
        }
    }
}
