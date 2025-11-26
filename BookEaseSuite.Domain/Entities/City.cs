namespace BookEaseSuite.Domain.Entities
{
    public class City : BaseEntity
    {
        public string? Name { get; set; }
        public long CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
