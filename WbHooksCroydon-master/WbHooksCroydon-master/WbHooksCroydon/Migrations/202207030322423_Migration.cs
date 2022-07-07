namespace WbHooksCroydon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billing_Address",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        address = c.String(unicode: false),
                        city = c.String(unicode: false),
                        country = c.String(unicode: false),
                        email = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        postal_code = c.String(unicode: false),
                        region = c.String(unicode: false),
                        taxid = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(unicode: false),
                        last_name = c.String(unicode: false),
                        email = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        doc_number = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        item_pk = c.String(unicode: false),
                        channel_product_pk = c.String(unicode: false),
                        product_url = c.String(unicode: false),
                        sku = c.String(unicode: false),
                        name = c.String(unicode: false),
                        status = c.String(unicode: false),
                        tracking_code = c.String(unicode: false),
                        price = c.Single(nullable: false),
                        product_special_price = c.Single(),
                        product_original_price = c.Single(nullable: false),
                        carrier = c.String(unicode: false),
                        quantity = c.Int(nullable: false),
                        comments = c.String(unicode: false),
                        currency = c.String(unicode: false),
                        coupon_code = c.String(unicode: false),
                        coupon_value = c.Single(),
                        channel_sku = c.String(unicode: false),
                        ff_type = c.String(unicode: false),
                        is_combo = c.Boolean(nullable: false),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pk = c.String(unicode: false),
                        parent_pk = c.String(unicode: false),
                        ean = c.String(unicode: false),
                        color = c.String(unicode: false),
                        size = c.String(unicode: false),
                        stock = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        color_text = c.String(unicode: false),
                        model = c.String(unicode: false),
                        brand = c.String(unicode: false),
                        shipping_depth = c.Single(nullable: false),
                        shipping_height = c.Single(nullable: false),
                        shipping_width = c.Single(nullable: false),
                        dimensions_unit = c.String(unicode: false),
                        weight = c.Single(nullable: false),
                        weight_unit = c.String(unicode: false),
                        official_store_id = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pk = c.String(unicode: false),
                        marketplace_pk = c.Int(nullable: false),
                        shop_pk = c.Int(nullable: false),
                        reference = c.String(unicode: false),
                        total = c.Single(nullable: false),
                        paid_total = c.Single(nullable: false),
                        currency = c.String(unicode: false),
                        created_at = c.DateTime(nullable: false, precision: 0),
                        updated_at = c.DateTime(nullable: false, precision: 0),
                        payment_method = c.String(unicode: false),
                        delivery_deadline = c.String(unicode: false),
                        status = c.String(unicode: false),
                        notes = c.Boolean(nullable: false),
                        shipping_cost = c.Single(nullable: false),
                        payment_accredited_at = c.DateTime(nullable: false, precision: 0),
                        ff_type = c.String(unicode: false),
                        billing_address_id = c.Int(),
                        customer_id = c.Int(),
                        shipping_address_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Billing_Address", t => t.billing_address_id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .ForeignKey("dbo.Shipping_Address", t => t.shipping_address_id)
                .Index(t => t.billing_address_id)
                .Index(t => t.customer_id)
                .Index(t => t.shipping_address_id);
            
            CreateTable(
                "dbo.Shipping_Address",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        address = c.String(unicode: false),
                        city = c.String(unicode: false),
                        country = c.String(unicode: false),
                        email = c.String(unicode: false),
                        first_name = c.String(unicode: false),
                        last_name = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        postal_code = c.String(unicode: false),
                        reference = c.String(unicode: false),
                        region = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            // AddColumn("dbo.orders_hooks", "url_request_yuju", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "shipping_address_id", "dbo.Shipping_Address");
            DropForeignKey("dbo.OrderDetails", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "billing_address_id", "dbo.Billing_Address");
            DropForeignKey("dbo.Items", "product_id", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "shipping_address_id" });
            DropIndex("dbo.OrderDetails", new[] { "customer_id" });
            DropIndex("dbo.OrderDetails", new[] { "billing_address_id" });
            DropIndex("dbo.Items", new[] { "product_id" });
            DropColumn("dbo.orders_hooks", "url_request_yuju");
            DropTable("dbo.Shipping_Address");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Items");
            DropTable("dbo.Customers");
            DropTable("dbo.Billing_Address");
        }
    }
}
