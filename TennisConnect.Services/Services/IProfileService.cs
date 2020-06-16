using System;
using System.Collections.Generic;
using TennisConnect.Data.Models;

namespace TennisConnect.Services.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetAllProfiles();
        public Profile GetProfile(int profileId);
        public Profile CreateProfile(int userId, DateTime dateOfBirth, int addressId, bool available, Rating rating, string bio, Club club);
        public void DeleteProfile(int profileId); 
    }
}
