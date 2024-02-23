namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hnay2322024 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "ProductCategory_Id", c => c.Int());
            CreateIndex("dbo.tb_Category", "ProductCategory_Id");
            AddForeignKey("dbo.tb_Category", "ProductCategory_Id", "dbo.tb_ProductCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Category", "ProductCategory_Id", "dbo.tb_ProductCategory");
            DropIndex("dbo.tb_Category", new[] { "ProductCategory_Id" });
            DropColumn("dbo.tb_Category", "ProductCategory_Id");
        }
    }
}
