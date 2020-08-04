using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public interface IFriendService
    {
        void Request(Profile requestedBy, Profile requestedTo);
        Friend Accept(int requestedById, int requestedToId);
        Friend Reject(int requestedById, int requestedToId);
        IEnumerable<Friend> GetAll();
        IEnumerable<Friend> GetAll(int profileId);
        Friend GetById(int requestedById, int requestedToId);
        IEnumerable<Friend> GetAllReceivedRequests(int requestedToId);
        IEnumerable<Friend> GetAllSentRequests(int requestedById);
        IEnumerable<Friend> GetAllReceivedRequestsAwaiting(int requestedToId);
        IEnumerable<Friend> GetAllSentRequestsAwaiting (int requestedById);
    }
}
