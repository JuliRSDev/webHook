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
    public class ProgressController : ApiController
    {
        MarketPlaceHooksContext db = new MarketPlaceHooksContext();
        // GET: api/Progress
        public IEnumerable<Progress> Get()
        {
            return db.Progress.ToList<Progress>();
        }

        // GET: api/Progress/5
        public Progress Get(int id)
        {
            return db.Progress.Find(id);
        }

        // POST: api/Progress
        public string Post([FromBody]Progress progress)
        {
            try
            {
                if(progress != null)
                {
                    db.Progress.Add(progress);
                    db.SaveChanges();
                    return "Add";
                }
                return "Not Add, Not Found";
            }catch(EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // PUT: api/Progress/5
        public string Put(int id, [FromBody] Progress progress)
        {
            try
            {
                progress.id = id;
                if (progress != null)
                {
                    db.Entry(progress).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return "Update";
                }
                return "Not Update, Not Found";
            } catch (EntityException e)
            {
                return e.Message.ToString();
            }
        }

        // DELETE: api/Progress/5
        public string Delete(int id)
        {
            try
            {
                var progress = db.Progress.Find(id);
                if (progress  != null)
                {
                    db.Progress.Remove(progress);
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
