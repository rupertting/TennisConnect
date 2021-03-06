﻿using System;
using System.Collections.Generic;
using System.Text;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        Address GetById(int id);
        Address Update(Address updatedAddress);
        void Delete(int id);
        Address Create(Address address);
        Address GetByUniqueIdentifier(string addressUniqueIdentifier);
    }
}
