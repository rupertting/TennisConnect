using System;
using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Web.Models
{
    public class CompletedProfileModel
    {
        public UserModel UserModel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Club Club { get; set; }
        public string Rating { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<FriendModel> SentFriendRequests { get; set; }
        public virtual ICollection<FriendModel> ReceivedFriendRequests { get; set; }
        public virtual ICollection<FriendModel> Friends { get; set; }

    }
}
