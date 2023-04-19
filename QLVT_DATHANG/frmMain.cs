using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTaoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmTaoTaiKhoan));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmTaoTaiKhoan form = new frmTaoTaiKhoan();
                form.MdiParent = this;
                form.Show();
            }

        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDangNhap form = new frmDangNhap();
                form.MdiParent = this;
                form.Show();
            }
        }
      
        public void buttons_Enable()
        {
            if (Program.crtRole != "USER") btnTaoTaiKhoan.Enabled = true;
            btnDangNhap.Enabled = false;
            btnDangXuat.Enabled = true;
            rib_pDanhMuc.Visible = rib_pNghiepVu.Visible = rib_pBaoCao.Visible = true; 
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn Đăng xuất không? ","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr != DialogResult.Yes) return;

            foreach (Form f in this.MdiChildren) f.Dispose();

            btnDangNhap.Enabled = true;
            btnDangXuat.Enabled = false;
            if (Program.crtRole != "USER") btnTaoTaiKhoan.Enabled = false;

            rib_pDanhMuc.Visible = rib_pNghiepVu.Visible = rib_pBaoCao.Visible = false;

            Program.frm_Main.MANV.Text = "MANV";
            Program.frm_Main.HOTEN.Text = "HOTEN";
            Program.frm_Main.NHOM.Text = "NHOM";
            
            btnDangNhap_ItemClick(sender, e);
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmKho));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmKho form = new frmKho();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmPhieuNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmPhieuNhap form = new frmPhieuNhap();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmPhieuXuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmPhieuXuat form = new frmPhieuXuat();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnBKCTNX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frm_Bang_Ke_Chi_Tiet_Nhap_Xuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frm_Bang_Ke_Chi_Tiet_Nhap_Xuat form = new frm_Bang_Ke_Chi_Tiet_Nhap_Xuat();
//                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnBCHD1NV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frm_Hoat_Dong_Nhan_Vien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frm_Hoat_Dong_Nhan_Vien form = new frm_Hoat_Dong_Nhan_Vien();
//               form.MdiParent = this;
                form.Show();
            }
        }

        private void btnTHNX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frm_Tong_Hop_Nhap_Xuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frm_Tong_Hop_Nhap_Xuat form = new frm_Tong_Hop_Nhap_Xuat();
//                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnDSDCCPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frm_Don_Hang_Chua_Co_Phieu_Nhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frm_Don_Hang_Chua_Co_Phieu_Nhap form = new frm_Don_Hang_Chua_Co_Phieu_Nhap();
                //                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnIDMVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frm_Danh_Muc_Vat_Tu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frm_Danh_Muc_Vat_Tu form = new frm_Danh_Muc_Vat_Tu();
                //                form.MdiParent = this;
                form.Show();
            }

        }

        private void btnIDSNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frm_Danh_Sach_Nhan_Vien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frm_Danh_Sach_Nhan_Vien form = new frm_Danh_Sach_Nhan_Vien();
                //                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmVatTu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmVatTu form = new frmVatTu();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnDonDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmDonDatHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmDonDatHang form = new frmDonDatHang();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(frmNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmNhanVien form = new frmNhanVien();
                form.MdiParent = this;
                form.Show();
            }
        }
    }
}
