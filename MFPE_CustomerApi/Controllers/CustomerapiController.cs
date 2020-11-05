using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using MFPE_CustomerApi.Models;
using MFPE_CustomerApi.Provider;
using MFPE_CustomerApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MFPE_CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerapiController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerapiController));
        IProvider<Customer> _cust;
        

        public CustomerapiController(IProvider<Customer> custprov)
        {
            _cust = custprov;
            
        }
        // GET: api/Customerapi
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            _log4net.Info("Get Api Initiated");
            return _cust.GetAll();
        }

        // GET: api/Customerapi/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult getCustomerDetails(int id)
        {
            if (id == 0)
            {
                _log4net.Warn("User has sent some invalid CustomerId");
                return NotFound();
            }
            Customer listCustomer = new Customer();
            listCustomer = _cust.Get(id);
            _log4net.Info("Customer's Details has been successfully returned");
            return Ok(listCustomer);
        }
        
        // POST: api/Customerapi
        [HttpPost]
        public IActionResult createCustomer([FromBody]Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }

            _cust.Add(customer);
            _log4net.Info("Customer has been successfully created");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44369");
            HttpResponseMessage response1 = client.PostAsJsonAsync("api/Account/createAccount", new { CustomerId = Convert.ToInt32(customer.CustomerId) }).Result;
            var result1 = response1.Content.ReadAsStringAsync().Result;
            AccountCreationStatus st = JsonConvert.DeserializeObject<AccountCreationStatus>(result1);

            CustomerCreationStatus cts = new CustomerCreationStatus();
            cts.Message = "Customer and its account has been successfully created.";
            cts.CustomerId = customer.CustomerId;
            return Ok(cts);
            
        }

        // PUT: api/Customerapi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
