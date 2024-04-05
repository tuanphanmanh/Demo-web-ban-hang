namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Service", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Service", "Description");
        }
    }
}
