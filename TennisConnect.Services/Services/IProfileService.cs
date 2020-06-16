using System;
using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetAllProfiles();
        public Profile GetProfile(int profileId);
        public Profile CreateProfile(int userId, DateTime dateOfBirth, Address address, string rating, string bio, int clubId);
        public void DeleteProfile(int profileId); 
    }
}
