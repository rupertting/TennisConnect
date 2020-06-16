using System;
using System.Collections.Generic;
using TennisConnect.Data.Models;

namespace TennisConnect.Services.Services
{
    public class ProfileService : IProfileService
    {
        public Profile CreateProfile(int userId, DateTime dateOfBirth, int addressId, bool available, Rating rating, string bio, Club club)
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
