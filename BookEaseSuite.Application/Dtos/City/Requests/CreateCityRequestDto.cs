namespace BookEaseSuite.Application.Dtos.City.Requests
{
    public class CreateCityRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public long CountryId { get; set; }
    }
}
