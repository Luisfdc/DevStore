namespace DevStore.Infra.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AquireDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CategorYId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorYId, cascadeDelete: true)
                .Index(t => t.CategorYId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategorYId", "dbo.Categories");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "CategorYId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Categories");
        }
    }
}
