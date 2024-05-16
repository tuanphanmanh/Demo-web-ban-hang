namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateChosseDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_OrderDetail", "SelectedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_OrderDetail", "SelectedDate", c => c.DateTime(nullable: false));
        }
    }
}
