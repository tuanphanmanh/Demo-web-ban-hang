namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "Email", c => c.String(nullable: false));
            AddColumn("dbo.tb_Order", "AddressType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "AddressType");
            DropColumn("dbo.tb_Order", "Email");
        }
    }
}
