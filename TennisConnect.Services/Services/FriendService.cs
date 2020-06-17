using System;
using System.Collections.Generic;
using System.Linq;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public class FriendService : IFriendService
    {
        private readonly TennisConnectDbContext _context;

        public FriendService(TennisConnectDbContext context)
        {
            _context = context;
        }

        public Friend Accept(int requestedById, int requestedToId)
        {
            var friend = GetById(requestedById, requestedToId);

            if (friend == null)
                throw new Exception("Friend request not found");

            friend.FriendRequestFlag = FriendRequestFlag.Approved;
            friend.BecameFriendsTime = DateTime.Now;

            _context.Friends.Update(friend);
            _context.SaveChanges();

            return friend;
        }

        public IEnumerable<Friend> GetAll()
        {
            return _context.Friends;
        }

        public IEnumerable<Friend> GetAllReceivedRequests(int requestedToId)
        {
            var result = GetAll().Where(friend => friend.RequestedToId == requestedToId
                && friend.FriendRequestFlag == FriendRequestFlag.None);

            return GetAll().Where(friend => friend.RequestedToId == requestedToId
                && friend.FriendRequestFlag == FriendRequestFlag.None);
        }

        public IEnumerable<Friend> GetAllSentRequests(int requestedById)
        {
            var result = GetAll().Where(friend => friend.RequestedById == requestedById
                && friend.FriendRequestFlag == FriendRequestFlag.None);

            return GetAll().Where(friend => friend.RequestedById == requestedById
                && friend.FriendRequestFlag == FriendRequestFlag.None);
        }

        public Friend GetById(int requestedById, int requestedToId)
        {
            return GetAll().FirstOrDefault(friend => friend.RequestedById == requestedById 
                && friend.RequestedToId == requestedToId);
        }

        public Friend Reject(int requestedById, int requestedToId)
        {
            var friend = GetById(requestedById, requestedToId);

            if (friend == null)
                throw new Exception("Friend request not found");

            friend.FriendRequestFlag = FriendRequestFlag.Rejected;

            _context.Friends.Update(friend);
            _context.SaveChanges();

            return friend;
        }

        public void Request(Profile requestedBy, Profile requestedTo)
        {
            var friend = new Friend
            {
                RequestedBy = requestedBy,
                RequestedTo = requestedTo,
                RequestTime = DateTime.Now,
                BecameFriendsTime = null,
                FriendRequestFlag = FriendRequestFlag.None,
            };

            _context.Friends.Add(friend);
            _context.SaveChanges();
        }
    }
}
