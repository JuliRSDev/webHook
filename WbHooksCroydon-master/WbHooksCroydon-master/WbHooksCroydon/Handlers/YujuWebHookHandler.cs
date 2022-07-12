using AutoMapper;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

            string marketplace = "";
            if (responseOrder != null && responseOrder.marketplace_pk == 15)
            {
                marketplace = "Libre";
                foreach (var tag in responseOrder.tags)
                {
                    if (tag == "mshops") { marketplace = "Shops"; }
                }
            } else { marketplace = "Linio"; }

            double? total = 0;
            if (marketplace != null)
            {
                try
                {
                    db.Customer.Add(new Customer() {
                        first_name = responseOrder.customer.first_name,
                        last_name = responseOrder.customer.last_name,
                        email = responseOrder.customer.email,
                        phone = responseOrder.customer.phone,
                        doc_number = responseOrder.customer.doc_number
                    });
                    db.SaveChanges();
                } catch (EntityException ex) { ex.Message.ToString(); }

                if(responseOrder.cart_orders.Count > 0)
                {
                    // mas ordenes
                    foreach (var cart_order in responseOrder.cart_orders)
                    {

                        try
                        {
                            var rest = get(urlService + responseOrder.marketplace_pk + "/orders/" + cart_order.ToString());
                            var x = rest.Result;
                        }
                        catch (Exception ex)
                        {
                            string mensaje =  ex.Message.ToString();
                            throw;
                        }

                        //var responseOrder1 = YujuClient.Instance.GetOrder(
                        //    urlService + responseOrder.marketplace_pk + "/orders/" + cart_order.ToString());
                        //total += x.total;
                    }
                } else { total = responseOrder.total; }
            }

            Logs.Intance.log.Info(logReg);
            return Task.FromResult(true);
        }
        private async Task<ResponseOrder> get(string url) {

            var consulta = new HttpClient();          
            consulta.DefaultRequestHeaders.Add("Authorization", "Token 3fe510b1ecec4283d719a027132b88ebf55130f9");
            var resultado = await consulta.GetAsync(url);
            var responseBody = await resultado.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
        }
    }
}