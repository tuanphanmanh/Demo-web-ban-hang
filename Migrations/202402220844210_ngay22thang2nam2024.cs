namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ngay22thang2nam2024 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "TypeCode", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_Category", "Link", c => c.String());
            AlterColumn("dbo.tb_ProductCategory", "Image", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_ProductCategory", "Image", c => c.String());
            DropColumn("dbo.tb_Category", "Link");
            DropColumn("dbo.tb_Category", "TypeCode");
        }
    }
}
