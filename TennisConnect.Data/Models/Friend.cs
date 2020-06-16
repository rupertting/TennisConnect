using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisConnect.Data
{
    public class Friend
    {
        [Key, Column(Order = 0)]
        public int RequestedById { get; set; }
        [Key, Column(Order = 1)]
        public int RequestedToId { get; set; }
        public Profile RequestedBy { get; set; }
        public Profile RequestedTo { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? BecameFriendsTime { get; set; }
        public FriendRequestFlag FriendRequestFlag { get; set; }
        [NotMapped]
        public bool Approved => FriendRequestFlag == FriendRequestFlag.Approved;
        public void AddFriendRequest(Profile byProfile, Profile forProfile)
        {
            var friendRequest = new Friend()
            {
                RequestedBy = byProfile,
                RequestedTo = forProfile,
                RequestTime = DateTime.Now,
                FriendRequestFlag = FriendRequestFlag.None
            };
            byProfile.SentFriendRequests.Add(friendRequest);
        }

    }
}
