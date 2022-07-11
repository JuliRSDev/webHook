using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Domain.Yuju.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string pk { get; set; }
        public int marketplace_pk { get; set; }
        public int shop_pk { get; set; }
        public string reference { get; set; }
        public float? total { get; set; }
        public float? paid_total { get; set; }
        public string currency { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string payment_method { get; set; }
        public string delivery_deadline { get; set; }
        public string status { get; set; }
        public string[] actions { get; set; }
        public bool notes { get; set; }
        public object coupon { get; set; }
        public Customer customer { get; set; }
        public Progress[] progress { get; set; }
        public Billing_Address billing_address { get; set; }
        public Shipping_Address shipping_address { get; set; }
        public float? shipping_cost { get; set; }
        public object seller_shipping_cost { get; set; }
        public object marketplace_fee { get; set; }
        public object paid_total_to_seller { get; set; }
        public DateTime? payment_accredited_at { get; set; }
        public object fulfillment_type { get; set; }
        public object[] payment_references { get; set; }
        public object[] cart_orders { get; set; }
        public string[] tags { get; set; }
        public object[] payment_detail { get; set; }
        public object extra { get; set; }
        public object claims { get; set; }
        public object[] discounts { get; set; }
        public string ff_type { get; set; }
        public Item[] items { get; set; }
    }
}