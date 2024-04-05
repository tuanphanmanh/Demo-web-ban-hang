namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class service : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ProductId = c.Int(nullable: false),
                        PriceOfSerVice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.tb_Subscribe", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Subscribe", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Subscribe", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Service", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Service", new[] { "ProductId" });
            DropColumn("dbo.tb_Subscribe", "ModifiedBy");
            DropColumn("dbo.tb_Subscribe", "ModifiedDate");
            DropColumn("dbo.tb_Subscribe", "CreatedBy");
            DropTable("dbo.tb_Service");
        }
    }
}
