namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatéignupfordrie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_SignUpForTestDrive", "Xa", c => c.String());
            AddColumn("dbo.tb_SignUpForTestDrive", "Huyen", c => c.String());
            AddColumn("dbo.tb_SignUpForTestDrive", "Tinh", c => c.String());
            DropColumn("dbo.tb_SignUpForTestDrive", "SoHuuXe");
            DropColumn("dbo.tb_SignUpForTestDrive", "KhuVuc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_SignUpForTestDrive", "KhuVuc", c => c.String());
            AddColumn("dbo.tb_SignUpForTestDrive", "SoHuuXe", c => c.String());
            DropColumn("dbo.tb_SignUpForTestDrive", "Tinh");
            DropColumn("dbo.tb_SignUpForTestDrive", "Huyen");
            DropColumn("dbo.tb_SignUpForTestDrive", "Xa");
        }
    }
}
