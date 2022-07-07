namespace WbHooksCroydon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WbHooksCroydon.Models.DataBase;

    internal sealed class Configuration : DbMigrationsConfiguration<MarketPlaceHooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WbHooksCroydon.Models.DataBase.MarketPlaceHooksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
