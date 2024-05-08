namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryUpdateAgain2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductDetail", "DoiXe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductDetail", "DoiXe");
        }
    }
}
