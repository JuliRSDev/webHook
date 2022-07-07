using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbHooksCroydon.Domain.Yuju.Models;

namespace WbHooksCroydon.Domain.Yuju.NetWork
{
    interface IYujuClient
    {
        OrderDetail GetOrderDetail(string urlRequest);
    }
}
