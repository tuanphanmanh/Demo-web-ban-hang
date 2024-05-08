namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateService : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Service", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Service", new[] { "ProductId" });
            RenameColumn(table: "dbo.tb_Service", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.tb_Service", "Product_Id", c => c.Int());
            CreateIndex("dbo.tb_Service", "Product_Id");
            AddForeignKey("dbo.tb_Service", "Product_Id", "dbo.tb_Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Service", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_Service", new[] { "Product_Id" });
            AlterColumn("dbo.tb_Service", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.tb_Service", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.tb_Service", "ProductId");
            AddForeignKey("dbo.tb_Service", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
    }
}
