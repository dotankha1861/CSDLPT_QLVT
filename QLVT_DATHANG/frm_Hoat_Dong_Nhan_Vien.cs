using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class frm_Hoat_Dong_Nhan_Vien : DevExpress.XtraEditors.XtraForm
    {
        public frm_Hoat_Dong_Nhan_Vien()
        {
            InitializeComponent();
        }

        private void frm_Hoat_Dong_Nhan_Vien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.HOTENNV' table. You can move, or remove it, as needed.
            this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hoTenNVTableAdapter.Fill(this.DS.HOTENNV);

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            try
            {
                txtMaNV.Text = cmbHoTen.SelectedValue.ToString();
            }
            catch (Exception) { }
            if (Program.crtRole != "CONGTY") cmbChiNhanh.Enabled = false;

            detDateFrom.Text = "1/1/2010";
            detDateTo.Text = DateTime.Today.ToString("MM/dd/yyyy");
        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                txtMaNV.Text = cmbHoTen.SelectedValue.ToString();
            }
            catch(Exception){ }
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            if (detDateFrom.DateTime > detDateTo.DateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (detDateTo.DateTime > DateTime.Today)
            {
                MessageBox.Show("Ngày kết thúc nhỏ hơn hoặc là ngày hiện tại!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            xrpt_Hoat_Dong_Nhan_Vien rpt = new xrpt_Hoat_Dong_Nhan_Vien(int.Parse(txtMaNV.Text),detDateFrom.DateTime, detDateTo.DateTime);
            Program.myReader = Program.ExecSqlDataReader("SELECT DIACHI, NGAYSINH, LUONG FROM NHANVIEN WHERE MANV = " + txtMaNV.Text.Trim());
            if (Program.myReader == null) return;
            try
            {
                Program.myReader.Read();
                rpt.lblMaNV.Text = "Mã nhân viên:   "+ txtMaNV.Text;
                rpt.lblHoTen.Text = "Họ tên:           " + cmbHoTen.Text;
                rpt.lblDiaChi.Text = "Địa chỉ:           " + Program.myReader.GetString(0);
                rpt.lblNgaySinh.Text ="Ngày sinh:         " + Program.myReader.GetDateTime(1).ToString("dd - MM - yyyy");
                rpt.lblLuong.Text = "Lương:               " + Program.myReader.GetDouble(2).ToString();
                rpt.lblChiNhanh.Text = "Chi nhánh:     " + cmbChiNhanh.Text;
            }
            catch (Exception) { }
            Program.myReader.Close();
            if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            rpt.lblStaffName.Text = Program.crtFullName;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Program.serverName = cmbChiNhanh.SelectedValue.ToString();

            if (cmbChiNhanh.SelectedIndex != Program.crtBrand)
            {
                Program.loginName = Program.rmeLoginName;
                Program.loginPwd = Program.rmeLoginPwd;
            }
            else
            {
                Program.loginName = Program.crtLoginName;
                Program.loginPwd = Program.crtLoginPwd;
            }

            if (Program.database_Connect() == false) MessageBox.Show("Xảy ra lỗi kết nối với chi nhánh hiện tại!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hoTenNVTableAdapter.Fill(this.DS.HOTENNV);
                try
                {
                    txtMaNV.Text = cmbHoTen.SelectedValue.ToString();
                }
                catch (Exception) { }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            xrpt_Hoat_Dong_Nhan_Vien rpt = new xrpt_Hoat_Dong_Nhan_Vien(int.Parse(txtMaNV.Text), detDateFrom.DateTime, detDateTo.DateTime);
            if (detDateFrom.DateTime > detDateTo.DateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Program.myReader = Program.ExecSqlDataReader("SELECT DIACHI, NGAYSINH, LUONG FROM NHANVIEN WHERE MANV = " + txtMaNV.Text.Trim());
            if (Program.myReader == null) return;
            try
            {
                Program.myReader.Read();
                rpt.lblMaNV.Text = "Mã nhân viên:   " + txtMaNV.Text;
                rpt.lblHoTen.Text = "Họ tên:           " + cmbHoTen.Text;
                rpt.lblDiaChi.Text = "Địa chỉ:           " + Program.myReader.GetString(0);
                rpt.lblNgaySinh.Text = "Ngày sinh:         " + Program.myReader.GetDateTime(1).ToString("dd - MM - yyyy");
                rpt.lblLuong.Text = "Lương:               " + Program.myReader.GetDouble(2).ToString();
                rpt.lblChiNhanh.Text = "Chi nhánh:     " + cmbChiNhanh.Text;
                if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
                else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
                rpt.lblStaffName.Text = Program.crtFullName;
            }
            catch (Exception) { }
            Program.myReader.Close();
            try
            {
                    if (File.Exists("D:\\RptHDNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf"))
                    if (MessageBox.Show("File D:\\RptHDNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf tại ổ D đã có!\nBạn có muốn tạo lại?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                rpt.ExportToPdf("D:\\RptHDNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf");
                MessageBox.Show("File RptHDNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf đã được ghi thành công tại ổ D", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng đóng file D:\\RptHDNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}