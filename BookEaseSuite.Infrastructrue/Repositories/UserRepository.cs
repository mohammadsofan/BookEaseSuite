using Bidaya.Infrastructure.Repositories;
using BookEaseSuite.Application.Interfaces;
using BookEaseSuite.Domain.Entities;
using BookEaseSuite.Infrastructrue.Data;
using Microsoft.Extensions.Logging;

namespace BookEaseSuite.Infrastructrue.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ILogger<GenericRepository<User>> logger) : base(context, logger)
        {
        }
    }
}
