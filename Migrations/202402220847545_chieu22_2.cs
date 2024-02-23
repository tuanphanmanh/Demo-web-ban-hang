namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chieu22_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_ProductCategory", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_ProductCategory", "Image", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
