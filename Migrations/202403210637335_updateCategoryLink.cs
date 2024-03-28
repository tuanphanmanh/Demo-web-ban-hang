namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategoryLink : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Link", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Link", c => c.String());
        }
    }
}
