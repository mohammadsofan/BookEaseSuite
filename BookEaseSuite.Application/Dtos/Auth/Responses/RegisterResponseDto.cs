using BookEaseSuite.Domain.Enums;

namespace BookEaseSuite.Application.Dtos.Auth.Responses
{
    public class RegisterResponseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRole UserRole { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
    }
}
