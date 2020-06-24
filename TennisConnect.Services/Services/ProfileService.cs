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
        private readonly IUserService _userService;
        private readonly IClubService _clubService;
        private readonly IAddressService _addressService;

        public ProfileService(TennisConnectDbContext context, IUserService userService, IClubService clubService, IAddressService addressService)
        {
            _context = context;
            _userService = userService;
            _clubService = clubService;
            _addressService = addressService;
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
            var duplicatedAddress = _addressService.GetByUniqueIdentifier(profile.Address.UniqueIdentifier);

            if (duplicatedAddress == null)
            {
                _context.Profiles.Add(profile);
            }
            else
            {
                profile.Address = null;
                _context.Profiles.Add(profile);
                profile.Address = duplicatedAddress;
            }

            _context.SaveChanges();
            return profile;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> GetAll()
        {
            return _context.Profiles
                 .Include(profile => profile.User)
                 .Include(profile => profile.Address)
                 .Include(profile => profile.Club)
                 .ThenInclude(club => club.Venue)
                 .ThenInclude(venue => venue.Address);
        }

        public Profile GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(profile => profile.Id == id);
        }

        public Profile Update(Profile updatedProfile)
        {
            var profile = GetById(updatedProfile.Id);

            if(updatedProfile.DateOfBirth != null)
            {
                profile.DateOfBirth = updatedProfile.DateOfBirth;
            }

            if(updatedProfile.Address != null)
            {
                profile.Address = updatedProfile.Address;
            }
            
            if(updatedProfile.Rating != profile.Rating)
            {
                profile.Rating = updatedProfile.Rating;
            }
            
            if(updatedProfile.Club != null)
            {
                profile.Club = updatedProfile.Club;
            }
            
            if(updatedProfile.Available != profile.Available)
            {
                profile.Available = updatedProfile.Available;
            }
            
            if(updatedProfile.Bio != profile.Bio)
            {
                profile.Bio = updatedProfile.Bio;
            }
           
            _context.Profiles.Update(profile);
            _context.SaveChanges();

            return profile;
        }
    }
}
