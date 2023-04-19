using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection connPublisher = new SqlConnection() ;

        public frmDangNhap()
        {
            InitializeComponent();
        }
        
        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.serverName = cmbChiNhanh.SelectedValue.ToString();
            }
            catch (Exception) { }
        }
        private bool orgDatabase_Connect()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.connstrPublisher;
                connPublisher.Open();
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!\nBạn xem lại user name và password.\n " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Subscribers_Get(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            da.Fill(dt);

            connPublisher.Close();
            Program.bds_Subscribers.DataSource = dt;

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (orgDatabase_Connect() == false) return;
            Subscribers_Get("SELECT TOP 2 * FROM ViEW_GET_SUBSCRIBERS");
            cmbChiNhanh.SelectedIndex = 1;
            cmbChiNhanh.SelectedIndex = 0;

            txtTaiKhoan.Text = Program.crtLoginName;
            if (Program.crtLoginName != "") 
            {
                cmbChiNhanh.SelectedIndex = Program.crtBrand;
                txtMatKhau.TabIndex = 0;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Trim() == "" || txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản & mật khẩu không thể bỏ trống!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Program.loginName = txtTaiKhoan.Text.Trim();
            Program.loginPwd = txtMatKhau.Text.Trim();
            if (Program.database_Connect() == false) return;
        
            Program.crtBrand = cmbChiNhanh.SelectedIndex;
            Program.crtLoginName = Program.loginName;
            Program.crtLoginPwd = Program.loginPwd;

            String statement = "EXEC SP_GET_INFOR_LOGIN '" + Program.loginName + "'";
            Program.myReader = Program.ExecSqlDataReader(statement);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            try
            {
                Program.userName = Program.myReader.GetString(0);
                if (Convert.IsDBNull(Program.userName))
                {
                    MessageBox.Show("Tài khoản này không có quyền truy cập \n Hãy thử tài khoản khác", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Program.crtFullName = Program.myReader.GetString(1);
                Program.crtRole = Program.myReader.GetString(2);
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản này không được dùng để truy cập! \n Hãy thử tài khoản khác", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Program.myReader.Close();
            Program.conn.Close();

            Program.frm_Main.MANV.Text = "Mã Nhân Viên: " + Program.userName;
            Program.frm_Main.HOTEN.Text = "Họ Tên: " + Program.crtFullName;
            Program.frm_Main.NHOM.Text = "Nhóm: " + Program.crtRole;

            this.Visible = false;
            Program.frm_Main.buttons_Enable();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}