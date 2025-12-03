using BookEaseSuite.Domain.Enums;

namespace BookEaseSuite.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime? LastLoginUtc { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsLocked { get; set; } = false;
        public DateTime? LockedTill { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneNumberConfirmed { get; set; } = false;
        public string? PhoneNumberVerificationCode { get; set; }
        public DateTime? PhoneNumberVerificationCodeExpires { get; set; }
        public string? EmailVerificationToken { get; set; }
        public DateTime? EmailVerificationTokenExpires { get; set; }
        public string? PasswordResetCode { get; set; }
        public DateTime? PasswordResetCodeExpires { get; set; }
        public long CountryId { get; set; }
        public Country? Country { get; set; }
        public long CityId { get; set; }
        public City? City { get; set; }
    }
}
