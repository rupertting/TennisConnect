using System;
using System.Collections.Generic;

namespace TennisConnect.Data.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public bool Available { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
        public Rating Rating { get; set; }
        public string Bio { get; set; }
    }
}
