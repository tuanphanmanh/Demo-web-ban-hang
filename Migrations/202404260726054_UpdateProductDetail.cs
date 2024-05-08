namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        KichThuoc = c.String(),
                        KhoangSangGamXe = c.Int(nullable: false),
                        BanKinhVongQUay = c.Int(nullable: false),
                        WeightKhongTai = c.Int(nullable: false),
                        WeightToanTai = c.Int(nullable: false),
                        ChieuRongCoSo = c.String(),
                        LoaiDongCo = c.String(),
                        KichThuocLopXe = c.String(),
                        CongSuatToiDa = c.String(),
                        HeThongNhienLieu = c.String(),
                        SoXyLanh = c.Int(nullable: false),
                        BoTriXyLanh = c.String(),
                        HeThongTruyenDong = c.String(),
                        HopSo = c.String(),
                        LoaiVanh = c.String(),
                        PhanhTruoc = c.String(),
                        PhanhSau = c.String(),
                        TieuChuanKhiThai = c.String(),
                        MucTieuThuTrong = c.String(),
                        MucTieuThuNgoai = c.String(),
                        MucTieuThuHonHop = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductDetail", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductDetail", new[] { "ProductId" });
            DropTable("dbo.tb_ProductDetail");
        }
    }
}
