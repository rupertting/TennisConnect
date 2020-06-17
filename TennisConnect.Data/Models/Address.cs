using System.ComponentModel.DataAnnotations;

namespace TennisConnect.Data
{
    public class Address
    {
        public int Id { get; set; }
        public string NumberSupplement { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        [Required]
        public string UniqueIdentifier { get; set; }
    }
}