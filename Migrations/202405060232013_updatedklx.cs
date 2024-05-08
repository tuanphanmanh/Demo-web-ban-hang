namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedklx : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tb_SignUpForTestDrive");
        }
        
        public override void Down()
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
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
