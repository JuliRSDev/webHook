namespace WbHooksCroydon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class variables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "price", c => c.Single());
            AlterColumn("dbo.Products", "price", c => c.Single());
            AlterColumn("dbo.Products", "shipping_depth", c => c.Single());
            AlterColumn("dbo.Products", "shipping_height", c => c.Single());
            AlterColumn("dbo.Products", "shipping_width", c => c.Single());
            AlterColumn("dbo.Products", "weight", c => c.Single());
            AlterColumn("dbo.OrderDetails", "total", c => c.Single());
            AlterColumn("dbo.OrderDetails", "paid_total", c => c.Single());
            AlterColumn("dbo.OrderDetails", "created_at", c => c.DateTime(precision: 0));
            AlterColumn("dbo.OrderDetails", "updated_at", c => c.DateTime(precision: 0));
            AlterColumn("dbo.OrderDetails", "shipping_cost", c => c.Single());
            AlterColumn("dbo.OrderDetails", "payment_accredited_at", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "payment_accredited_at", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.OrderDetails", "shipping_cost", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderDetails", "updated_at", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.OrderDetails", "created_at", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.OrderDetails", "paid_total", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderDetails", "total", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "weight", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "shipping_width", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "shipping_height", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "shipping_depth", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "price", c => c.Single(nullable: false));
            AlterColumn("dbo.Items", "price", c => c.Single(nullable: false));
        }
    }
}
