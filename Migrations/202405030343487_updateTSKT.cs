namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTSKT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_ProductDetail", "BanKinhVongQUay", c => c.Single(nullable: false));
            AlterColumn("dbo.tb_ProductDetail", "DungTichXyLanh", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_ProductDetail", "DungTichXyLanh", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_ProductDetail", "BanKinhVongQUay", c => c.Int(nullable: false));
        }
    }
}
