namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upatever2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Booking", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Booking", "PhoneNumber", c => c.String());
        }
    }
}
