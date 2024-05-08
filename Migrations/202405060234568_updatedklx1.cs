namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedklx1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_SignUpForTestDrive",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DiaChiLienHe = c.String(),
                        DiaDiemLaiThu = c.String(),
                        HinhThucMuaXe = c.String(),
                        SoHuuXe = c.String(),
                        KhuVuc = c.String(),
                        BuyCarTime = c.String(),
                        ProductId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_SignUpForTestDrive", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_SignUpForTestDrive", new[] { "ProductId" });
            DropTable("dbo.tb_SignUpForTestDrive");
        }
    }
}
