using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Domain.Yuju.Models
{
    public class Billing_Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public object name { get; set; }
        public object neighborhood { get; set; }
        public string phone { get; set; }
        public string postal_code { get; set; }
        public object reference { get; set; }
        public string region { get; set; }
        public string taxid { get; set; }
        public object use_cfdi { get; set; }
        public object extra { get; set; }
    }
}