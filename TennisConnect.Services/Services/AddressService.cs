using System;
using System.Collections.Generic;
using System.Text;
using TennisConnect.Data;

namespace TennisConnect.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly TennisConnectDbContext _context;

        public AddressService(TennisConnectDbContext context)
        {
            _context = context;
        }

        public Address Create(Address address)
        {
            if (DuplicateCheck(address))
            {
                return address;
            }

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DuplicateCheck(Address address)
        {
            var addresses = GetAll();

            foreach (var ad in addresses)
            {
                if (ad.NumberSupplement == address.NumberSupplement && ad.StreetName == address.StreetName && ad.PostCode == address.PostCode)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses;
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Find(id);
        }

        public Address Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
