using System;
using System.Collections.Generic;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public interface IProfileService
    {
        public IEnumerable<Profile> GetAll();
        public Profile GetById(int id);
        public Profile Create(int userId, DateTime dateOfBirth, Address address, string rating, string bio, int clubId);
        public void Delete(int id);
        public Profile Update(Profile updatedProfile);
        public Profile GetByUserId(int userId);
    }
}
