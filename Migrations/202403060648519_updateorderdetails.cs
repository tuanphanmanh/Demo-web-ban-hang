namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderdetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Order", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "Quantity", c => c.Int(nullable: false));
        }
    }
}
