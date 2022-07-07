using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Domain.Yuju.Models
{
    public class Product
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string pk { get; set; }
        public string parent_pk { get; set; }
        public object upc { get; set; }
        public string ean { get; set; }
        public object isbn_10 { get; set; }
        public object isbn_13 { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public object custom_variation { get; set; }
        public object custom_variation_name { get; set; }
        public int stock { get; set; }
        public float price { get; set; }
        public string color_text { get; set; }
        public object discount { get; set; }
        public object discount_to { get; set; }
        public object discount_from { get; set; }
        public object special_price { get; set; }
        public object special_price_amz { get; set; }
        public object special_price_linio { get; set; }
        public object secondary_color { get; set; }
        public object asin { get; set; }
        public object gtin { get; set; }
        public object jan { get; set; }
        public object mpn { get; set; }
        public object part_number { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public float shipping_depth { get; set; }
        public float shipping_height { get; set; }
        public float shipping_width { get; set; }
        public string dimensions_unit { get; set; }
        public float weight { get; set; }
        public string weight_unit { get; set; }
        public object measure_unit_code_sat { get; set; }
        public object product_code_sat { get; set; }
        public object cost { get; set; }
        public object msrp { get; set; }
        public object custom_i1 { get; set; }
        public object custom_i2 { get; set; }
        public object custom_i3 { get; set; }
        public object custom_i4 { get; set; }
        public object custom_i5 { get; set; }
        public object custom_s1 { get; set; }
        public object custom_s2 { get; set; }
        public object custom_s3 { get; set; }
        public object custom_s4 { get; set; }
        public object custom_s5 { get; set; }
        public object custom_f1 { get; set; }
        public object custom_f2 { get; set; }
        public object custom_f3 { get; set; }
        public object custom_f4 { get; set; }
        public object custom_f5 { get; set; }
        public string official_store_id { get; set; }
    }
}