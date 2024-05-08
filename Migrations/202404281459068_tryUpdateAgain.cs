namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryUpdateAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductDetail", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductDetail", new[] { "Product_Id" });
            RenameColumn(table: "dbo.tb_ProductDetail", name: "Product_Id", newName: "ProductId");
            AddColumn("dbo.tb_ProductDetail", "KichThuoc", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "KhoangSangGamXe", c => c.Int(nullable: false));
            AddColumn("dbo.tb_ProductDetail", "BanKinhVongQUay", c => c.Int(nullable: false));
            AddColumn("dbo.tb_ProductDetail", "WeightKhongTai", c => c.Int(nullable: false));
            AddColumn("dbo.tb_ProductDetail", "WeightToanTai", c => c.Int(nullable: false));
            AddColumn("dbo.tb_ProductDetail", "ChieuRongCoSo", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "LoaiDongCo", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "KichThuocLopXe", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "CongSuatToiDa", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "HeThongNhienLieu", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "SoXyLanh", c => c.Int(nullable: false));
            AddColumn("dbo.tb_ProductDetail", "BoTriXyLanh", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "HeThongTruyenDong", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "HopSo", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "LoaiVanh", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "TieuChuanKhiThai", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "MucTieuThuTrong", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "MucTieuThuNgoai", c => c.String());
            AddColumn("dbo.tb_ProductDetail", "MucTieuThuHonHop", c => c.String());
            AlterColumn("dbo.tb_ProductDetail", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_ProductDetail", "ProductId");
            AddForeignKey("dbo.tb_ProductDetail", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductDetail", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductDetail", new[] { "ProductId" });
            AlterColumn("dbo.tb_ProductDetail", "ProductId", c => c.Int());
            DropColumn("dbo.tb_ProductDetail", "MucTieuThuHonHop");
            DropColumn("dbo.tb_ProductDetail", "MucTieuThuNgoai");
            DropColumn("dbo.tb_ProductDetail", "MucTieuThuTrong");
            DropColumn("dbo.tb_ProductDetail", "TieuChuanKhiThai");
            DropColumn("dbo.tb_ProductDetail", "LoaiVanh");
            DropColumn("dbo.tb_ProductDetail", "HopSo");
            DropColumn("dbo.tb_ProductDetail", "HeThongTruyenDong");
            DropColumn("dbo.tb_ProductDetail", "BoTriXyLanh");
            DropColumn("dbo.tb_ProductDetail", "SoXyLanh");
            DropColumn("dbo.tb_ProductDetail", "HeThongNhienLieu");
            DropColumn("dbo.tb_ProductDetail", "CongSuatToiDa");
            DropColumn("dbo.tb_ProductDetail", "KichThuocLopXe");
            DropColumn("dbo.tb_ProductDetail", "LoaiDongCo");
            DropColumn("dbo.tb_ProductDetail", "ChieuRongCoSo");
            DropColumn("dbo.tb_ProductDetail", "WeightToanTai");
            DropColumn("dbo.tb_ProductDetail", "WeightKhongTai");
            DropColumn("dbo.tb_ProductDetail", "BanKinhVongQUay");
            DropColumn("dbo.tb_ProductDetail", "KhoangSangGamXe");
            DropColumn("dbo.tb_ProductDetail", "KichThuoc");
            RenameColumn(table: "dbo.tb_ProductDetail", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.tb_ProductDetail", "Product_Id");
            AddForeignKey("dbo.tb_ProductDetail", "Product_Id", "dbo.tb_Product", "Id");
        }
    }
}
