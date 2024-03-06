namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thanhcong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "AddressType", c => c.String(nullable: false));
            AddColumn("dbo.tb_Order", "MessegesForBuyer", c => c.String());
            AddColumn("dbo.tb_Order", "ShippingUnit", c => c.String());
            AddColumn("dbo.tb_Order", "Voucher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "Voucher");
            DropColumn("dbo.tb_Order", "ShippingUnit");
            DropColumn("dbo.tb_Order", "MessegesForBuyer");
            DropColumn("dbo.tb_Order", "AddressType");
        }
    }
}
