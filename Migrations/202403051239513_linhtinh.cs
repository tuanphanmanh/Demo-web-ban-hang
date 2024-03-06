namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linhtinh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "TypePayment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Order", "TypePayment", c => c.String(nullable: false));
        }
    }
}
