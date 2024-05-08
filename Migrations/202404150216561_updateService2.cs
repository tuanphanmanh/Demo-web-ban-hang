namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateService2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Service", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_Service", new[] { "Product_Id" });
            DropColumn("dbo.tb_Service", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Service", "Product_Id", c => c.Int());
            CreateIndex("dbo.tb_Service", "Product_Id");
            AddForeignKey("dbo.tb_Service", "Product_Id", "dbo.tb_Product", "Id");
        }
    }
}
