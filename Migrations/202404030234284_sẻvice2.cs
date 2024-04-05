namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sẻvice2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Service", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_Service", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Service", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Service", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Service", "ModifiedBy");
            DropColumn("dbo.tb_Service", "ModifiedDate");
            DropColumn("dbo.tb_Service", "CreatedDate");
            DropColumn("dbo.tb_Service", "CreatedBy");
        }
    }
}
