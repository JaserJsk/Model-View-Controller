using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcMedEntityFramework.Data.Repositories
{
    public interface IAddressRepository
    {
        void Add(Address address);
        void Delete(Guid id);
        IEnumerable<Address> All();
        Address Find(Expression<Func<Address, bool>> predicate);
    }
    
    public class AddressRepository : IAddressRepository
    {
        // repository.Find(x => x.Id == Guid.Empty);
        public Address Find(Expression<Func<Address, bool>> predicate)
        {
            using (var context = new MyDataContext())
            {
                return context.Addresses.Single(predicate);
            }
        }

        public void Add(Address address)
        {
            using (var context = new MyDataContext())
            {
                var newAddress = new Address
                {
                    StreetName = address.StreetName,
                    StreetNumber = address.StreetNumber
                };

                context.Addresses.Add(newAddress);

                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new MyDataContext())
            {
                var address = context.Addresses.Single(x => x.Id == id);

                context.Addresses.Remove(address);

                context.SaveChanges();
            }
        }

        public IEnumerable<Address> All()
        {
            using (var context = new MyDataContext())
            {
                return context.Addresses.ToList();
            }
        }
    }
}
