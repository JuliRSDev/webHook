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
            Guid guid = Guid.NewGuid();
            /*
             * https://api.software.madkting.com/shops/1086553/marketplace/15/orders/2000003841425110/
             * "cart_orders": [
                "2000003841421322",
                "2000003841421320",
                "2000003841425110",
                "2000003841417650"
                ],
             */
            switch (responseOrder.marketplace_pk)
            {
                // Mercado Libre Colombia || Mercado Shop Colombia
                case 15:
                    string marketplace = "Libre";
                    foreach (var tag in responseOrder.tags)
                    {
                        if (tag == "mshops") { marketplace = "Shop"; }
                    }
                    Console.WriteLine(marketplace);
                    break;
                // Linio Colombia
                case 17:
                    try
                    {
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
            if (responseOrder.cart_orders.Count > 0)
            {
                // Tiene mas de una orden

            }
            else
            {
                // Solo tiene una orden

            }
            Logs.Intance.log.Info(logReg);
            return Task.FromResult(true);
        }
    }
}