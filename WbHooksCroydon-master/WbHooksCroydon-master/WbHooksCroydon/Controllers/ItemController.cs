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
    public class ItemController : ApiController
    {
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        // GET: api/Item
        public IEnumerable<Item> Get()
        {
            return db.Item.ToList<Item>();
        }

        // GET: api/Item/5
        public Item Get(int id)
        {
            return db.Item.Find(id);
        }

        // POST: api/Item
        public string Post([FromBody] Item item)
        {
            try
            {
                if (item != null)
                {
                    db.Item.Add(item);
                    db.SaveChanges();
                    return "Add";
                } else { return "Not Add, Error"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Item/5
        public string Put(int id, [FromBody] Item item)
        {
            try
            {
                var id_item = db.Item.Find(id);
                if (id_item != null && item != null)
                {
                    item.id = id;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                } else { return "Not Found"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Item/5
        public string Delete(int id)
        {
            try
            {
                var item = db.Item.Find(id);
                if (item != null)
                {
                    db.Item.Remove(item);
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
