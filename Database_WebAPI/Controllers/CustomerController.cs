using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerDataAccess;

namespace Database_WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                return entities.Customer.ToList();
            }
        }


        public Customer Get(int id)
        {
            using(CustomerEntities entities = new CustomerEntities())
            {
                return entities.Customer.FirstOrDefault(e => e.Id == id);
            }
        }

        public Customer Post(Customer customer)
        {
   
            using(CustomerEntities entities = new CustomerEntities())
            {
                entities.Customer.Add(new Customer()
                {
                    Name = "Poopoo"
                });
                entities.SaveChanges();
                return entities.Customer.FirstOrDefault();
            }
         
            
        }
	
        
    }
}
