using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public class ClubService : IClubService
    {
        private readonly TennisConnectDbContext _context;

        public ClubService(TennisConnectDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Club> GetAll()
        {
            return _context.Clubs
                .Include(club => club.Venue)
                .ThenInclude(venue => venue.Address);
        }

        public Club GetById(int id)
        {
            return GetAll().FirstOrDefault(club => club.Id == id);
        }
    }
}
