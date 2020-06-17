using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public interface IFriendService
    {
        void Request(int requestedById, int requestedToId);
        Friend Accept(int requestedById, int requestedToId);
        Friend Reject(int requestedById, int requestedToId);
        IEnumerable<Friend> GetAll();
        Friend GetById(int requestedById, int requestedToId);
        IEnumerable<Friend> GetAllReceivedRequests(int requestedToId);
        IEnumerable<Friend> GetAllSentRequests(int requestedById);
    }
}
