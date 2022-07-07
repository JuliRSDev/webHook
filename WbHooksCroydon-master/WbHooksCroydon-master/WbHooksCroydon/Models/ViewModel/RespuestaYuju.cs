using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WbHooksCroydon.Models.ViewModel
{
    public class RespuestaYuju
    {

        public class Accounts
        {
            public string to { get; set; }
            public string from { get; set; }
        }

        public class AdditionalInfo
        {
            public object authentication_code { get; set; }
            public object nsu_processadora { get; set; }
            public object available_balance { get; set; }
        }

        public class Amounts
        {
            public double original { get; set; }
            public int refunded { get; set; }
        }

        public class BusinessInfo
        {
            public string unit { get; set; }
            public string sub_unit { get; set; }
        }

        public class Card
        {
        }

        public class ChargesDetail
        {
            public Accounts accounts { get; set; }
            public object reserve_id { get; set; }
            public DateTime date_created { get; set; }
            public DateTime last_updated { get; set; }
            public Amounts amounts { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public List<object> refund_charges { get; set; }
            public long client_id { get; set; }
            public string type { get; set; }
            public Metadata metadata { get; set; }
        }

        public class Customer
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string nickname { get; set; }
            public string customer_id { get; set; }
            public string doc_number { get; set; }
            public string doc_type { get; set; }
        }

        public class Extra
        {
            public DateTime date_approved { get; set; }
            public bool binary_mode { get; set; }
            public int installments { get; set; }
            public string operation_type { get; set; }
            public string payment_method_id { get; set; }
            public List<object> refunds { get; set; }
            public object money_release_schema { get; set; }
            public object differential_pricing_id { get; set; }
            public string payment_type_id { get; set; }
            public object corporation_id { get; set; }
            public int coupon_amount { get; set; }
            public int collector_id { get; set; }
            public Payer payer { get; set; }
            public object authorization_code { get; set; }
            public object issuer_id { get; set; }
            public object net_amount { get; set; }
            public object platform_id { get; set; }
            public object notification_url { get; set; }
            public object integrator_id { get; set; }
            public object merchant_number { get; set; }
            public string processing_mode { get; set; }
            public string status_detail { get; set; }
            public long id { get; set; }
            public DateTime money_release_date { get; set; }
            public object store_id { get; set; }
            public object sponsor_id { get; set; }
            public int shipping_amount { get; set; }
            public object deduction_schema { get; set; }
            public List<object> acquirer_reconciliation { get; set; }
            public object brand_id { get; set; }
            public object statement_descriptor { get; set; }
            public string external_reference { get; set; }
            public PointOfInteraction point_of_interaction { get; set; }
            public bool captured { get; set; }
            public object counter_currency { get; set; }
            public List<Taxis> taxes { get; set; }
            public Order order { get; set; }
            public AdditionalInfo additional_info { get; set; }
            public string status { get; set; }
            public Metadata metadata { get; set; }
            public string currency_id { get; set; }
            public object pos_id { get; set; }
            public int transaction_amount_refunded { get; set; }
            public int transaction_amount { get; set; }
            public object date_of_expiration { get; set; }
            public string description { get; set; }
            public List<FeeDetail> fee_details { get; set; }
            public Card card { get; set; }
            public bool live_mode { get; set; }
            public List<ChargesDetail> charges_details { get; set; }
            public object merchant_account_id { get; set; }
            public DateTime date_created { get; set; }
            public TransactionDetails transaction_details { get; set; }
            public int taxes_amount { get; set; }
            public DateTime date_last_updated { get; set; }
            public object call_for_authorize_id { get; set; }
            public object marketplace_owner { get; set; }
            public string pack_id { get; set; }
        }

        public class FeeDetail
        {
            public int amount { get; set; }
            public string type { get; set; }
            public string fee_payer { get; set; }
        }

        public class Identification
        {
            public object type { get; set; }
            public object number { get; set; }
        }

        public class Item
        {
            public string item_pk { get; set; }
            public string channel_product_pk { get; set; }
            public string product_url { get; set; }
            public string sku { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public string tracking_code { get; set; }
            public double price { get; set; }
            public object product_special_price { get; set; }
            public double product_original_price { get; set; }
            public string carrier { get; set; }
            public int quantity { get; set; }
            public object comments { get; set; }
            public object delivery_time { get; set; }
            public string currency { get; set; }
            public object coupon_code { get; set; }
            public object coupon_value { get; set; }
            public Product product { get; set; }
            public List<object> providers { get; set; }
            public List<object> discounts { get; set; }
            public string channel_sku { get; set; }
            public string ff_type { get; set; }
            public double marketplace_fee { get; set; }
            public List<Shipment> shipments { get; set; }
            public bool is_combo { get; set; }
            public List<object> combo_components { get; set; }
            public object extra { get; set; }
        }

        public class Location
        {
            public string state_id { get; set; }
            public string source { get; set; }
        }

        public class Metadata
        {
            public string tax_status { get; set; }
            public string mov_type { get; set; }
            public string mov_financial_entity { get; set; }
            public object tax_id { get; set; }
            public string mov_detail { get; set; }
            public int user_id { get; set; }
        }

        public class Order
        {
            public string type { get; set; }
            public string id { get; set; }
        }

        public class Payer
        {
            public string type { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public object operator_id { get; set; }
            public Identification identification { get; set; }
            public object email { get; set; }
            public string id { get; set; }
            public Phone phone { get; set; }
            public object entity_type { get; set; }
        }

        public class PaymentDetail
        {
            public string method { get; set; }
            public string amount { get; set; }
            public string currency { get; set; }
            public string id { get; set; }
            public DateTime acredited_at { get; set; }
            public Extra extra { get; set; }
        }

        public class Phone
        {
            public object area_code { get; set; }
            public object extension { get; set; }
            public object number { get; set; }
        }

        public class PointOfInteraction
        {
            public Location location { get; set; }
            public string type { get; set; }
            public BusinessInfo business_info { get; set; }
        }

        public class Product
        {
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
            public double price { get; set; }
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
            public double shipping_depth { get; set; }
            public double shipping_height { get; set; }
            public double shipping_width { get; set; }
            public string dimensions_unit { get; set; }
            public double weight { get; set; }
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

        public class Progress
        {
            public string name { get; set; }
            public string status { get; set; }
        }

            public string pk { get; set; }
            public int marketplace_pk { get; set; }
            public int shop_pk { get; set; }
            public string reference { get; set; }
            public double total { get; set; }
            public double paid_total { get; set; }
            public string currency { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string payment_method { get; set; }
            public string delivery_deadline { get; set; }
            public string status { get; set; }
            public List<string> actions { get; set; }
            public bool notes { get; set; }
            public object coupon { get; set; }
            public Customer customer { get; set; }
            public List<Progress> progress { get; set; }
            public object billing_address { get; set; }
            public ShippingAddress shipping_address { get; set; }
            public double shipping_cost { get; set; }
            public double seller_shipping_cost { get; set; }
            public double marketplace_fee { get; set; }
            public double paid_total_to_seller { get; set; }
            public DateTime payment_accredited_at { get; set; }
            public object fulfillment_type { get; set; }
            public List<string> payment_references { get; set; }
            public List<object> cart_orders { get; set; }
            public List<string> tags { get; set; }
            public List<PaymentDetail> payment_detail { get; set; }
            public Extra extra { get; set; }
            public object claims { get; set; }
            public List<object> discounts { get; set; }
            public string ff_type { get; set; }
            public List<Item> items { get; set; }

        public class Shipment
        {
            public object buffering_date { get; set; }
            public string carrier { get; set; }
            public StatusHistory status_history { get; set; }
            public string id { get; set; }
            public string tracking_code { get; set; }
            public string status { get; set; }
            public int quantity { get; set; }
            public object tracking_url { get; set; }
            public string label_url { get; set; }
        }

        public class ShippingAddress
        {
            public string pk { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public object email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string neighborhood { get; set; }
            public string phone { get; set; }
            public string postal_code { get; set; }
            public string reference { get; set; }
            public string region { get; set; }
            public string street_name { get; set; }
            public string street_number { get; set; }
        }

        public class StatusHistory
        {
            public object date_not_delivered { get; set; }
            public object date_returned { get; set; }
            public object date_created { get; set; }
            public DateTime date_delivered { get; set; }
            public DateTime date_handling { get; set; }
            public object date_first_printed { get; set; }
            public DateTime date_first_visit { get; set; }
            public object date_delivered_estimated { get; set; }
            public DateTime date_ready_to_ship { get; set; }
            public DateTime date_shipped { get; set; }
            public object date_cancelled { get; set; }
        }

        public class Taxis
        {
            public string type { get; set; }
            public object value { get; set; }
        }

        public class TransactionDetails
        {
            public object payable_deferral_period { get; set; }
            public object payment_method_reference_id { get; set; }
            public int total_paid_amount { get; set; }
            public double net_received_amount { get; set; }
            public object external_resource_url { get; set; }
            public int installment_amount { get; set; }
            public object acquirer_reference { get; set; }
            public int overpaid_amount { get; set; }
            public object financial_institution { get; set; }
        }


    }
}