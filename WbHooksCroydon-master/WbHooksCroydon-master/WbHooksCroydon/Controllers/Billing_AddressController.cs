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
    public class Billing_AddressController : ApiController
    {
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        // GET: api/Billing_Address
        public IEnumerable<Billing_Address> Get()
        {
            return db.Billing_Address.ToList<Billing_Address>();
        }

        // GET: api/Billing_Address/5
        public Billing_Address Get(int id)
        {
            return db.Billing_Address.Find(id);
        }

        // POST: api/Billing_Address    
        public string Post([FromBody] Billing_Address billing_Address)
        {
            try
            {
                if (billing_Address != null)
                {
                    db.Billing_Address.Add(billing_Address);
                    db.SaveChanges();
                    return "Add";
                } else { return "Not Add, Error"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Billing_Address/5
        public string Put(int id, [FromBody] Billing_Address billing_Address)
        {

            try
            {
                var id_billing_Address = db.Billing_Address.Find(id);
                if (id_billing_Address != null && billing_Address != null)
                {
                    billing_Address.id = id;
                    db.Entry(billing_Address).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                } else { return "Not Found"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Billing_Address/5
        public string Delete(int id)
        {
            try
            {
                var billing_Address = db.Billing_Address.Find(id);
                if (billing_Address != null)
                {
                    db.Billing_Address.Remove(billing_Address);
                    db.SaveChanges();
                    return "Delete";
                } else { return "Not Found"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }
    }
}
