using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLVT_DATHANG
{
    public partial class frmNhanVien : Form
    {
        private int indexTHEM = 0;
        String crtBrand = "";
        Stack undoList = new Stack();
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = -1;
            age = DateTime.Now.Year - dateOfBirth.Year;
            return age;
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNhanVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            if (bdsNhanVien.Count > 0)
                crtBrand = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.crtBrand;

            if (Program.crtRole == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;
                this.pcChiTiet.Enabled = false;

                this.btnThem.Enabled = this.btnGhi.Enabled = this.btnXoa.Enabled = this.btnChuyenChiNhanh.Enabled = false;
            }

            if (Program.crtRole == "CHINHANH" || Program.crtRole == "USER")
            {
                cmbChiNhanh.Enabled = false;
                this.pcChiTiet.Enabled = true;

                this.btnThem.Enabled = this.btnGhi.Enabled = this.btnXoa.Enabled = this.btnChuyenChiNhanh.Enabled = true;

                this.txtMANV.Enabled = this.TrangThaiXoaCheckBox.Enabled = false;
            }
            this.btnTaiLai.Enabled = this.btnThoat.Enabled = true;
            btnPhucHoi.Enabled = false;

            gridVNhanVien.OptionsBehavior.Editable = false;
        }
        void in4Panel_Reset()
        {
            if (gridVNhanVien.GetFocusedDataRow() == null)
            {
                txtMANV.Text = "";
                txtHO.Text = "";
                txtTEN.Text = "";
                txtDiaChi.Text = "";
                dteNgaySinh.Text = "";
                setLuong.Value = 0;
                txtMACN.Text = crtBrand;
                btnChuyenChiNhanh.Enabled = false;

                txtMANV.Enabled = txtHO.Enabled = txtTEN.Enabled = dteNgaySinh.Enabled = setLuong.Enabled = txtDiaChi.Enabled = TrangThaiXoaCheckBox.Enabled = false;
                btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnChuyenChiNhanh.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVNhanVien.GetFocusedDataRow();
                txtMANV.Text = dtr[0].ToString();
                txtHO.Text = dtr[1].ToString();
                txtTEN.Text = dtr[2].ToString();
                txtDiaChi.Text = dtr[3].ToString();
                dteNgaySinh.EditValue = dtr[4];
                setLuong.Text = dtr[5].ToString();
                txtMACN.Text = dtr[6].ToString();
                btnChuyenChiNhanh.Enabled = false;

                if (Program.crtRole == "CONGTY") return;

                txtMANV.Enabled = txtMACN.Enabled = false;
                txtHO.Enabled = txtTEN.Enabled = txtDiaChi.Enabled = dteNgaySinh.Enabled = setLuong.Enabled = true;

                btnXoa.Enabled = btnGhi.Enabled = true;
                if (TrangThaiXoaCheckBox.Checked == false) btnChuyenChiNhanh.Enabled = true;
                else btnChuyenChiNhanh.Enabled = false;
            }
        }
        private void gcNhanVien_Click(object sender, EventArgs e)
        {

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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

                in4Panel_Reset();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexTHEM = bdsNhanVien.Position;

            this.gcNhanVien.Enabled = false;
            this.pcChiTiet.Enabled = true;

            bdsNhanVien.AddNew();

            txtMACN.Text = crtBrand;
            setLuong.Value = 4000000;

            this.txtMANV.Enabled = true;
            this.btnThem.Enabled = this.btnXoa.Enabled = this.btnTaiLai.Enabled = this.btnChuyenChiNhanh.Enabled = this.btnThoat.Enabled = false;
            this.btnGhi.Enabled = this.btnPhucHoi.Enabled = true;

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                txtMANV.Focus();
                return;
            }

            if (Regex.IsMatch(txtMANV.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Mã nhân viên chỉ chấp nhận số", "Thông báo", MessageBoxButtons.OK);
                txtMANV.Focus();
                return;
            }

            if (txtHO.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return;
            }

            if (Regex.IsMatch(txtHO.Text, @"^[A-Za-záàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Họ chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return;
            }

            if (txtHO.Text.Length > 40)
            {
                MessageBox.Show("Họ không thể lớn hơn 40 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return;
            }

            if (txtTEN.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return;
            }

            if (Regex.IsMatch(txtTEN.Text, @"^[a-zA-ZáàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ]+$") == false)
            {
                MessageBox.Show("Tên người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return;
            }

            if (txtTEN.Text.Length > 10)
            {
                MessageBox.Show("Tên không thể lớn hơn 10 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }

            if (Regex.IsMatch(txtDiaChi.Text, @"^[a-zA-Z0-9,áàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Địa chỉ chỉ chấp nhận chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }

            if (txtDiaChi.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không quá 100 ký tự", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if (CalculateAge(dteNgaySinh.DateTime) < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK);
                dteNgaySinh.Focus();
                return;
            }
            if (setLuong.Value == 0 || setLuong.Value < 4000000)
            {
                MessageBox.Show("Mức lương không thể bỏ trống hoặc nhỏ hơn 4,000,000 đồng!", "Thông báo", MessageBoxButtons.OK);
                setLuong.Focus();
                return;
            }
            if (txtMANV.Text.Trim() != gridVNhanVien.GetFocusedDataRow()[0].ToString().Trim())
            {
                int check_MANV = Program.alreadyExist_check("MANV", "'" + txtMANV.Text.Trim() + "'");
                if (check_MANV == -1) return;
                else if (check_MANV == 1)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMANV.Focus();
                    return;
                }
            }

            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string strlenh = "";
                    object[] updated_Values = null;
                    if (btnThem.Enabled == false) strlenh = "DELETE";
                    else
                    {
                        strlenh = "UPDATE";
                        updated_Values = gridVNhanVien.GetFocusedDataRow().ItemArray;
                    }
                    DataRow dtr = gridVNhanVien.GetFocusedDataRow();
                    dtr[0] = txtMANV.Text.Trim();
                    dtr[1] = txtHO.Text.Trim();
                    dtr[2] = txtTEN.Text.Trim();
                    dtr[3] = txtDiaChi.Text.Trim();
                    dtr[4] = dteNgaySinh.DateTime;
                    dtr[5] = setLuong.Text.Trim();
                    dtr[6] = crtBrand;
                    dtr[7] = (TrangThaiXoaCheckBox.Checked == true) ? 1 : 0;

                    bdsNhanVien.ResetCurrentItem();
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);

                    int index = DS.NhanVien.Rows.IndexOf(dtr);

                    if (btnThem.Enabled == true) undoList.Push(updated_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);

                    in4Panel_Reset();

                    gcNhanVien.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi nhân viên!\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (undoList.Count > 0) btnPhucHoi.Enabled = true;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String MANV = ((DataRowView)bdsNhanVien[bdsNhanVien.Position])["MANV"].ToString();

            if (MANV == Program.userName)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (bdsDatHang.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPhieuNhap.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPhieuXuat.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {

                    object[] inserted_Values = gridVNhanVien.GetFocusedDataRow().ItemArray;
                    int index = DS.NhanVien.Rows.IndexOf(gridVNhanVien.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsNhanVien.RemoveCurrent();

                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Update(this.DS.NhanVien);

                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);

                    in4Panel_Reset();

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string strLenh = "EXEC sp_Xoa_Login '" + MANV.Trim() + "'";

                    Program.ExecSqlNonQuery(strLenh);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    return;
                }
            }
            if (bdsNhanVien.Count == 0) btnXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }
        public static DataRow undo_Execute2(Stack undoList, DataTable dt)
        {
            string strlenh = (string)undoList.Pop();
            int index = (int)(undoList.Pop());
            DataRow dr = null;
            if (strlenh == "INSERT")
            {
                dr = dt.NewRow();
                dr.ItemArray = (object[])(undoList.Pop());
                dt.Rows.InsertAt(dr, index);
            }
            else if (strlenh == "DELETE") dt.Rows[index].Delete();
            else if (strlenh == "UPDATE")
            {
                dr = dt.Rows[index];
                dr.ItemArray = (object[])(undoList.Pop());
            }
            else //chinhanh
            {
                try
                {
                    string crtServer = Program.serverName;
                    string newServer = Program.serverNameLeft;

                    Program.serverName = newServer;
                    Program.loginName = Program.rmeLoginName;
                    Program.loginPwd = Program.rmeLoginPwd;

                    if (Program.database_Connect() == false)
                    {
                        MessageBox.Show(Program.connstr, "Thông báo", MessageBoxButtons.OK);
                        return null;
                    }

                  
                    Program.ExecSqlNonQuery((string)undoList.Pop());
                    dr = dt.Rows[index];
                    dr["TrangThaiXoa"] = false;
                    dr.AcceptChanges();
                    MessageBox.Show("Chuyển nhân viên trở lại thành công", "Thông báo", MessageBoxButtons.OK);

                    Program.serverName = crtServer;
                    Program.loginName = Program.crtLoginName;
                    Program.loginPwd = Program.crtLoginPwd;
                    if (Program.database_Connect() == false)
                    {
                        MessageBox.Show(Program.connstr, "Thông báo", MessageBoxButtons.OK);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển nhân viên thất bại \n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return null;
                }
            }
            return dr;
        }
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                bdsNhanVien.CancelEdit();
                bdsNhanVien.Position = indexTHEM;
                in4Panel_Reset();

                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                gcNhanVien.Enabled = true;
                return;
            }
            DataRow dtr_tmp = undo_Execute2(undoList, DS.NhanVien);
            if (dtr_tmp == null) gridVNhanVien.MoveLastVisible();
            else bdsNhanVien.Position = DS.NhanVien.Rows.IndexOf(dtr_tmp);

            this.nhanVienTableAdapter.Update(this.DS.NhanVien);
            in4Panel_Reset();
            if (undoList.Count == 0) btnPhucHoi.Enabled = false;
            if (bdsNhanVien.Count > 0) btnXoa.Enabled = true;
            else btnXoa.Enabled = false;


        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                undoList.Clear();
                in4Panel_Reset();
                btnPhucHoi.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lại!:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void chuyenChiNhanh(String chiNhanh)
        {
            if (Program.serverName == chiNhanh)
            {
                MessageBox.Show("Hãy chọn chi nhánh khác chi nhánh bạn đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String newBrand = "";
            int crtPosition = bdsNhanVien.Position;
            String MaNV = ((DataRowView)bdsNhanVien[crtPosition])["MANV"].ToString();

            if (chiNhanh.Contains("1"))
            {
                crtBrand = "CN2";
                newBrand = "CN1";
            }
            else if (chiNhanh.Contains("2"))
            {
                crtBrand = "CN1";
                newBrand = "CN2";
            }
            else
            {
                MessageBox.Show("Mã chi nhánh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newMANV = "";
            String cauTruyVan = "DECLARE @KQ INT; EXEC @KQ = sp_Chuyen_Chi_Nhanh '" + MaNV + "','" + newBrand + "' ; SELECT @KQ";
            Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
            if (Program.myReader == null) return;
            try
            {
                Program.myReader.Read();
                newMANV = Program.myReader.GetInt32(0).ToString();
                gridVNhanVien.GetFocusedDataRow()["TrangThaiXoa"] = true;
                MessageBox.Show("Chuyển chi nhánh thành công", "thông báo", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
 
                return;
            }
            String srtLenh = "EXEC sp_Chuyen_Chi_Nhanh '" + newMANV.Trim() + "','" + crtBrand + "'";
            Program.serverNameLeft = chiNhanh;
            undoList.Push(srtLenh);
            undoList.Push(DS.NhanVien.Rows.IndexOf(gridVNhanVien.GetFocusedDataRow()));
            undoList.Push("ChuyenCN");
            DS.NhanVien.AcceptChanges();

            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnChuyenChiNhanh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int crtPosition = bdsNhanVien.Position;
            Boolean trangThaiXoa = (Boolean)((DataRowView)(bdsNhanVien[crtPosition]))["TrangThaiXoa"];
            string MaNV = ((DataRowView)(bdsNhanVien[crtPosition]))["MANV"].ToString();

            if (MaNV == Program.userName)
            {
                MessageBox.Show("Không thể chuyển chính người đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (trangThaiXoa == true)
            {
                MessageBox.Show("Nhân viên này không có ở chi nhánh này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form f = this.CheckExists(typeof(frmChuyenChiNhanh));
            if (f != null)
            {
                f.Activate();
            }
            frmChuyenChiNhanh form = new frmChuyenChiNhanh();
            form.Show();

            form.branchTransfer = new frmChuyenChiNhanh.MyDelegate(chuyenChiNhanh);

            in4Panel_Reset();

            this.btnPhucHoi.Enabled = true;
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void gridVNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4Panel_Reset();
        }

        private void pcChiTiet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tENLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtTEN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

