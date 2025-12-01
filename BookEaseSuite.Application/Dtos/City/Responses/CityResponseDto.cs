namespace BookEaseSuite.Application.Dtos.City.Responses
{
    public class CityResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long CountryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
