using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Models.DataBase
{
    public class orders_hooks
    {
        [Key, Column(Order = 0)]
        public string order_id { get; set; }

        [Key, Column(Order = 1)]
        public string market_place_id { get; set; }

        [Key, Column(Order = 2)]
        public string seller_id { get; set; }
        public string erp_invoice { get; set; }
        public string erp_order_number { get; set; }
        public bool document_tracking { get; set; }
        public string global_status { get; set; }
        public string url_request_yuju { get; set; }

    }
}