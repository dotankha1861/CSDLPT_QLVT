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
    public partial class frm_Bang_Ke_Chi_Tiet_Nhap_Xuat : DevExpress.XtraEditors.XtraForm
    {
        public frm_Bang_Ke_Chi_Tiet_Nhap_Xuat()
        {
            InitializeComponent();
        }

        private void frm_Bang_Ke_Chi_Tiet_Nhap_Xuat_Load(object sender, EventArgs e)
        {
            cmbLoaiPhieu.SelectedIndex = 0;
            detFrom.Text = "1/1/2010";
            detTo.Text = DateTime.Today.ToString("MM/dd/yyyy");
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (detFrom.DateTime > detTo.DateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (detTo.DateTime > DateTime.Today)
            {
                MessageBox.Show("Ngày kết thúc nhỏ hơn hoặc là ngày hiện tại!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            xrpt_Bang_Ke_Chi_Tiet_Nhap_Xuat rpt = new xrpt_Bang_Ke_Chi_Tiet_Nhap_Xuat(Program.crtRole, cmbLoaiPhieu.Text.Substring(0, 1), detFrom.DateTime, detTo.DateTime);
            rpt.lblHeader.Text = "BẢNG KÊ CHI TIẾT SỐ LƯỢNG - TRỊ GIÁ HÀNG " +cmbLoaiPhieu.Text.ToUpper();
            rpt.lblDate.Text = "Từ ngày: " + detFrom.DateTime.ToString("dd - MM - yyyy") + " đến ngày: " + detTo.DateTime.ToString("dd - MM - yyyy");
            if (Program.crtRole == "CONGTY") rpt.lblChiNhanh.Text = "Chi nhánh 1, 2";
            else rpt.lblChiNhanh.Text = "Chi nhánh " + (Program.crtBrand + 1);
            if(Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            rpt.lblStaffName.Text = Program.crtFullName;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (detFrom.DateTime > detTo.DateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            xrpt_Bang_Ke_Chi_Tiet_Nhap_Xuat rpt = new xrpt_Bang_Ke_Chi_Tiet_Nhap_Xuat(Program.crtRole, cmbLoaiPhieu.Text.Substring(0, 1), detFrom.DateTime, detTo.DateTime);
            rpt.lblHeader.Text = "BẢNG KÊ CHI TIẾT SỐ LƯỢNG - TRỊ GIÁ HÀNG " + cmbLoaiPhieu.Text.ToUpper();
            rpt.lblDate.Text = "Từ ngày: " + detFrom.DateTime.ToString("dd - MM - yyyy") + " đến ngày: " + detTo.DateTime.ToString("dd - MM - yyyy");
            if (Program.crtRole == "CONGTY") rpt.lblChiNhanh.Text = "Chi nhánh 1, 2";
            else rpt.lblChiNhanh.Text = "Chi nhánh " + (Program.crtBrand + 1);
            if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            rpt.lblStaffName.Text = Program.crtFullName;
            try
            {
                if (File.Exists("D:\\RptCTNX" + DateTime.Now.ToString("ddMMyyyyhhmmss")+ ".pdf"))
                    if (MessageBox.Show("File D:\\RptCTNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf tại ổ D đã có!\nBạn có muốn tạo lại?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                rpt.ExportToPdf("D:\\RptCTNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf" );
                MessageBox.Show("File RptCTNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf đã được ghi thành công tại ổ D", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng đóng file D:\\RptCTNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf","WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}