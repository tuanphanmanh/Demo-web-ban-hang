namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBooking1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Booking", "ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Booking", "ServiceName", c => c.String());
            CreateIndex("dbo.tb_Booking", "ServiceId");
            AddForeignKey("dbo.tb_Booking", "ServiceId", "dbo.tb_Service", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_Booking", "BookService");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Booking", "BookService", c => c.String());
            DropForeignKey("dbo.tb_Booking", "ServiceId", "dbo.tb_Service");
            DropIndex("dbo.tb_Booking", new[] { "ServiceId" });
            DropColumn("dbo.tb_Booking", "ServiceName");
            DropColumn("dbo.tb_Booking", "ServiceId");
        }
    }
}
