using System;
using System.Collections.Generic;
using TennisConnect.Data.Models;

namespace TennisConnect.Services.Services
{
    public class ProfileService : IProfileService
    {
        public Profile CreateProfile(int userId, DateTime dateOfBirth, int addressId, int contactDetailsId, bool available, Rating rating, string bio, ICollection<Club> clubs)
        {
            throw new NotImplementedException();
        }

        public void DeleteProfile(int profileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            throw new NotImplementedException();
        }

        public Profile GetProfile(int profileId)
        {
            throw new NotImplementedException();
        }
    }
}
