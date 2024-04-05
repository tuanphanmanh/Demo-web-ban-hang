namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class service3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Service", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Service", "Image");
        }
    }
}
