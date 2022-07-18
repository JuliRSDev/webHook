namespace WbHooksCroydon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVariableType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Billing_Address", "pk", c => c.String(unicode: false));
            AddColumn("dbo.Customers", "nickname", c => c.String(unicode: false));
            AddColumn("dbo.Customers", "customer_id", c => c.String(unicode: false));
            AddColumn("dbo.Customers", "doc_type", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "doc_type");
            DropColumn("dbo.Customers", "customer_id");
            DropColumn("dbo.Customers", "nickname");
            DropColumn("dbo.Billing_Address", "pk");
        }
    }
}
