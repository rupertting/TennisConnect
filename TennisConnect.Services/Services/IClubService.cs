using System.Collections.Generic;
using TennisConnect.Data.Models;

namespace TennisConnect.Services.Services
{
    public interface IClubService
    {
        public IEnumerable<Club> GetAllClubs();
        public Club GetClub(int clubId);
    }
}
