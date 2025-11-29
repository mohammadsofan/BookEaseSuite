namespace BookEaseSuite.Application.Dtos.Country.Responses
{
    public class CountryResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
