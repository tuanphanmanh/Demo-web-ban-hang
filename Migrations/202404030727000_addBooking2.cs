namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBooking2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Booking", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Booking", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Booking", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Booking", "ModifiedBy", c => c.String());
            DropColumn("dbo.tb_Booking", "CustomerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Booking", "CustomerName", c => c.String());
            DropColumn("dbo.tb_Booking", "ModifiedBy");
            DropColumn("dbo.tb_Booking", "ModifiedDate");
            DropColumn("dbo.tb_Booking", "CreatedDate");
            DropColumn("dbo.tb_Booking", "CreatedBy");
        }
    }
}
