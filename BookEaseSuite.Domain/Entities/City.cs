namespace BookEaseSuite.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public long CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
