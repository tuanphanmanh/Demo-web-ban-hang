namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesinupforcustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_SignUpForTestDrive",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        BuyCarTime = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Product", "SignUpForTestDrive_Id", c => c.Int());
            CreateIndex("dbo.tb_Product", "SignUpForTestDrive_Id");
            AddForeignKey("dbo.tb_Product", "SignUpForTestDrive_Id", "dbo.tb_SignUpForTestDrive", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "SignUpForTestDrive_Id", "dbo.tb_SignUpForTestDrive");
            DropIndex("dbo.tb_Product", new[] { "SignUpForTestDrive_Id" });
            DropColumn("dbo.tb_Product", "SignUpForTestDrive_Id");
            DropTable("dbo.tb_SignUpForTestDrive");
        }
    }
}
