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
    public partial class frmTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {

        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            cmbMaNhanVien.DataSource = Program.ExecSqlDataTable("EXEC SP_NHAN_VIEN_CHUA_TAO_LOGIN");
            cmbMaNhanVien.DisplayMember = "HOTEN";
            cmbMaNhanVien.ValueMember = "MANV";
            //????
            cmbMaNhanVien.SelectedIndex = -1;
   
            if (Program.crtRole == "CONGTY")
            {
                rdoCHINHANH.Text = "CONGTY";
                rdoCHINHANH.Checked = true;
                rdoCHINHANH.Enabled = false;
                rdoUSER.Visible = false;
            }
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (cmbMaNhanVien.Text == "")
            {
                MessageBox.Show("Thiếu mã nhân viên!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Thiếu tên tài khoản!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Thiếu mật khẩu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            if (txtXacNhanMK.Text == "")
            {
                MessageBox.Show("Chưa xác nhận mật khẩu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu không khớp với mật khẩu xác nhận!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            if (rdoCHINHANH.Checked == false && rdoUSER.Checked == false)
            {
                MessageBox.Show("Chưa chọn nhóm cho tài khoản!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

            string createdRole = "";
            if(Program.crtRole == "CONGTY") createdRole = "CONGTY";
            else createdRole = (rdoCHINHANH.Checked == true) ? "CHINHANH" : "USER";

            String cmd = "EXEC sp_Tao_Login '" + txtTaiKhoan.Text.Trim() + "' , '" + txtMatKhau.Text.Trim() + "', '"
                             + cmbMaNhanVien.SelectedValue.ToString() + "', '" + createdRole + "'";

            Program.myReader = Program.ExecSqlDataReader(cmd);
            if (Program.myReader == null) return;
            MessageBox.Show("Đăng kí tài khoản thành công!\nTài khoản: " + txtTaiKhoan.Text.Trim() + "\nMật khẩu: " + txtMatKhau.Text.Trim() + "\nNhân Viên: " + cmbMaNhanVien.Text + "\nNhóm: " + createdRole, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Program.myReader.Close();

            cmbMaNhanVien.DataSource = Program.ExecSqlDataTable("EXEC SP_NHAN_VIEN_CHUA_TAO_LOGIN");
            cmbMaNhanVien.DisplayMember = "HOTEN";
            cmbMaNhanVien.ValueMember = "MANV";
            cmbMaNhanVien.SelectedIndex = -1;
            
            cmbMaNhanVien.Text = txtMatKhau.Text = txtTaiKhoan.Text = txtXacNhanMK.Text = "";
            
            if(Program.crtRole != "CONGTY") rdoCHINHANH.Checked = rdoUSER.Checked = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}