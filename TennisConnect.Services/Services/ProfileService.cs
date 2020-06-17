using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public class ProfileService : IProfileService
    {
        private readonly TennisConnectDbContext _context;
        private IUserService _userService;
        private IClubService _clubService;
        private IFriendService _friendService;

        public ProfileService(TennisConnectDbContext context, IUserService userService, IClubService clubService, IFriendService friendService)
        {
            _context = context;
            _userService = userService;
            _clubService = clubService;
            _friendService = friendService;
        }

        public Profile Create(int userId, DateTime dateOfBirth, Address address, string rating, string bio, int clubId)
        {
            var user = _userService.GetById(userId);
            var club = _clubService.GetById(clubId);

            Enum.TryParse(rating, true, out Rating parsedRating);

            var profile = new Profile
            {
                User = user,
                DateOfBirth = dateOfBirth,
                Address = address,
                Rating = parsedRating,
                Club = club,
                Available = true,
                Bio = bio
            };

            _context.Profiles.Add(profile);
            _context.SaveChanges();

            return profile;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> GetAll()
        {
            var profiles = _context.Profiles
                .Include(profile => profile.User)
                .Include(profile => profile.Address)
                .Include(profile => profile.Club)
                .ThenInclude(club => club.Venue)
                .ThenInclude(venue => venue.Address);

            foreach (var profile in profiles)
            {
                profile.SentFriendRequests = _friendService.GetAllSentRequests(profile.Id).ToList();
                profile.ReceivedFriendRequests = _friendService.GetAllReceivedRequests(profile.Id).ToList();
            }

            return profiles;
        }

        public Profile GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(profile => profile.Id == id);
        }
    }
}
