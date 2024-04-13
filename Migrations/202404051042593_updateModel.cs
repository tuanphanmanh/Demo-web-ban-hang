namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "NumberOfSeats", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "Design", c => c.String());
            AddColumn("dbo.tb_Product", "Fuel", c => c.String());
            AddColumn("dbo.tb_Product", "Origin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "Origin");
            DropColumn("dbo.tb_Product", "Fuel");
            DropColumn("dbo.tb_Product", "Design");
            DropColumn("dbo.tb_Product", "NumberOfSeats");
        }
    }
}
