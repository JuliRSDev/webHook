using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Domain.Yuju.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string item_pk { get; set; }
        public string channel_product_pk { get; set; }
        public string product_url { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string tracking_code { get; set; }
        public float price { get; set; }
        public float? product_special_price { get; set; }
        public float? product_original_price { get; set; }
        public string carrier { get; set; }
        public int quantity { get; set; }
        public string comments { get; set; }
        public object delivery_time { get; set; }
        public string currency { get; set; }
        public string coupon_code { get; set; }
        public float? coupon_value { get; set; }
        public Product product { get; set; }
        public object[] providers { get; set; }
        public object[] discounts { get; set; }
        public string channel_sku { get; set; }
        public string ff_type { get; set; }
        public object marketplace_fee { get; set; }
        public object[] shipments { get; set; }
        public bool is_combo { get; set; }
        public object[] combo_components { get; set; }
        public object extra { get; set; }
    }
}