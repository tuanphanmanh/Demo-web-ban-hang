namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBooking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Booking", "ServiceName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Booking", "ServiceName", c => c.String());
        }
    }
}
