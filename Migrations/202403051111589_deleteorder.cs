namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteorder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "TypePayment", c => c.String(nullable: false));
            DropColumn("dbo.tb_Order", "AddressType");
            DropColumn("dbo.tb_Order", "MessegesForBuyer");
            DropColumn("dbo.tb_Order", "ShippingUnit");
            DropColumn("dbo.tb_Order", "Voucher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "Voucher", c => c.String());
            AddColumn("dbo.tb_Order", "ShippingUnit", c => c.String());
            AddColumn("dbo.tb_Order", "MessegesForBuyer", c => c.String());
            AddColumn("dbo.tb_Order", "AddressType", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Order", "TypePayment", c => c.String());
        }
    }
}
