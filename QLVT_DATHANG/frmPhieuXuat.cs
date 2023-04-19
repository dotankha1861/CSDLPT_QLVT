using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class frmPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        int indexTHEM = 0;
        int indexTHEMSub = 0;
        Stack undoList = new Stack();
        public frmPhieuXuat()
        {
            InitializeComponent();
        }

        private void in4PhieuXuatPanel_Reset()
        {
            if (gridVPhieuXuat.GetFocusedDataRow() == null)
            {
                txtMaPX.Text = "";
                detNgay.Text = "";
                cmbHoTen.Text = "";
                txtHoTenKH.Text = "";
                txtMaKho.Text = "";
                cmbTenKho.SelectedValue = "";

                cmbTenKho.Enabled =  false;
                txtMaPX.Enabled = txtHoTenKH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVPhieuXuat.GetFocusedDataRow();
                txtMaPX.Text = dtr[0].ToString();
                detNgay.EditValue = dtr[1];
                txtHoTenKH.Text = dtr[2].ToString();
                txtMaKho.Text = dtr[4].ToString();

                if (Program.crtRole == "CONGTY")
                {
                    in4CTPXPanel_Reset();
                    return;
                }

                if (Program.userName.Trim() == txtMaNV.Text.Trim())
                {
                    cmbTenKho.Enabled = txtHoTenKH.Enabled = true;
                    txtMaPX.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                    btnGhi.Enabled = btnXoa.Enabled = true;
                }

                else
                {
                    cmbTenKho.Enabled = txtHoTenKH.Enabled = false;
                    txtMaPX.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                    btnGhi.Enabled = btnXoa.Enabled = false;
                }
            }
            in4CTPXPanel_Reset();
        }

        private void in4CTPXPanel_Reset()
        {
            if (gridVCTPX.GetFocusedDataRow() == null)
            {
                txtMaVT.Text = "";
                cmbTenVT.SelectedValue = "";
                setSoLuong.Text = "";
                setDonGia.Text = "";

                cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = false;
                txtMaPX1.Enabled = txtMaVT.Enabled = false;
                //bật tắt nút lệnh
                ctmsCTPX.Enabled = true;
                if (bdsPHIEUXUAT.Count == 0) tsmiThem.Enabled = false;
                else tsmiThem.Enabled = true;
                tsmiGhi.Enabled = tsmiXoa.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVCTPX.GetFocusedDataRow();
                txtMaVT.Text = dtr[1].ToString();
                setSoLuong.Text = dtr[2].ToString();
                setDonGia.Text = dtr[3].ToString();

                if (Program.crtRole == "CONGTY") return;

                if (Program.userName.Trim() == txtMaNV.Text.Trim())
                {
                    cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = true;
                    txtMaPX1.Enabled = txtMaVT.Enabled = false;

                    //bật tắt nút lệnh
                    ctmsCTPX.Enabled = true;

                    if (bdsCTPX.Count == 0) tsmiXoa.Enabled = tsmiGhi.Enabled = false;
                    else tsmiXoa.Enabled = tsmiGhi.Enabled = true;
                }
                else
                {
                    cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = false;
                    txtMaPX1.Enabled = txtMaVT.Enabled = false;
                    ctmsCTPX.Enabled = false;
                    //bật tắt nút lệnh
                }
            }
        }
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            this.vatTuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vatTuTableAdapter.Fill(this.DS.Vattu);

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);

            this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hoTenNVTableAdapter.Fill(this.DS.HOTENNV);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPXTableAdapter.Fill(this.DS.CTPX);

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.crtBrand;

            if (Program.crtRole == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;

                cmbHoTen.Enabled = txtHoTenKH.Enabled = cmbTenKho.Enabled = false;
                txtMaPX.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = false;
                txtMaPX1.Enabled = txtMaVT.Enabled = false;

                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
                ctmsCTPX.Enabled = false;
            }
            else cmbChiNhanh.Enabled = false;

            btnPhucHoi.Enabled = false;
            gridVPhieuXuat.OptionsBehavior.Editable = false;
            gridVCTPX.OptionsBehavior.Editable = false;
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
                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDown;
                cmbHoTen.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDown;

                this.vatTuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vatTuTableAdapter.Fill(this.DS.Vattu);

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS.Kho);

                this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hoTenNVTableAdapter.Fill(this.DS.HOTENNV);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

                this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTPXTableAdapter.Fill(this.DS.CTPX);

                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbHoTen.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDownList;

                in4PhieuXuatPanel_Reset();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexTHEM = bdsPHIEUXUAT.Position;

            bdsPHIEUXUAT.AddNew();

            detNgay.EditValue = DateTime.Today;
            txtMaNV.Text = Program.userName;
            cmbHoTen.Text = Program.crtFullName;

           // if (bdsKHO.Count > 0) cmbTenKho.SelectedIndex = 0;

            txtMaPX.Enabled = txtHoTenKH.Enabled = cmbTenKho.Enabled = true;

            phieuXuatGridControl.Enabled = false;
            cTPXGridControl.Enabled = false;
            panelControl2.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaPX.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu xuất không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPX.Focus();
                return;
            }

            //Sửa lỗi lại ...
            if (Regex.IsMatch(txtMaPX.Text.Trim(), @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã phiếu chỉ chấp nhận chữ không dấu và số!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPX.Focus();
                return;
            }

            if (txtMaPX.Text.Length > 8)
            {
                MessageBox.Show("Mã phiếu xuất không thể lớn hơn 8 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPX.Focus();
                return;
            }
            if (txtHoTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Tên khách hàng không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKH.Focus();
                return;
            }

            if (Regex.IsMatch(txtHoTenKH.Text.Trim(), @"^[a-zA-ZáàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Tên khách hàng chỉ chấp nhận chữ cái và khoảng trắng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKH.Focus();
                return;
            }

            if (txtHoTenKH.Text.Length > 100)
            {
                MessageBox.Show("Tên khách hàng không thể quá 100 kí tự", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKH.Focus();
                return;
            }

            if (cmbTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn kho!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenKho.Focus();
                return;
            }

            if (txtMaPX.Text.Trim()!=gridVPhieuXuat.GetFocusedDataRow()[0].ToString().Trim())
            {
                int check_MAPX = Program.alreadyExist_check("MAPX", "'" + txtMaPX.Text.Trim() + "'");
                if (check_MAPX == -1) return;
                else if (check_MAPX == 1)
                {
                    MessageBox.Show("Mã phiếu xuất đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPX.Focus();
                    return;
                }
            }    
            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string strlenh = "";
                    object[] updated_Values = null;

                    if (btnThem.Enabled == false)
                    {
                        strlenh = "DELETE";
                    }
                    else
                    {
                        strlenh = "UPDATE";
                        updated_Values = gridVPhieuXuat.GetFocusedDataRow().ItemArray;
                    }

                    DataRow dtr = gridVPhieuXuat.GetFocusedDataRow();
                    dtr[0] = txtMaPX.Text.Trim();
                    dtr[1] = detNgay.DateTime;
                    dtr[2] = txtHoTenKH.Text.Trim();
                    dtr[3] = txtMaNV.Text.Trim();
                    dtr[4] = txtMaKho.Text.Trim();
                    bdsPHIEUXUAT.ResetCurrentItem();
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);

                    int index = DS.PhieuXuat.Rows.IndexOf(dtr);
                    if (btnThem.Enabled == true) undoList.Push(updated_Values);

                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push("PX");
                    in4PhieuXuatPanel_Reset();

                    phieuXuatGridControl.Enabled = true;
                    cTPXGridControl.Enabled = true;
                    panelControl2.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất!\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu xuất này vì đã có CTPX!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    object[] inserted_Values = gridVPhieuXuat.GetFocusedDataRow().ItemArray;
                    int index = DS.PhieuXuat.Rows.IndexOf(gridVPhieuXuat.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsPHIEUXUAT.RemoveCurrent();

                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);

                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push("PX");

                    in4PhieuXuatPanel_Reset();

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu xuất. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                    return;
                }
            }
            if (bdsPHIEUXUAT.Count == 0) btnXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                bdsPHIEUXUAT.CancelEdit();
                bdsPHIEUXUAT.Position = indexTHEM;

                in4PhieuXuatPanel_Reset();

                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsPHIEUXUAT.Count > 0) btnXoa.Enabled = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                panelControl1.Enabled = panelControl2.Enabled = phieuXuatGridControl.Enabled = cTPXGridControl.Enabled = true;
                return;
            }
            string type = (string)undoList.Pop();

            if (type == "PX")
            {
                DataRow dtr_tmp = Program.undo_Execute(undoList, DS.PhieuXuat);
                if (dtr_tmp == null) gridVPhieuXuat.MoveLastVisible();
                else bdsPHIEUXUAT.Position = DS.PhieuXuat.Rows.IndexOf(dtr_tmp);
                this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);
                in4PhieuXuatPanel_Reset();
                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsPHIEUXUAT.Count > 0) btnXoa.Enabled = true;
                else btnXoa.Enabled = false;
            }
            else // type = "CTPX"
            {
                DataRow dtr_PX = (DataRow)undoList.Pop();
                DataRow dtr_CTPX = Program.undo_Execute(undoList, DS.CTPX);
                bdsPHIEUXUAT.Position = DS.PhieuXuat.Rows.IndexOf(dtr_PX);
                this.CTPXTableAdapter.Update(this.DS.CTPX);
                if (dtr_CTPX == null) gridVCTPX.MoveLastVisible();
                else bdsCTPX.Position = (int)undoList.Pop();
                in4PhieuXuatPanel_Reset();
                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsCTPX.Count > 0) tsmiXoa.Enabled = true;
                else tsmiXoa.Enabled = false;
            }
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDown;
                cmbHoTen.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDown;

                this.vatTuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vatTuTableAdapter.Fill(this.DS.Vattu);

                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS.Kho);

                this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hoTenNVTableAdapter.Fill(this.DS.HOTENNV);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

                this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTPXTableAdapter.Fill(this.DS.CTPX);

                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbHoTen.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDownList;

                undoList.Clear();
                in4PhieuXuatPanel_Reset();

                btnPhucHoi.Enabled = false;
                if (bdsPHIEUXUAT.Count == 0) btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                in4PhieuXuatPanel_Reset();
                MessageBox.Show("Lỗi Reload:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tsmiThem_Click(object sender, EventArgs e)
        {
            if (barDockControlTop.Enabled == true)
            {
                indexTHEMSub = bdsPHIEUXUAT.Position;

                bdsCTPX.AddNew();

                if (bdsVATTU.Count > 0) cmbTenVT.SelectedIndex = 0;
                txtMaPX1.Text = txtMaPX.Text;
                setSoLuong.Text = "1";
                setDonGia.Text = "1";
                cmbTenKho.Enabled = setDonGia.Enabled = setSoLuong.Enabled = true;

                tsmiThem.Text = "Bỏ thêm";
                barDockControlTop.Enabled = false;
                phieuXuatGridControl.Enabled = false;
                cTPXGridControl.Enabled = false;
                panelControl4.Enabled = false;

                tsmiXoa.Enabled = false;
                tsmiGhi.Enabled = tsmiThem.Enabled = true;
            }
            else
            {
                bdsCTPX.CancelEdit();
                bdsCTPX.Position = indexTHEMSub;

                in4CTPXPanel_Reset();
                if (bdsCTPX.Count > 0) btnXoa.Enabled = true;

                barDockControlTop.Enabled = panelControl4.Enabled = phieuXuatGridControl.Enabled = cTPXGridControl.Enabled = true;
                tsmiThem.Text = "Thêm";
                return;
            }

        }

        private void tsmiGhi_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(setDonGia.Text.Trim(), @"^[0-9]+$") == false)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setDonGia.Focus();
                return;
            }
            if (Regex.IsMatch(setSoLuong.Text.Trim(), @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setSoLuong.Focus();
                return;
            }
            if (txtMaVT.Text.Trim() != gridVCTPX.GetFocusedDataRow()[1].ToString().Trim())
            {
                int check_MAVT_MAPX = Program.alreadyExist_check("MAVT_MAPX", "'" +txtMaVT.Text.Trim() + "','" + txtMaPX.Text.Trim() + "'");
                if (check_MAVT_MAPX == -1) return;
                else if (check_MAVT_MAPX == 1)
                {
                    MessageBox.Show("Phiếu Xuất đã có vật tư này rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTenVT.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string strlenh = "";
                    object[] updated_Values = null;

                    if (barDockControlTop.Enabled == false)
                    {
                        strlenh = "DELETE";
                    }
                    else
                    {
                        strlenh = "UPDATE";
                        updated_Values = gridVCTPX.GetFocusedDataRow().ItemArray;
                    }

                    DataRow dtr = gridVCTPX.GetFocusedDataRow();
                    dtr[1] = txtMaVT.Text.Trim();
                    dtr[2] = (int)setSoLuong.Value;
                    dtr[3] = (int)setDonGia.Value;


                    bdsCTPX.ResetCurrentItem();
                    this.CTPXTableAdapter.Update(this.DS.CTPX);

                    int index = DS.CTPX.Rows.IndexOf(dtr);
                    if (barDockControlTop.Enabled == true)
                    {
                        undoList.Push(bdsCTPX.Position);
                        undoList.Push(updated_Values);
                    }
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push(gridVPhieuXuat.GetFocusedDataRow());
                    undoList.Push("CTPX");
                    in4CTPXPanel_Reset();

                    tsmiThem.Text = "Thêm";
                    barDockControlTop.Enabled = true;
                    phieuXuatGridControl.Enabled = true;
                    cTPXGridControl.Enabled = true;
                    panelControl4.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu xuất!\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    object[] inserted_Values = gridVCTPX.GetFocusedDataRow().ItemArray;
                    int index = DS.CTPX.Rows.IndexOf(gridVCTPX.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsCTPX.RemoveCurrent();

                    this.CTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.CTPXTableAdapter.Update(this.DS.CTPX);
                    undoList.Push(bdsCTPX.Position);
                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push(gridVPhieuXuat.GetFocusedDataRow());
                    undoList.Push("CTPX");
                    in4PhieuXuatPanel_Reset();

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa CTPN. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                    return;
                }
            }
            if (bdsCTPX.Count == 0) tsmiXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void gridVPhieuXuat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4PhieuXuatPanel_Reset();
        }

        private void gridVCTPX_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4CTPXPanel_Reset();
        }

        private void cmbTenKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaKho.Text = cmbTenKho.SelectedValue.ToString();
            }
            catch (Exception) { }
        }
        private void cmbTenVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaVT.Text = cmbTenVT.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void txtMaKho_TextChanged(object sender, EventArgs e)
        {
            cmbTenKho.SelectedValue = txtMaKho.Text;

        }

        private void txtMaVT_TextChanged(object sender, EventArgs e)
        {
            cmbTenVT.SelectedValue = txtMaVT.Text;
        }


        private void barDockControlTop_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlBottom_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlLeft_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlRight_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bdsVATTU_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void setDonGia_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void setSoLuong_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}