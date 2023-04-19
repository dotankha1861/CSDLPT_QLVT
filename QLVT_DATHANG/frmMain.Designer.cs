
namespace QLVT_DATHANG
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnKho = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnVatTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnDonDatHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnIDSNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnIDMVT = new DevExpress.XtraBars.BarButtonItem();
            this.btnBKCTNX = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSDCCPN = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCHD1NV = new DevExpress.XtraBars.BarButtonItem();
            this.btnTHNX = new DevExpress.XtraBars.BarButtonItem();
            this.rib_pDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_pNghiepVu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_pBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_pHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rib_pGQuanLyTaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MANV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnDangNhap,
            this.btnTaoTaiKhoan,
            this.btnDangXuat,
            this.btnKho,
            this.btnNhanVien,
            this.btnVatTu,
            this.btnDonDatHang,
            this.btnPhieuNhap,
            this.btnPhieuXuat,
            this.btnIDSNV,
            this.btnIDMVT,
            this.btnBKCTNX,
            this.btnDSDCCPN,
            this.btnBCHD1NV,
            this.btnTHNX});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(5);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rib_pDanhMuc,
            this.rib_pNghiepVu,
            this.rib_pBaoCao,
            this.rib_pHeThong});
            this.ribbonControl1.Size = new System.Drawing.Size(1269, 231);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng Nhập";
            this.btnDangNhap.Id = 1;
            this.btnDangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangNhap.ImageOptions.SvgImage")));
            this.btnDangNhap.LargeWidth = 100;
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangNhap_ItemClick);
            // 
            // btnTaoTaiKhoan
            // 
            this.btnTaoTaiKhoan.Caption = "Tạo Tài Khoản";
            this.btnTaoTaiKhoan.Enabled = false;
            this.btnTaoTaiKhoan.Id = 2;
            this.btnTaoTaiKhoan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoTaiKhoan.ImageOptions.SvgImage")));
            this.btnTaoTaiKhoan.LargeWidth = 100;
            this.btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            this.btnTaoTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTaiKhoan_ItemClick);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng Xuất";
            this.btnDangXuat.Enabled = false;
            this.btnDangXuat.Id = 3;
            this.btnDangXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDangXuat.ImageOptions.SvgImage")));
            this.btnDangXuat.LargeWidth = 100;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.VisibleInSearchMenu = false;
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
            // 
            // btnKho
            // 
            this.btnKho.Caption = "Kho";
            this.btnKho.Id = 4;
            this.btnKho.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKho.ImageOptions.SvgImage")));
            this.btnKho.LargeWidth = 100;
            this.btnKho.Name = "btnKho";
            this.btnKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKho_ItemClick);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Caption = "Nhân Viên";
            this.btnNhanVien.Id = 5;
            this.btnNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNhanVien.ImageOptions.SvgImage")));
            this.btnNhanVien.LargeWidth = 100;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhanVien_ItemClick);
            // 
            // btnVatTu
            // 
            this.btnVatTu.Caption = "Vật Tư";
            this.btnVatTu.Id = 6;
            this.btnVatTu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVatTu.ImageOptions.SvgImage")));
            this.btnVatTu.LargeWidth = 100;
            this.btnVatTu.Name = "btnVatTu";
            this.btnVatTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVatTu_ItemClick);
            // 
            // btnDonDatHang
            // 
            this.btnDonDatHang.Caption = "Đơn Đặt Hàng";
            this.btnDonDatHang.Id = 7;
            this.btnDonDatHang.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDonDatHang.ImageOptions.SvgImage")));
            this.btnDonDatHang.LargeWidth = 100;
            this.btnDonDatHang.Name = "btnDonDatHang";
            this.btnDonDatHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDonDatHang_ItemClick);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Caption = "Phiếu Nhập";
            this.btnPhieuNhap.Id = 8;
            this.btnPhieuNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhieuNhap.ImageOptions.SvgImage")));
            this.btnPhieuNhap.LargeWidth = 100;
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Caption = "Phiếu Xuất";
            this.btnPhieuXuat.Id = 9;
            this.btnPhieuXuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhieuXuat.ImageOptions.SvgImage")));
            this.btnPhieuXuat.LargeWidth = 100;
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhieuXuat_ItemClick);
            // 
            // btnIDSNV
            // 
            this.btnIDSNV.Caption = "In Danh Sách Nhân Viên";
            this.btnIDSNV.Id = 10;
            this.btnIDSNV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIDSNV.ImageOptions.SvgImage")));
            this.btnIDSNV.LargeWidth = 100;
            this.btnIDSNV.Name = "btnIDSNV";
            this.btnIDSNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIDSNV_ItemClick);
            // 
            // btnIDMVT
            // 
            this.btnIDMVT.Caption = "In Danh Mục Vật Tư";
            this.btnIDMVT.Id = 11;
            this.btnIDMVT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIDMVT.ImageOptions.SvgImage")));
            this.btnIDMVT.LargeWidth = 100;
            this.btnIDMVT.Name = "btnIDMVT";
            this.btnIDMVT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIDMVT_ItemClick);
            // 
            // btnBKCTNX
            // 
            this.btnBKCTNX.Caption = "Bảng Kê Chi Tiết Nhập/Xuất";
            this.btnBKCTNX.Id = 12;
            this.btnBKCTNX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBKCTNX.ImageOptions.SvgImage")));
            this.btnBKCTNX.LargeWidth = 100;
            this.btnBKCTNX.Name = "btnBKCTNX";
            this.btnBKCTNX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBKCTNX_ItemClick);
            // 
            // btnDSDCCPN
            // 
            this.btnDSDCCPN.Caption = "Danh Sách ĐĐH Chưa Có PN";
            this.btnDSDCCPN.Id = 13;
            this.btnDSDCCPN.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDSDCCPN.ImageOptions.SvgImage")));
            this.btnDSDCCPN.LargeWidth = 100;
            this.btnDSDCCPN.Name = "btnDSDCCPN";
            this.btnDSDCCPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSDCCPN_ItemClick);
            // 
            // btnBCHD1NV
            // 
            this.btnBCHD1NV.Caption = "Báo Cáo Hoạt Động 1 Nhân Viên";
            this.btnBCHD1NV.Id = 14;
            this.btnBCHD1NV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBCHD1NV.ImageOptions.SvgImage")));
            this.btnBCHD1NV.LargeWidth = 100;
            this.btnBCHD1NV.Name = "btnBCHD1NV";
            this.btnBCHD1NV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBCHD1NV_ItemClick);
            // 
            // btnTHNX
            // 
            this.btnTHNX.Caption = "Tổng Hợp Nhập Xuất";
            this.btnTHNX.Id = 15;
            this.btnTHNX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTHNX.ImageOptions.SvgImage")));
            this.btnTHNX.LargeWidth = 100;
            this.btnTHNX.Name = "btnTHNX";
            this.btnTHNX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTHNX_ItemClick);
            // 
            // rib_pDanhMuc
            // 
            this.rib_pDanhMuc.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rib_pDanhMuc.Appearance.Options.UseFont = true;
            this.rib_pDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rib_pDanhMuc.Name = "rib_pDanhMuc";
            this.rib_pDanhMuc.Text = "Danh Mục";
            this.rib_pDanhMuc.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNhanVien);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnVatTu);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKho);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Quản Lý Nhân Lực Và Tài Sản";
            // 
            // rib_pNghiepVu
            // 
            this.rib_pNghiepVu.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rib_pNghiepVu.Appearance.Options.UseFont = true;
            this.rib_pNghiepVu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rib_pNghiepVu.Name = "rib_pNghiepVu";
            this.rib_pNghiepVu.Text = "Nghiệp Vụ";
            this.rib_pNghiepVu.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDonDatHang);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPhieuNhap);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPhieuXuat);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Lập Phiếu Nhập/Xuất";
            // 
            // rib_pBaoCao
            // 
            this.rib_pBaoCao.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rib_pBaoCao.Appearance.Options.UseFont = true;
            this.rib_pBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rib_pBaoCao.Name = "rib_pBaoCao";
            this.rib_pBaoCao.Text = "Báo Cáo";
            this.rib_pBaoCao.Visible = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnIDSNV);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnIDMVT);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnBKCTNX);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDSDCCPN);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnBCHD1NV);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTHNX);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // rib_pHeThong
            // 
            this.rib_pHeThong.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rib_pHeThong.Appearance.Options.UseFont = true;
            this.rib_pHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rib_pGQuanLyTaiKhoan});
            this.rib_pHeThong.Name = "rib_pHeThong";
            this.rib_pHeThong.Text = "Hệ Thống";
            // 
            // rib_pGQuanLyTaiKhoan
            // 
            this.rib_pGQuanLyTaiKhoan.ItemLinks.Add(this.btnDangNhap);
            this.rib_pGQuanLyTaiKhoan.ItemLinks.Add(this.btnTaoTaiKhoan);
            this.rib_pGQuanLyTaiKhoan.ItemLinks.Add(this.btnDangXuat);
            this.rib_pGQuanLyTaiKhoan.Name = "rib_pGQuanLyTaiKhoan";
            this.rib_pGQuanLyTaiKhoan.Text = "Quản Lý Tài Khoản";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MANV,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 468);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1269, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(64, 25);
            this.MANV.Text = "MANV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(69, 25);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(68, 25);
            this.NHOM.Text = "NHOM";
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 500);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmMain.IconOptions.SvgImage")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ VẬT TƯ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_pHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rib_pGQuanLyTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem btnTaoTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_pDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_pNghiepVu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage rib_pBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MANV;
        public System.Windows.Forms.ToolStripStatusLabel HOTEN;
        public System.Windows.Forms.ToolStripStatusLabel NHOM;
        private DevExpress.XtraBars.BarButtonItem btnKho;
        private DevExpress.XtraBars.BarButtonItem btnNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnVatTu;
        private DevExpress.XtraBars.BarButtonItem btnDonDatHang;
        private DevExpress.XtraBars.BarButtonItem btnPhieuNhap;
        private DevExpress.XtraBars.BarButtonItem btnPhieuXuat;
        private DevExpress.XtraBars.BarButtonItem btnIDSNV;
        private DevExpress.XtraBars.BarButtonItem btnIDMVT;
        private DevExpress.XtraBars.BarButtonItem btnBKCTNX;
        private DevExpress.XtraBars.BarButtonItem btnDSDCCPN;
        private DevExpress.XtraBars.BarButtonItem btnBCHD1NV;
        private DevExpress.XtraBars.BarButtonItem btnTHNX;
    }
}

