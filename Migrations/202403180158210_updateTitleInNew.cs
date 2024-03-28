﻿namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTitleInNew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_News", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_News", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
