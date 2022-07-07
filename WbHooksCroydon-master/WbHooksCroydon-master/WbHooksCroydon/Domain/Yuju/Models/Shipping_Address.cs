using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Domain.Yuju.Models
{
    public class Shipping_Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public object pk { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public object neighborhood { get; set; }
        public string phone { get; set; }
        public string postal_code { get; set; }
        public string reference { get; set; }
        public string region { get; set; }
        public object street_name { get; set; }
        public object street_number { get; set; }
    }
}