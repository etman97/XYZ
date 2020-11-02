namespace XYZSTUDIOSFINALFINAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class codebasedmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblUserRoles", "RoleId", "dbo.tblRoles");
            DropForeignKey("dbo.tblUserRoles", "UserId", "dbo.tblUsers");
            DropIndex("dbo.tblUserRoles", new[] { "UserId" });
            DropIndex("dbo.tblUserRoles", new[] { "RoleId" });
        }

        public override void Down()
        {
            CreateTable(
                "dbo.tblUserRoles",
                c => new
                {
                    UserId = c.Int(nullable: false),
                    RoleId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId });

            CreateTable(
                "dbo.tblRoles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.tblUserRoles", "RoleId");
            CreateIndex("dbo.tblUserRoles", "UserId");
            AddForeignKey("dbo.tblUserRoles", "UserId", "dbo.tblUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblUserRoles", "RoleId", "dbo.tblRoles", "Id", cascadeDelete: true);
        }
    }
}
