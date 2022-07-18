using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WbHooksCroydon.Domain.Yuju.Models;
using WbHooksCroydon.Domain.Yuju.NetWork;
using WbHooksCroydon.Log4Net;
using WbHooksCroydon.Models.DataBase;
using WbHooksCroydon.Models.ViewModel;
using WbHooksCroydon.WebHooksRecivers;

namespace WbHooksCroydon.Handlers
{
    public class YujuWebHookHandler : WebHookHandler
    {
        string urlService = "https://api.software.madkting.com/shops/1086553/marketplace/";
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

            string marketplace = "m_libre";
            if (responseOrder.marketplace_pk == 15)
            {
                foreach (var tag in responseOrder.tags)
                {
                    if (tag == "mshops") { marketplace = "m_shops"; }
                }
            } else { marketplace = "m_linio"; }

            double? total = 0;

            try
            {
                db.Customer.Add(new Customer()
                {
                    first_name = responseOrder.customer.first_name,
                    last_name = responseOrder.customer.last_name,
                    email = responseOrder.customer.email,
                    phone = responseOrder.customer.phone,
                    nickname = responseOrder.customer.nickname,
                    customer_id = responseOrder.customer.customer_id,
                    doc_number = responseOrder.customer.doc_number,
                    doc_type = responseOrder.customer.doc_type
                });
                db.SaveChanges();

            } catch (EntityException ex) { ex.Message.ToString(); }

            if (responseOrder.cart_orders.Count > 0)
            {
                foreach (var cart_order in responseOrder.cart_orders)
                {
                    var responseOrders = YujuClient.Instance.GetOrder
                        (urlService + responseOrder.marketplace_pk.ToString() +
                       "/orders/" + cart_order.ToString() + "/");
                }
                total = responseOrder.extra.cart_total;

            } else { total = responseOrder.total; }

            Logs.Intance.log.Info(logReg);
            return Task.FromResult(true);
        }
    }
}