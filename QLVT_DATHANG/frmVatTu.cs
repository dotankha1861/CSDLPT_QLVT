using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class frmVatTu : Form
    {
        public frmVatTu()
        {
            InitializeComponent();
        }

        private int indexTHEM = 0;
        Stack undoList = new Stack();

        void in4Panel_Reset()
        {
            if (gridVVatTu.GetFocusedDataRow() == null)
            {
                txtMAVT.Text = "";
                txtTENVT.Text = "";
                txtDVT.Text = "";
                //setSLT.Text = "";

                txtMAVT.Enabled = txtTENVT.Enabled = txtDVT.Enabled = false;//setSLT.Enabled = false;
                btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVVatTu.GetFocusedDataRow();
                txtMAVT.Text = dtr[0].ToString();
                txtTENVT.Text = dtr[1].ToString();
                txtDVT.Text = dtr[2].ToString();
                //setSLT.Text = dtr[3].ToString();

                if (Program.crtRole == "CONGTY") return;

                txtMAVT.Enabled = false;
                txtTENVT.Enabled = txtDVT.Enabled = true;
                btnXoa.Enabled = btnGhi.Enabled = true;
            }
        }
        private void frmVatTu_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);

            this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPNTableAdapter.Fill(this.DS.CTPN);

            this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPXTableAdapter.Fill(this.DS.CTPX);

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.crtBrand;

            if (Program.crtRole == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
                txtTENVT.Enabled = txtMAVT.Enabled = txtDVT.Enabled = false; //setSLT.Enabled = false;
            }
            else cmbChiNhanh.Enabled = false;

            btnPhucHoi.Enabled = false;
            gridVVatTu.OptionsBehavior.Editable = false;

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
                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS.Vattu);

                in4Panel_Reset();
            }
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexTHEM = bdsVatTu.Position;
            bdsVatTu.AddNew();

            txtMAVT.Enabled = true;
            //setSLT.Value = 0;

            gcVatTu.Enabled = false;
            pcChiTiet.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAVT.Text.Trim() == "")
            {
                MessageBox.Show("Mã vật tư không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Sửa lỗi lại ...
            if (Regex.IsMatch(txtMAVT.Text.Trim(), @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã vật tư chỉ chấp nhận chữ không dấu và số!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMAVT.Focus();
                return;
            }

            if (txtMAVT.Text.Length > 4)
            {
                MessageBox.Show("Mã vật tư không thể lớn hơn 4 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMAVT.Focus();
                return;
            }

            if (txtTENVT.Text.Trim() == "")
            {
                MessageBox.Show("Tên vật tư không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTENVT.Focus();
                return;
            }

            if (Regex.IsMatch(txtTENVT.Text.Trim(), @"^[a-zA-Z0-9áàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Tên vật tư chỉ chấp nhận chữ cái, số và khoảng trắng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTENVT.Focus();
                return;
            }

            if (txtTENVT.Text.Length > 30)
            {
                MessageBox.Show("Tên vật tư không thể quá 30 kí tự", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTENVT.Focus();
                return;
            }
            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Đơn vị tính không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
                return;
            }

            if (Regex.IsMatch(txtDVT.Text.Trim(), @"^[a-zA-ZáàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Đơn vị tính gồm chữ cái và khoảng trắng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
                return;
            }

            if (txtDVT.Text.Length > 15)
            {
                MessageBox.Show("Đơn vị tính không quá 15 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
                return;
            }

            if (txtMAVT.Text.Trim() != gridVVatTu.GetFocusedDataRow()[0].ToString().Trim())
            {
                int check_MAVT = Program.alreadyExist_check("MAVT", "'" + txtMAVT.Text.Trim() + "'");
                if (check_MAVT == -1) return;
                else if (check_MAVT == 1)
                {
                    MessageBox.Show("Mã vật tư đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMAVT.Focus();
                    return;
                }
            }
            if (txtTENVT.Text.Trim() != gridVVatTu.GetFocusedDataRow()[1].ToString().Trim())
            {
                int check_TENVT = Program.alreadyExist_check("TENVT", "N'" + txtTENVT.Text.Trim() + "'");
                if (check_TENVT == -1) return;
                else if (check_TENVT == 1)
                {
                    MessageBox.Show("Tên vật tư đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMAVT.Focus();
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
                        updated_Values = gridVVatTu.GetFocusedDataRow().ItemArray;
                    }
                    DataRow dtr = gridVVatTu.GetFocusedDataRow();
                    dtr[0] = txtMAVT.Text.Trim();
                    dtr[1] = txtTENVT.Text.Trim();
                    dtr[2] = txtDVT.Text.Trim();
                   
                    bdsVatTu.ResetCurrentItem();
                    this.vattuTableAdapter.Update(this.DS.Vattu);

                    int index = DS.Vattu.Rows.IndexOf(dtr);

                    if (btnThem.Enabled == true) undoList.Push(updated_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);

                    in4Panel_Reset();

                    gcVatTu.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi vật tư!\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (undoList.Count > 0) btnPhucHoi.Enabled = true;
            }
        }
        private int kiemTraVatTuCoSuDungTaiChiNhanhKhac(String maVatTu)
        {
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaVatTuChiNhanhConLai '" +
                    maVatTu + "' " +
                    "SELECT 'Value' = @result";
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                if (Program.myReader == null)
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return 1;
            }
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            /*result = 1 nghia la vat tu nay dang duoc su dung o chi nhanh con lai*/
            int ketQua = (result == 1) ? 1 : 0;

            return ketQua;
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập chi tiết đơn đặt hàng!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập chi tiết phiếu nhập!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập chi tiết phiếu xuất!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            String maVatTu = txtMAVT.Text.Trim();
            int ketQua = kiemTraVatTuCoSuDungTaiChiNhanhKhac(maVatTu);

            if (ketQua == 1)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đang được sử dụng ở chi nhánh khác", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    object[] inserted_Values = gridVVatTu.GetFocusedDataRow().ItemArray;
                    int index = DS.Vattu.Rows.IndexOf(gridVVatTu.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsVatTu.RemoveCurrent();

                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.DS.Vattu);

                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);

                    in4Panel_Reset();

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa vật tư. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.vattuTableAdapter.Fill(this.DS.Vattu);
                    return;
                }
            }
            if (bdsVatTu.Count == 0) btnXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                bdsVatTu.CancelEdit();
                bdsVatTu.Position = indexTHEM;
                in4Panel_Reset();

                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                gcVatTu.Enabled = true;
                return;
            }

            DataRow dtr_tmp = Program.undo_Execute(undoList, DS.Vattu);
            if (dtr_tmp == null) gridVVatTu.MoveLastVisible();
            else bdsVatTu.Position = DS.Vattu.Rows.IndexOf(dtr_tmp);

            this.vattuTableAdapter.Update(this.DS.Vattu);
            in4Panel_Reset();
            if (undoList.Count == 0) btnPhucHoi.Enabled = false;
            if (bdsVatTu.Count > 0) btnXoa.Enabled = true;
            else btnXoa.Enabled = false;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.vattuTableAdapter.Fill(this.DS.Vattu);

                undoList.Clear();

                in4Panel_Reset();

                btnPhucHoi.Enabled = false;
                if (bdsVatTu.Count == 0) btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mAVTLabel_Click(object sender, EventArgs e)
        {

        }

        private void gridVVatTu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4Panel_Reset();
        }
    }
}
