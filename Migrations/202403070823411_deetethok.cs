namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deetethok : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tb_ThongKe");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_ThongKe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThoiGian = c.DateTime(nullable: false),
                        SoTruyCap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
