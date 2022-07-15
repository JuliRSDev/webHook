using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace WbHooksCroydon.WebHooksRecivers
{
    public class YujuWebHookReceiver : WebHookReceiver
    {
        public override string Name
        {
            get { return HookName; }
        }

        internal const string HookName = "Yuju";
        public override async Task<HttpResponseMessage> ReceiveAsync(string id, HttpRequestContext context, HttpRequestMessage request)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));   
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Method != HttpMethod.Post)
            {
                return CreateBadMethodResponse(request);
            }

            List<string> AllRequestHeaders = new List<string>();
            AllRequestHeaders.Add("X-Madkting-event");
            AllRequestHeaders.Add("X-Madkting-signature");
            AllRequestHeaders.Add("X-Madkting-delivery");
            AllRequestHeaders.Add("location");

            Dictionary<string, string> headerYuju = new Dictionary<string, string>();

            foreach (var header in request.Headers)
            {
                if (AllRequestHeaders.Contains(header.Key))
                {
                    headerYuju.Add(header.Key, header.Value.FirstOrDefault());
                }
            }

            string data = headerYuju.Where(a => a.Key == "location").FirstOrDefault().Value;
            string action = "test";
            return await ExecuteWebHookAsync(id, context, request, new[] { action }, data);
        }
    }
}