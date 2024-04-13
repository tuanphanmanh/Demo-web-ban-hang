namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBooking1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Booking", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Booking", "Status");
        }
    }
}
