using System;

namespace TennisConnect.Web.Models
{
    public class ProfileModel
    {
        public int UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressModel AddressModel { get; set; }
        public int ClubId { get; set; }
        public string Rating { get; set; }
        public string Bio { get; set; }
    }
}
