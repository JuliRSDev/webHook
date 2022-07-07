using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WbHooksCroydon.Domain.Yuju.NetWork;
using WbHooksCroydon.Log4Net;
using WbHooksCroydon.Models.DataBase;
using WbHooksCroydon.WebHooksRecivers;

namespace WbHooksCroydon.Handlers
{
    public class YujuWebHookHandler : WebHookHandler
    {
        public YujuWebHookHandler()
        {
            this.Receiver = YujuWebHookReceiver.HookName;
        }
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            //response.Content = new System.Net.Http.StringContent(receiver);
            //context.Response = response;
            var headers = context.Request.Headers;
            List<string> AllRequestHeaders = new List<string>();
            AllRequestHeaders.Add("X-Madkting-event");
            AllRequestHeaders.Add("X-Madkting-signature");
            AllRequestHeaders.Add("X-Madkting-delivery");
            AllRequestHeaders.Add("location");

            Dictionary<string, string> headerYuju = new Dictionary<string, string>();

            foreach (var header in context.Request.Headers)
            {
                if (AllRequestHeaders.Contains(header.Key))
                {
                    headerYuju.Add(header.Key, header.Value.FirstOrDefault());
                }
            }
            string logReg = "";
            foreach (var header in headerYuju)
            {
                logReg += string.Format("\n\r{0} == {1}\n\r", header.Key, header.Value);
            }
            MarketPlaceHooksContext db = new MarketPlaceHooksContext();
            var e = db.Database.CreateIfNotExists();
            var order = YujuClient.Instance.GetOrderDetail(context.Data.ToString());
            var responseOrder = YujuClient.Instance.GetOrder(context.Data.ToString());
            switch (responseOrder.marketplace_pk)
            {
                // Mercado Libre Colombia
                case 15:
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        db.orders.Add(new orders_hooks() { market_place_id = responseOrder.marketplace_pk.ToString(), 
                            order_id = guid.ToString(), seller_id = guid.ToString() });
                        db.SaveChanges();
                    }catch(EntityException ex)
                    {
                        ex.Message.ToString();
                    }
                    break;
                // Linio Colombia
                case 17:
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        db.orders.Add(new orders_hooks() { market_place_id = responseOrder.marketplace_pk.ToString(), 
                            order_id = guid.ToString(), seller_id = guid.ToString() });
                        db.SaveChanges();
                    }
                    catch (EntityException ex)
                    {
                        ex.Message.ToString();
                    }
                    break;
                default:
                    break;
            }
            Logs.Intance.log.Info(logReg);
            return Task.FromResult(true);
        }
    }
}