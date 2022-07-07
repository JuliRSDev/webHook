using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Models.SellerCenter
{
    public class GetWebhookEntities
    {
        [JsonProperty("event")]
        public string _event { get; set; }
        public Payload payload { get; set; }
    }

    public class Payload
    {
        public string OrderId { get; set; }
        public string[] OrderItemIds { get; set; }
        public string NewStatus { get; set; }
        public string[] SellerSkus { get; set; }
        public string Feed { get; set; }
    }
}