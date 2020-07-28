using System;
using TennisConnect.Data;

namespace TennisConnect.Web.Models
{
    public class FriendModel
    {
        public int RequestedById { get; set; }
        public int RequestedToId { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? BecameFriendsTime { get; set; }
        public FriendRequestFlag FriendRequestFlag { get; set; }
        public int? FriendId { get; set; }
    }
}