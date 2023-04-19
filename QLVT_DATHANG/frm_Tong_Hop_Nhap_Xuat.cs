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
    public partial class frm_Tong_Hop_Nhap_Xuat : DevExpress.XtraEditors.XtraForm
    {
        public frm_Tong_Hop_Nhap_Xuat()
        {
            InitializeComponent();
        }

        private void frm_Tong_Hop_Nhap_Xuat_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";

            if (Program.crtRole != "CONGTY") cmbChiNhanh.Enabled = false;

            detFrom.Text = "1/1/2010";
            detTo.Text = DateTime.Today.ToString("MM/dd/yyyy");
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
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
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
            DateTime dateFrom = detFrom.DateTime;
            DateTime dateTo = detTo.DateTime;
            xrpt_Tong_Hop_Nhap_Xuat rpt = new xrpt_Tong_Hop_Nhap_Xuat(detFrom.DateTime, detTo.DateTime);
            rpt.lblDate.Text = "Từ ngày: " + dateFrom.ToString("dd - MM - yyyy") + " đến ngày: " + dateTo.ToString("dd - MM - yyyy");
            rpt.lblChiNhanh.Text = "*** CHI NHÁNH " + (Program.crtBrand + 1)+" ***";
            if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
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
            DateTime dateFrom = detFrom.DateTime;
            DateTime dateTo = detTo.DateTime;
            xrpt_Tong_Hop_Nhap_Xuat rpt = new xrpt_Tong_Hop_Nhap_Xuat(detFrom.DateTime, detTo.DateTime);
            rpt.lblDate.Text = "Từ ngày: " + dateFrom.ToString("dd - MM - yyyy") + " đến ngày: " + dateTo.ToString("dd - MM - yyyy");
            rpt.lblChiNhanh.Text = "*** CHI NHÁNH " + (Program.crtBrand + 1) +" ***";
            if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            rpt.lblStaffName.Text = Program.crtFullName;
            try
            {
                if (File.Exists("D:\\RptTHNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf"))
                    if (MessageBox.Show("File D:\\RptTHNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf tại ổ D đã có!\nBạn có muốn tạo lại?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                rpt.ExportToPdf("D:\\RptTHNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf");
                MessageBox.Show("File RptTHNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf đã được ghi thành công tại ổ D", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng đóng file D:\\RptTHNX" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}