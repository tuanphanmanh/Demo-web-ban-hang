namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatever2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductDetail", "LoaiSo", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "DungTichXyLanh", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductDetail", "DungTichXyLanh");
            DropColumn("dbo.tb_ProductDetail", "LoaiSo");
        }
    }
}
