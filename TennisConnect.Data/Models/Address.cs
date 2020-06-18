using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TennisConnect.Data
{
    public class Address
    {
        public int Id { get; set; }
        public string NumberSupplement { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        private string uniqueIdentifier;
        [Required]
        public string UniqueIdentifier
        {
            get
            {
                uniqueIdentifier = string.Join(string.Empty, new string[]{NumberSupplement, StreetName,Town,PostCode})
                    .ToLowerInvariant();
                uniqueIdentifier = Regex.Replace(uniqueIdentifier, @"\s+", "");

                return uniqueIdentifier;
            }
            set
            {
                uniqueIdentifier = value;
            }
        }
    }
}