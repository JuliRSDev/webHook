
using Microsoft.AspNet.WebHooks;
using System.Threading.Tasks;
using WbHooksCroydon.Log4Net;
using WbHooksCroydon.WebHooksRecivers;

namespace WbHooksCroydon.Handlers
{
    public class CustomWebHookHandler : WebHookHandler
    {
        
        public CustomWebHookHandler()
        {
            this.Receiver = DafitiWebHookReciver.ReceiverName;
        }       

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
           // response.Content = new System.Net.Http.StringContent(receiver);
           // context.Response = response;
            Logs.Intance.log.Info(context.Data.ToString());
            return Task.FromResult(true);
        }
    }
}