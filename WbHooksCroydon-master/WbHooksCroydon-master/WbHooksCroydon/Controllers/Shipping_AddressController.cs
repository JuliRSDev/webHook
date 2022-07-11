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
    public class Shipping_AddressController : ApiController
    {
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        // GET: api/Shipping_Address
        public IEnumerable<Shipping_Address> Get()
        {
            return db.Shipping_Address.ToList<Shipping_Address>();
        }

        // GET: api/Shipping_Address/5
        public Shipping_Address Get(int id)
        {
            return db.Shipping_Address.Find(id);
        }

        // POST: api/Shipping_Address
        public string Post([FromBody]Shipping_Address shipping_Address)
        {
            try
            {
                if(shipping_Address != null)
                {
                    db.Shipping_Address.Add(shipping_Address);
                    db.SaveChanges();
                    return "Add";
                }
                return "Not Add, Error";
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Shipping_Address/5
        public string Put(int id, [FromBody] Shipping_Address shipping_Address)
        {
            try
            {
                var id_shipping_Address = db.Shipping_Address.Find(id);
                if (id_shipping_Address != null && shipping_Address != null)
                {
                    shipping_Address.id = id;
                    db.Entry(shipping_Address).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                } else { return "Not Found"; }
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Shipping_Address/5
        public string Delete(int id)
        {
            try
            {
                var shipping_Address = db.Shipping_Address.Find(id);
                if(shipping_Address != null)
                {
                    db.Shipping_Address.Remove(shipping_Address);
                    db.SaveChanges();
                    return "Delete";
                } else { return "Not Found"; }
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }
    }
}
