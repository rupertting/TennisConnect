namespace TennisConnect.Data.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClub { get; set; }
        public Address Address { get; set; }
    }
}