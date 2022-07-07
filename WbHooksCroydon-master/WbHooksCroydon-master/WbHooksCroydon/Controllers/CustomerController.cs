using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WbHooksCroydon.Domain.Yuju.Models;
using WbHooksCroydon.Models.DataBase;

namespace WbHooksCroydon.Controllers
{
    public class CustomerController : ApiController
    {
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            return db.Customer.ToList<Customer>();
        }

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            return db.Customer.Find(id);
        }

        // POST: api/Customer
        public string Post([FromBody]Customer customer)
        {
            try
            {
                if(customer != null)
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return "Add";
                }
                return "Not Add, Not Found";
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Customer/5
        public string Put(int id, [FromBody]Customer customer)
        {
            try
            {
                if(customer != null)
                {
                    customer.id = id;
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                }
                return "Not Update, Not Found";
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Customer/5
        public string Delete(int id)
        {
            try
            {
                var customer = db.Customer.Find(id);
                if(customer != null)
                {
                    db.Customer.Remove(customer);
                    db.SaveChanges();
                    return "Delete";
                }
                return "Not Delete, Not Found";
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }
    }
}
