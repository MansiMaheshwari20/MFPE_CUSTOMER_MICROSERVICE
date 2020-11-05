using MFPE_CustomerApi.Models;
using MFPE_CustomerApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CustomerApi.Provider
{
    public class CustomerProvider : IProvider<Customer>
    {
        IRepository<Customer> _custom;


        public CustomerProvider(IRepository<Customer> custrepo)
        {
            _custom = custrepo;

        }
        public void Add(Customer item)
        {
            _custom.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            return _custom.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _custom.GetAll();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
