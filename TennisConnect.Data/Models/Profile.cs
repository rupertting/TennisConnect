using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TennisConnect.Data
{
    public class Profile
    {
        public Profile()
        {
            SentFriendRequests = new List<Friend>();
            ReceivedFriendRequests = new List<Friend>();
        }

        public int Id { get; set; }
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public bool Available { get; set; }
        public Club Club { get; set; }
        public Rating Rating { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Friend> SentFriendRequests { get; set; }
        public virtual ICollection<Friend> ReceivedFriendRequests { get; set; }
        [NotMapped]
        public virtual ICollection<Friend> SentFriendRequestsAwaiting { get; set; }
        [NotMapped]
        public virtual ICollection<Friend> ReceivedFriendRequestsAwaiting { get; set; }
        [NotMapped]
        public virtual ICollection<Friend> Friends
        {
            get
            {
                var friends = SentFriendRequests.Where(x => x.Approved).ToList();
                friends.AddRange(ReceivedFriendRequests.Where(x => x.Approved));
                return friends;
            }
        }
    }
}
