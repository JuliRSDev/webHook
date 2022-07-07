using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using WbHooksCroydon.Models.SellerCenter;

namespace WbHooksCroydon.WebHooksRecivers
{
    public class DafitiWebHookReciver : WebHookReceiver
    {
        public override string Name
        {
            get { return RecName; }
        }

        internal const string RecName = "Dafiti";
        internal const string ActionQueryParameter = "action";
        internal const string DefaultAction = "change";
        public static string ReceiverName
        {
            get { return RecName; }
        }

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

            // Ensure that we use https and have a valid code parameter
            //await EnsureValidCode(request, id);

            // Read the request entity body
            JToken data = await ReadAsJsonTokenAsync(request);
            var BodyRequest = data.Root.ToString();
            string action = "";
            var _request = JsonConvert.DeserializeObject<GetWebhookEntities>(data.Root.ToString());
            action = _request._event;
            if (string.IsNullOrEmpty(_request._event))
            {
                action = DefaultAction;
            }

            // Call registered handlers
            return await ExecuteWebHookAsync(id, context, request, new[] { action }, data);
        }

    }
}