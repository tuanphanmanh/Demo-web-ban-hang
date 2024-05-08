namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesinupforcustomer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_SignUpForTestDrive", "CreatedBy", c => c.String());
            AddColumn("dbo.tb_SignUpForTestDrive", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_SignUpForTestDrive", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_SignUpForTestDrive", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_SignUpForTestDrive", "ModifiedBy");
            DropColumn("dbo.tb_SignUpForTestDrive", "ModifiedDate");
            DropColumn("dbo.tb_SignUpForTestDrive", "CreatedDate");
            DropColumn("dbo.tb_SignUpForTestDrive", "CreatedBy");
        }
    }
}
