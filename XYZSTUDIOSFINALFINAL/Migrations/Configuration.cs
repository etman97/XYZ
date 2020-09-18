namespace XYZSTUDIOSFINALFINAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XYZSTUDIOSFINALFINAL.Models.Data.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "XYZSTUDIOSFINALFINAL.Models.Data.Db";
        }

        protected override void Seed(XYZSTUDIOSFINALFINAL.Models.Data.Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
