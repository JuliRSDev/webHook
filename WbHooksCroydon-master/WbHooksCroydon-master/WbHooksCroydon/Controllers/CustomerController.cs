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
        public string Post([FromBody] Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return "Add";
                } else { return "Error"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Customer/5
        public string Put(int id, [FromBody]Customer customer)
        {
            try
            {
                var id_customer = db.Customer.Find(id);
                if (id_customer != null && customer != null)
                {
                    db.Entry(id_customer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                } else { return "Error"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Customer/5
        public string Delete(int id)
        {
            try
            {
                var id_customer = db.Customer.Find(id);
                if (id_customer != null)
                {
                    db.Customer.Remove(id_customer);
                    db.SaveChanges();
                    return "Delete";
                } else { return "Error"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }
    }
}
