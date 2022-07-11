using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WbHooksCroydon.Domain.Yuju.Models;
using WbHooksCroydon.Models.DataBase;

namespace WbHooksCroydon.Controllers
{
    public class OrderDetailController : ApiController
    {
        // GET: api/OrderDetail
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        public IEnumerable<OrderDetail> Get()
        {
            return db.OrderDetail.ToList();
        }

        // GET: api/OrderDetail/5
        public OrderDetail Get(int id)
        {
            return db.OrderDetail.Find(id);
        }

        // POST: api/OrderDetail
        public string Post([FromBody] OrderDetail orderDetail)
        {
            try
            {
                if (orderDetail != null)
                {
                    db.OrderDetail.Add(orderDetail);
                    db.SaveChanges();
                    return "Add";
                } else { return "Not Add, Error"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/OrderDetail/5
        public string Put(int id, [FromBody] OrderDetail orderDetail)
        {
            try
            {
                var id_orderDetail = db.OrderDetail.Find(id);
                if (id_orderDetail != null && orderDetail != null)
                {
                    orderDetail.id = id;
                    db.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                } else { return "Not Found"; }
            }
            catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/OrderDetail/5
        public string Delete(int id)
        {
            try
            {
                var order = db.OrderDetail.Find(id);
                if (order != null)
                {
                    db.OrderDetail.Remove(order);
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
