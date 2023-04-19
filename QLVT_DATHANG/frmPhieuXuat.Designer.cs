
namespace QLVT_DATHANG
{
    partial class frmPhieuXuat
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
            System.Windows.Forms.Label dONGIALabel1;
            System.Windows.Forms.Label sOLUONGLabel1;
            System.Windows.Forms.Label mAVTLabel1;
            System.Windows.Forms.Label mAPXLabel1;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label mANVLabel1;
            System.Windows.Forms.Label nGAYLabel1;
            System.Windows.Forms.Label mAPXLabel;
            System.Windows.Forms.Label hOTENKHLabel;
            System.Windows.Forms.Label tENKHOLabel;
            System.Windows.Forms.Label hOTENLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuXuat));
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaiLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnHieuChinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnInDSNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.cTPXGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsCTPX = new System.Windows.Forms.BindingSource(this.components);
            this.bdsPHIEUXUAT = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new QLVT_DATHANG.DS();
            this.gridVCTPX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.hoTenNVTableAdapter = new QLVT_DATHANG.DSTableAdapters.HOTENNVTableAdapter();
            this.bdsHOTENNV = new System.Windows.Forms.BindingSource(this.components);
            this.bdsKHO = new System.Windows.Forms.BindingSource(this.components);
            this.bdsVATTU = new System.Windows.Forms.BindingSource(this.components);
            this.ctmsCTPX = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiThem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGhi = new System.Windows.Forms.ToolStripMenuItem();
            this.vatTuTableAdapter = new QLVT_DATHANG.DSTableAdapters.VattuTableAdapter();
            this.khoTableAdapter = new QLVT_DATHANG.DSTableAdapters.KhoTableAdapter();
            this.CTPXTableAdapter = new QLVT_DATHANG.DSTableAdapters.CTPXTableAdapter();
            this.tableAdapterManager = new QLVT_DATHANG.DSTableAdapters.TableAdapterManager();
            this.phieuXuatTableAdapter = new QLVT_DATHANG.DSTableAdapters.PhieuXuatTableAdapter();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.setDonGia = new DevExpress.XtraEditors.SpinEdit();
            this.setSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.txtMaPX1 = new System.Windows.Forms.TextBox();
            this.cmbTenVT = new System.Windows.Forms.ComboBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.detNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.txtHoTenKH = new System.Windows.Forms.TextBox();
            this.cmbTenKho = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbHoTen = new System.Windows.Forms.ComboBox();
            this.phieuXuatGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridVPhieuXuat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            dONGIALabel1 = new System.Windows.Forms.Label();
            sOLUONGLabel1 = new System.Windows.Forms.Label();
            mAVTLabel1 = new System.Windows.Forms.Label();
            mAPXLabel1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            mANVLabel1 = new System.Windows.Forms.Label();
            nGAYLabel1 = new System.Windows.Forms.Label();
            mAPXLabel = new System.Windows.Forms.Label();
            hOTENKHLabel = new System.Windows.Forms.Label();
            tENKHOLabel = new System.Windows.Forms.Label();
            hOTENLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTPXGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPHIEUXUAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVCTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHOTENNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKHO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVATTU)).BeginInit();
            this.ctmsCTPX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuXuatGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVPhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // dONGIALabel1
            // 
            dONGIALabel1.AutoSize = true;
            dONGIALabel1.Location = new System.Drawing.Point(1066, 20);
            dONGIALabel1.Name = "dONGIALabel1";
            dONGIALabel1.Size = new System.Drawing.Size(77, 19);
            dONGIALabel1.TabIndex = 24;
            dONGIALabel1.Text = "DONGIA:";
            // 
            // sOLUONGLabel1
            // 
            sOLUONGLabel1.AutoSize = true;
            sOLUONGLabel1.Location = new System.Drawing.Point(855, 18);
            sOLUONGLabel1.Name = "sOLUONGLabel1";
            sOLUONGLabel1.Size = new System.Drawing.Size(89, 19);
            sOLUONGLabel1.TabIndex = 23;
            sOLUONGLabel1.Text = "SOLUONG:";
            // 
            // mAVTLabel1
            // 
            mAVTLabel1.AutoSize = true;
            mAVTLabel1.Location = new System.Drawing.Point(677, 18);
            mAVTLabel1.Name = "mAVTLabel1";
            mAVTLabel1.Size = new System.Drawing.Size(58, 19);
            mAVTLabel1.TabIndex = 22;
            mAVTLabel1.Text = "MAVT:";
            // 
            // mAPXLabel1
            // 
            mAPXLabel1.AutoSize = true;
            mAPXLabel1.Location = new System.Drawing.Point(96, 18);
            mAPXLabel1.Name = "mAPXLabel1";
            mAPXLabel1.Size = new System.Drawing.Size(56, 19);
            mAPXLabel1.TabIndex = 21;
            mAPXLabel1.Text = "MAPX:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(277, 18);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(65, 19);
            label9.TabIndex = 2;
            label9.Text = "TENVT:";
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(393, 301);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(70, 19);
            mAKHOLabel.TabIndex = 20;
            mAKHOLabel.Text = "MAKHO:";
            // 
            // mANVLabel1
            // 
            mANVLabel1.AutoSize = true;
            mANVLabel1.Location = new System.Drawing.Point(393, 211);
            mANVLabel1.Name = "mANVLabel1";
            mANVLabel1.Size = new System.Drawing.Size(59, 19);
            mANVLabel1.TabIndex = 19;
            mANVLabel1.Text = "MANV:";
            // 
            // nGAYLabel1
            // 
            nGAYLabel1.AutoSize = true;
            nGAYLabel1.Location = new System.Drawing.Point(323, 59);
            nGAYLabel1.Name = "nGAYLabel1";
            nGAYLabel1.Size = new System.Drawing.Size(58, 19);
            nGAYLabel1.TabIndex = 18;
            nGAYLabel1.Text = "NGAY:";
            // 
            // mAPXLabel
            // 
            mAPXLabel.AutoSize = true;
            mAPXLabel.Location = new System.Drawing.Point(23, 60);
            mAPXLabel.Name = "mAPXLabel";
            mAPXLabel.Size = new System.Drawing.Size(56, 19);
            mAPXLabel.TabIndex = 17;
            mAPXLabel.Text = "MAPX:";
            // 
            // hOTENKHLabel
            // 
            hOTENKHLabel.AutoSize = true;
            hOTENKHLabel.Location = new System.Drawing.Point(25, 119);
            hOTENKHLabel.Name = "hOTENKHLabel";
            hOTENKHLabel.Size = new System.Drawing.Size(88, 19);
            hOTENKHLabel.TabIndex = 16;
            hOTENKHLabel.Text = "HOTENKH:";
            // 
            // tENKHOLabel
            // 
            tENKHOLabel.AutoSize = true;
            tENKHOLabel.Location = new System.Drawing.Point(23, 263);
            tENKHOLabel.Name = "tENKHOLabel";
            tENKHOLabel.Size = new System.Drawing.Size(77, 19);
            tENKHOLabel.TabIndex = 14;
            tENKHOLabel.Text = "TENKHO:";
            // 
            // hOTENLabel
            // 
            hOTENLabel.AutoSize = true;
            hOTENLabel.Location = new System.Drawing.Point(25, 178);
            hOTENLabel.Name = "hOTENLabel";
            hOTENLabel.Size = new System.Drawing.Size(68, 19);
            hOTENLabel.TabIndex = 6;
            hOTENLabel.Text = "HOTEN:";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1944, 45);
            this.barDockControl1.Manager = null;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl1.Size = new System.Drawing.Size(0, 752);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.Controls.Add(this.cmbChiNhanh);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1944, 81);
            this.panelControl1.TabIndex = 15;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanh.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(259, 22);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(410, 37);
            this.cmbChiNhanh.TabIndex = 10;
            this.cmbChiNhanh.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chi Nhánh";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnHieuChinh,
            this.btnGhi,
            this.btnXoa,
            this.btnPhucHoi,
            this.btnTaiLai,
            this.btnInDSNhanVien,
            this.btnThoat});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPhucHoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTaiLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnThem.Caption = "Thêm";
            this.btnThem.CloseRadialMenuOnItemClick = true;
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 30);
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 30);
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(130, 30);
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnPhucHoi.Caption = "Phục Hồi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhucHoi.ImageOptions.SvgImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(130, 30);
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnTaiLai.Caption = "Tải lại";
            this.btnTaiLai.Id = 5;
            this.btnTaiLai.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaiLai.ImageOptions.SvgImage")));
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(130, 30);
            this.btnTaiLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaiLai_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(130, 30);
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.barDockControlTop.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.barDockControlTop.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.barDockControlTop.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDockControlTop.Appearance.Options.UseBackColor = true;
            this.barDockControlTop.Appearance.Options.UseBorderColor = true;
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1944, 45);
            this.barDockControlTop.Click += new System.EventHandler(this.barDockControlTop_Click);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 797);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1944, 0);
            this.barDockControlBottom.Click += new System.EventHandler(this.barDockControlBottom_Click);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 752);
            this.barDockControlLeft.Click += new System.EventHandler(this.barDockControlLeft_Click);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1944, 45);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 752);
            this.barDockControlRight.Click += new System.EventHandler(this.barDockControlRight_Click);
            // 
            // btnHieuChinh
            // 
            this.btnHieuChinh.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnHieuChinh.Caption = "Hiệu chỉnh";
            this.btnHieuChinh.Id = 1;
            this.btnHieuChinh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHieuChinh.ImageOptions.SvgImage")));
            this.btnHieuChinh.Name = "btnHieuChinh";
            this.btnHieuChinh.Size = new System.Drawing.Size(130, 30);
            // 
            // btnInDSNhanVien
            // 
            this.btnInDSNhanVien.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnInDSNhanVien.Caption = "In DS Nhân viên";
            this.btnInDSNhanVien.Id = 6;
            this.btnInDSNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnInDSNhanVien.ImageOptions.SvgImage")));
            this.btnInDSNhanVien.Name = "btnInDSNhanVien";
            this.btnInDSNhanVien.Size = new System.Drawing.Size(170, 30);
            // 
            // cTPXGridControl
            // 
            this.cTPXGridControl.DataSource = this.bdsCTPX;
            this.cTPXGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTPXGridControl.Location = new System.Drawing.Point(615, 487);
            this.cTPXGridControl.MainView = this.gridVCTPX;
            this.cTPXGridControl.Name = "cTPXGridControl";
            this.cTPXGridControl.Size = new System.Drawing.Size(1329, 310);
            this.cTPXGridControl.TabIndex = 24;
            this.cTPXGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVCTPX});
            // 
            // bdsCTPX
            // 
            this.bdsCTPX.DataMember = "FK_CTPX_PX";
            this.bdsCTPX.DataSource = this.bdsPHIEUXUAT;
            // 
            // bdsPHIEUXUAT
            // 
            this.bdsPHIEUXUAT.DataMember = "PhieuXuat";
            this.bdsPHIEUXUAT.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridVCTPX
            // 
            this.gridVCTPX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX1,
            this.colMAVT,
            this.colSOLUONG,
            this.colDONGIA});
            this.gridVCTPX.GridControl = this.cTPXGridControl;
            this.gridVCTPX.Name = "gridVCTPX";
            this.gridVCTPX.OptionsBehavior.Editable = false;
            this.gridVCTPX.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridVCTPX_FocusedRowChanged);
            // 
            // colMAPX1
            // 
            this.colMAPX1.FieldName = "MAPX";
            this.colMAPX1.MinWidth = 30;
            this.colMAPX1.Name = "colMAPX1";
            this.colMAPX1.Visible = true;
            this.colMAPX1.VisibleIndex = 0;
            this.colMAPX1.Width = 112;
            // 
            // colMAVT
            // 
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.MinWidth = 30;
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 1;
            this.colMAVT.Width = 112;
            // 
            // colSOLUONG
            // 
            this.colSOLUONG.FieldName = "SOLUONG";
            this.colSOLUONG.MinWidth = 30;
            this.colSOLUONG.Name = "colSOLUONG";
            this.colSOLUONG.Visible = true;
            this.colSOLUONG.VisibleIndex = 2;
            this.colSOLUONG.Width = 112;
            // 
            // colDONGIA
            // 
            this.colDONGIA.FieldName = "DONGIA";
            this.colDONGIA.MinWidth = 30;
            this.colDONGIA.Name = "colDONGIA";
            this.colDONGIA.Visible = true;
            this.colDONGIA.VisibleIndex = 3;
            this.colDONGIA.Width = 112;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 38);
            this.label6.TabIndex = 10;
            this.label6.Text = "CTPX";
            // 
            // hoTenNVTableAdapter
            // 
            this.hoTenNVTableAdapter.ClearBeforeFill = true;
            // 
            // bdsHOTENNV
            // 
            this.bdsHOTENNV.DataMember = "HOTENNV";
            this.bdsHOTENNV.DataSource = this.DS;
            // 
            // bdsKHO
            // 
            this.bdsKHO.DataMember = "Kho";
            this.bdsKHO.DataSource = this.DS;
            // 
            // bdsVATTU
            // 
            this.bdsVATTU.DataMember = "Vattu";
            this.bdsVATTU.DataSource = this.DS;
            this.bdsVATTU.CurrentChanged += new System.EventHandler(this.bdsVATTU_CurrentChanged);
            // 
            // ctmsCTPX
            // 
            this.ctmsCTPX.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctmsCTPX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThem,
            this.tsmiXoa,
            this.tsmiGhi});
            this.ctmsCTPX.Name = "contextMenuStrip1";
            this.ctmsCTPX.Size = new System.Drawing.Size(129, 100);
            // 
            // tsmiThem
            // 
            this.tsmiThem.Name = "tsmiThem";
            this.tsmiThem.Size = new System.Drawing.Size(128, 32);
            this.tsmiThem.Text = "Thêm";
            this.tsmiThem.Click += new System.EventHandler(this.tsmiThem_Click);
            // 
            // tsmiXoa
            // 
            this.tsmiXoa.Name = "tsmiXoa";
            this.tsmiXoa.Size = new System.Drawing.Size(128, 32);
            this.tsmiXoa.Text = "Xóa";
            this.tsmiXoa.Click += new System.EventHandler(this.tsmiXoa_Click);
            // 
            // tsmiGhi
            // 
            this.tsmiGhi.Name = "tsmiGhi";
            this.tsmiGhi.Size = new System.Drawing.Size(128, 32);
            this.tsmiGhi.Text = "Ghi";
            this.tsmiGhi.Click += new System.EventHandler(this.tsmiGhi_Click);
            // 
            // vatTuTableAdapter
            // 
            this.vatTuTableAdapter.ClearBeforeFill = true;
            // 
            // khoTableAdapter
            // 
            this.khoTableAdapter.ClearBeforeFill = true;
            // 
            // CTPXTableAdapter
            // 
            this.CTPXTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = this.CTPXTableAdapter;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = this.khoTableAdapter;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = this.phieuXuatTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLVT_DATHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = this.vatTuTableAdapter;
            // 
            // phieuXuatTableAdapter
            // 
            this.phieuXuatTableAdapter.ClearBeforeFill = true;
            // 
            // panelControl2
            // 
            this.panelControl2.ContextMenuStrip = this.ctmsCTPX;
            this.panelControl2.Controls.Add(dONGIALabel1);
            this.panelControl2.Controls.Add(this.setDonGia);
            this.panelControl2.Controls.Add(sOLUONGLabel1);
            this.panelControl2.Controls.Add(this.setSoLuong);
            this.panelControl2.Controls.Add(mAVTLabel1);
            this.panelControl2.Controls.Add(this.txtMaVT);
            this.panelControl2.Controls.Add(mAPXLabel1);
            this.panelControl2.Controls.Add(this.txtMaPX1);
            this.panelControl2.Controls.Add(this.cmbTenVT);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Controls.Add(label9);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(615, 422);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1329, 65);
            this.panelControl2.TabIndex = 23;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // setDonGia
            // 
            this.setDonGia.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setDonGia.Location = new System.Drawing.Point(1149, 15);
            this.setDonGia.Name = "setDonGia";
            this.setDonGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.setDonGia.Properties.DisplayFormat.FormatString = "#,# VNĐ";
            this.setDonGia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.setDonGia.Properties.EditFormat.FormatString = "#";
            this.setDonGia.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.setDonGia.Properties.Mask.EditMask = "N00";
            this.setDonGia.Properties.MaxValue = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.setDonGia.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setDonGia.Size = new System.Drawing.Size(148, 28);
            this.setDonGia.TabIndex = 25;
            this.setDonGia.EditValueChanged += new System.EventHandler(this.setDonGia_EditValueChanged);
            // 
            // setSoLuong
            // 
            this.setSoLuong.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setSoLuong.Location = new System.Drawing.Point(950, 15);
            this.setSoLuong.Name = "setSoLuong";
            this.setSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.setSoLuong.Properties.DisplayFormat.FormatString = "#,#";
            this.setSoLuong.Properties.EditFormat.FormatString = "#";
            this.setSoLuong.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.setSoLuong.Properties.Mask.EditMask = "N00";
            this.setSoLuong.Properties.MaxValue = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.setSoLuong.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setSoLuong.Size = new System.Drawing.Size(97, 28);
            this.setSoLuong.TabIndex = 24;
            this.setSoLuong.EditValueChanged += new System.EventHandler(this.setSoLuong_EditValueChanged);
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(741, 15);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(100, 27);
            this.txtMaVT.TabIndex = 23;
            this.txtMaVT.TextChanged += new System.EventHandler(this.txtMaVT_TextChanged);
            // 
            // txtMaPX1
            // 
            this.txtMaPX1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsCTPX, "MAPX", true));
            this.txtMaPX1.Location = new System.Drawing.Point(158, 15);
            this.txtMaPX1.Name = "txtMaPX1";
            this.txtMaPX1.Size = new System.Drawing.Size(100, 27);
            this.txtMaPX1.TabIndex = 22;
            // 
            // cmbTenVT
            // 
            this.cmbTenVT.DataSource = this.bdsVATTU;
            this.cmbTenVT.DisplayMember = "TENVT";
            this.cmbTenVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenVT.FormattingEnabled = true;
            this.cmbTenVT.Location = new System.Drawing.Point(348, 15);
            this.cmbTenVT.Name = "cmbTenVT";
            this.cmbTenVT.Size = new System.Drawing.Size(323, 27);
            this.cmbTenVT.TabIndex = 21;
            this.cmbTenVT.ValueMember = "MAVT";
            this.cmbTenVT.SelectedIndexChanged += new System.EventHandler(this.cmbTenVT_SelectedIndexChanged);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(mAKHOLabel);
            this.panelControl4.Controls.Add(this.txtMaKho);
            this.panelControl4.Controls.Add(mANVLabel1);
            this.panelControl4.Controls.Add(this.txtMaNV);
            this.panelControl4.Controls.Add(nGAYLabel1);
            this.panelControl4.Controls.Add(this.detNgay);
            this.panelControl4.Controls.Add(mAPXLabel);
            this.panelControl4.Controls.Add(this.txtMaPX);
            this.panelControl4.Controls.Add(hOTENKHLabel);
            this.panelControl4.Controls.Add(this.txtHoTenKH);
            this.panelControl4.Controls.Add(this.cmbTenKho);
            this.panelControl4.Controls.Add(tENKHOLabel);
            this.panelControl4.Controls.Add(this.label11);
            this.panelControl4.Controls.Add(hOTENLabel);
            this.panelControl4.Controls.Add(this.cmbHoTen);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(0, 422);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(615, 375);
            this.panelControl4.TabIndex = 22;
            // 
            // txtMaKho
            // 
            this.txtMaKho.Location = new System.Drawing.Point(469, 298);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(113, 27);
            this.txtMaKho.TabIndex = 21;
            this.txtMaKho.TextChanged += new System.EventHandler(this.txtMaKho_TextChanged);
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPHIEUXUAT, "MANV", true));
            this.txtMaNV.Location = new System.Drawing.Point(458, 208);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(125, 27);
            this.txtMaNV.TabIndex = 20;
            // 
            // detNgay
            // 
            this.detNgay.EditValue = null;
            this.detNgay.Enabled = false;
            this.detNgay.Location = new System.Drawing.Point(387, 56);
            this.detNgay.Name = "detNgay";
            this.detNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detNgay.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.detNgay.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.detNgay.Size = new System.Drawing.Size(196, 28);
            this.detNgay.TabIndex = 19;
            // 
            // txtMaPX
            // 
            this.txtMaPX.Location = new System.Drawing.Point(93, 57);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(153, 27);
            this.txtMaPX.TabIndex = 18;
            // 
            // txtHoTenKH
            // 
            this.txtHoTenKH.Location = new System.Drawing.Point(119, 116);
            this.txtHoTenKH.Name = "txtHoTenKH";
            this.txtHoTenKH.Size = new System.Drawing.Size(464, 27);
            this.txtHoTenKH.TabIndex = 17;
            // 
            // cmbTenKho
            // 
            this.cmbTenKho.DataSource = this.bdsKHO;
            this.cmbTenKho.DisplayMember = "TENKHO";
            this.cmbTenKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenKho.FormattingEnabled = true;
            this.cmbTenKho.Location = new System.Drawing.Point(106, 260);
            this.cmbTenKho.Name = "cmbTenKho";
            this.cmbTenKho.Size = new System.Drawing.Size(477, 27);
            this.cmbTenKho.TabIndex = 16;
            this.cmbTenKho.ValueMember = "MAKHO";
            this.cmbTenKho.SelectedIndexChanged += new System.EventHandler(this.cmbTenKho_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(126, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(322, 32);
            this.label11.TabIndex = 14;
            this.label11.Text = "THÔNG TIN PHIẾU XUẤT";
            // 
            // cmbHoTen
            // 
            this.cmbHoTen.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPHIEUXUAT, "MANV", true));
            this.cmbHoTen.DataSource = this.bdsHOTENNV;
            this.cmbHoTen.DisplayMember = "HOTEN";
            this.cmbHoTen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbHoTen.Enabled = false;
            this.cmbHoTen.FormattingEnabled = true;
            this.cmbHoTen.Location = new System.Drawing.Point(93, 175);
            this.cmbHoTen.Name = "cmbHoTen";
            this.cmbHoTen.Size = new System.Drawing.Size(490, 27);
            this.cmbHoTen.TabIndex = 7;
            this.cmbHoTen.ValueMember = "MANV";
            // 
            // phieuXuatGridControl
            // 
            this.phieuXuatGridControl.DataSource = this.bdsPHIEUXUAT;
            this.phieuXuatGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.phieuXuatGridControl.Location = new System.Drawing.Point(0, 126);
            this.phieuXuatGridControl.MainView = this.gridVPhieuXuat;
            this.phieuXuatGridControl.Name = "phieuXuatGridControl";
            this.phieuXuatGridControl.Size = new System.Drawing.Size(1944, 296);
            this.phieuXuatGridControl.TabIndex = 21;
            this.phieuXuatGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVPhieuXuat});
            // 
            // gridVPhieuXuat
            // 
            this.gridVPhieuXuat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPX,
            this.colNGAY,
            this.colHOTENKH,
            this.colMANV,
            this.colMAKHO});
            this.gridVPhieuXuat.GridControl = this.phieuXuatGridControl;
            this.gridVPhieuXuat.Name = "gridVPhieuXuat";
            this.gridVPhieuXuat.OptionsBehavior.Editable = false;
            this.gridVPhieuXuat.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridVPhieuXuat_FocusedRowChanged);
            // 
            // colMAPX
            // 
            this.colMAPX.FieldName = "MAPX";
            this.colMAPX.MinWidth = 30;
            this.colMAPX.Name = "colMAPX";
            this.colMAPX.Visible = true;
            this.colMAPX.VisibleIndex = 0;
            this.colMAPX.Width = 112;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.MinWidth = 30;
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            this.colNGAY.Width = 112;
            // 
            // colHOTENKH
            // 
            this.colHOTENKH.FieldName = "HOTENKH";
            this.colHOTENKH.MinWidth = 30;
            this.colHOTENKH.Name = "colHOTENKH";
            this.colHOTENKH.Visible = true;
            this.colHOTENKH.VisibleIndex = 2;
            this.colHOTENKH.Width = 112;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 30;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 112;
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.MinWidth = 30;
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 4;
            this.colMAKHO.Width = 112;
            // 
            // frmPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1944, 797);
            this.Controls.Add(this.cTPXGridControl);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.phieuXuatGridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPhieuXuat";
            this.Text = "PHIẾU XUẤT";
            this.Load += new System.EventHandler(this.frmPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTPXGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPHIEUXUAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVCTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHOTENNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsKHO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVATTU)).EndInit();
            this.ctmsCTPX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuXuatGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVPhieuXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnTaiLai;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnHieuChinh;
        private DevExpress.XtraBars.BarButtonItem btnInDSNhanVien;
        private DevExpress.XtraGrid.GridControl cTPXGridControl;
        private System.Windows.Forms.BindingSource bdsCTPX;
        private System.Windows.Forms.BindingSource bdsPHIEUXUAT;
        private DS DS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVCTPX;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ContextMenuStrip ctmsCTPX;
        private System.Windows.Forms.ToolStripMenuItem tsmiThem;
        private System.Windows.Forms.ToolStripMenuItem tsmiXoa;
        private System.Windows.Forms.ToolStripMenuItem tsmiGhi;
        private DevExpress.XtraEditors.SpinEdit setSoLuong;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.TextBox txtMaPX1;
        private System.Windows.Forms.ComboBox cmbTenVT;
        private System.Windows.Forms.BindingSource bdsVATTU;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.TextBox txtMaNV;
        private DevExpress.XtraEditors.DateEdit detNgay;
        private System.Windows.Forms.TextBox txtMaPX;
        private System.Windows.Forms.TextBox txtHoTenKH;
        private System.Windows.Forms.ComboBox cmbTenKho;
        private System.Windows.Forms.BindingSource bdsKHO;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbHoTen;
        private System.Windows.Forms.BindingSource bdsHOTENNV;
        private DevExpress.XtraGrid.GridControl phieuXuatGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVPhieuXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPX;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENKH;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DSTableAdapters.HOTENNVTableAdapter hoTenNVTableAdapter;
        private DSTableAdapters.VattuTableAdapter vatTuTableAdapter;
        private DSTableAdapters.KhoTableAdapter khoTableAdapter;
        private DSTableAdapters.CTPXTableAdapter CTPXTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTableAdapters.PhieuXuatTableAdapter phieuXuatTableAdapter;
        private DevExpress.XtraEditors.SpinEdit setDonGia;
    }
}