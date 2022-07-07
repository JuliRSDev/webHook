using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WbHooksCroydon.WebHooksRecivers;

namespace WbHooksCroydon.Handlers
{
    public class LinioWebHookHandler : WebHookHandler
    {
        public LinioWebHookHandler()
        {
            this.Receiver = LinioWebHookReciver.ReceiverName;
        }
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new System.Net.Http.StringContent("Este es de: " + receiver);
            context.Response = response;
            return Task.FromResult(true);
        }
    }
}