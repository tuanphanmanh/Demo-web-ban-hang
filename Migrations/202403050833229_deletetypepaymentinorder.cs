namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetypepaymentinorder : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "TypePayment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "TypePayment", c => c.Int(nullable: false));
        }
    }
}
