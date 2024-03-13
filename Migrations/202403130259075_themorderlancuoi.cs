namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themorderlancuoi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "ShippingStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "ShippingStatus", c => c.String());
        }
    }
}
