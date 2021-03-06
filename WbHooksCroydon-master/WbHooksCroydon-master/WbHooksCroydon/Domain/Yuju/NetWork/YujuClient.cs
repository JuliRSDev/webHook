using RestSharp;
using System;
using WbHooksCroydon.Domain.Yuju.Models;
using WbHooksCroydon.Models.ViewModel;

namespace WbHooksCroydon.Domain.Yuju.NetWork
{
    public class YujuClient : IYujuClient, IDisposable
    {
        private static YujuClient instance = null;
        public static YujuClient Instance
        {
            get
            {
                if (instance == null)
                    return instance = new YujuClient();
                return instance;
            }
        }

        readonly RestClient _client;
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public YujuClient()
        {
            _client = new RestClient() 
                .AddDefaultHeader("Authorization", "Token 3fe510b1ecec4283d719a027132b88ebf55130f9");
        }

        public OrderDetail GetOrderDetail(string urlRequest)
        {
            var response = _client.GetJsonAsync<OrderDetail>(urlRequest);
            response.Wait();
            return response.Result;
        }

        public ResponseOrder GetOrder(string urlRequest)
        {
            var response = _client.GetJsonAsync<ResponseOrder>(urlRequest);
            response.Wait();
            return response.Result;
        }
    }
}