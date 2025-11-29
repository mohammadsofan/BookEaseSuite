using BookEaseSuite.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookEaseSuite.Infrastructrue.Utils
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly IPasswordHasher<object> _identityHasher;

        public PasswordHasher(IPasswordHasher<Object> identityHasher)
        {
            _identityHasher = identityHasher;
        }
        public string HashPassword(string password)
        {
            return _identityHasher.HashPassword(new object(), password);
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            var result = _identityHasher.VerifyHashedPassword(new object(), storedHash, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}
