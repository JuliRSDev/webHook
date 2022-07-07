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
    public class ProductController : ApiController
    {
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return db.Product.ToList<Product>();
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return db.Product.Find(id);
        }

        // POST: api/Product
        public string Post([FromBody] Product product)
        {
            try
            {
                if (product != null)
                {
                    db.Product.Add(product);
                    db.SaveChanges();
                    return "Add";
                }
                else
                {
                    return "Not Add, Not Found";
                }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Product/5
        public string Put(int id, [FromBody] Product product)
        {
            try
            {
                if (product != null)
                {
                    product.id = id;
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                }
                else
                {
                    return "Not Update, Not Found";
                }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Product/5
        public string Delete(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                if (product != null)
                {
                    db.Product.Remove(product);
                    db.SaveChanges();
                    return "Delete";
                }
                else
                {
                    return "Not Delete, Not Found";
                }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }
    }
}
