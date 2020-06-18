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
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return address;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
