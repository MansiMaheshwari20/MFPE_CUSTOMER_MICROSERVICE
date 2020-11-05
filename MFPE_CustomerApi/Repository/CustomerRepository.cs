using MFPE_CustomerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace MFPE_CustomerApi.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        public static List<Customer> products = new List<Customer>()
        {
            new Customer {CustomerId = 1, Name = "Riya", Address = "Ballupur Road, Dehradun",  PANno = "DCRP124" , DOB = Convert.ToDateTime("1998-11-20 01:02:01 AM")},
            new Customer {CustomerId = 2, Name = "Reema", Address = "Vijay Colony, Delhi", PANno = "DCRP23456", DOB = Convert.ToDateTime("1999-11-10 02:02:01 AM")}
            
        };
        public bool Add(Customer item)
        {
            products.Add(item);
            return true;
        }

        
        public Customer Get(int id)
        {
            return products.Find(p => p.CustomerId == id);
        }
        

        public IEnumerable<Customer> GetAll()
        {
            return products.ToList();
        }
        

       
    }
}
