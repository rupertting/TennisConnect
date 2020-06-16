namespace TennisConnect.Data
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClub { get; set; }
        public Address Address { get; set; }
    }
}