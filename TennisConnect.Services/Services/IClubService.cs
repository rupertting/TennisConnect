using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public interface IClubService
    {
        public IEnumerable<Club> GetAll();
        public Club GetById(int id);
    }
}
