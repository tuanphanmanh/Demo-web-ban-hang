namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        BookService = c.String(),
                        CarName = c.String(),
                        CustomerTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_Booking");
        }
    }
}
