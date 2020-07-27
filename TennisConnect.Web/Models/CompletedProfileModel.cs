using System;
using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Web.Models
{
    public class CompletedProfileModel
    {
        public int Id { get; set; }
        public UserModel UserModel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Club Club { get; set; }
        public string Rating { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<FriendModel> SentFriendRequestsAwaiting { get; set; }
        public virtual ICollection<FriendModel> ReceivedFriendRequestsAwaiting { get; set; }
        public virtual ICollection<FriendModel> Friends { get; set; }

    }
}
