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
    public partial class frm_Danh_Sach_Nhan_Vien : DevExpress.XtraEditors.XtraForm
    {
        public frm_Danh_Sach_Nhan_Vien()
        {
            InitializeComponent();
        }

        private void frm_Danh_Sach_Nhan_Vien_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";

            if (Program.crtRole != "CONGTY") cmbChiNhanh.Enabled = false;
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            xrpt_DS_Nhan_Vien rpt = new xrpt_DS_Nhan_Vien();
            rpt.lblChiNhanh.Text = "*** CHI NHÁNH " + (Program.crtBrand + 1) + " ***";
            if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            rpt.lblStaffName.Text = Program.crtFullName;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            xrpt_DS_Nhan_Vien rpt = new xrpt_DS_Nhan_Vien();
            rpt.lblChiNhanh.Text = "*** CHI NHÁNH " + (Program.crtBrand + 1) + " ***";
            if (Program.crtBrand == 0) rpt.lblToday.Text = "TP HCM, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            else rpt.lblToday.Text = "TP Đà Nẵng, ngày " + (DateTime.Today).Day + " tháng " + (DateTime.Today).Month + " năm " + (DateTime.Today).Year;
            rpt.lblStaffName.Text = Program.crtFullName;
            try
            {
                if (File.Exists("D:\\RptDSNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf"))
                    if (MessageBox.Show("File D:\\RptDSNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf tại ổ D đã có!\nBạn có muốn tạo lại?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                rpt.ExportToPdf("D:\\RptDSNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf");
                MessageBox.Show("File RptDSNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf đã được ghi thành công tại ổ D", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng đóng file D:\\RptDSNV" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}