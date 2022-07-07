namespace WbHooksCroydon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orders_hooks",
                c => new
                    {
                        order_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        market_place_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        seller_id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        erp_invoice = c.String(unicode: false),
                        erp_order_number = c.String(unicode: false),
                        document_tracking = c.Boolean(nullable: false),
                        global_status = c.String(unicode: false),
                    url_request_yuju = c.String(unicode: false),
                })
                .PrimaryKey(t => new { t.order_id, t.market_place_id, t.seller_id });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.orders_hooks");
        }
    }
}
