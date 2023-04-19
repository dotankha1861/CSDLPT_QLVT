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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class frmDonDatHang : DevExpress.XtraEditors.XtraForm
    {
        int indexTHEM;
        int indexTHEMSub;
        Stack undoList = new Stack();
        public frmDonDatHang()
        {
            InitializeComponent();
        }

        private void in4DDHPanel_Reset()
        {
            if (gridVDDH.GetFocusedDataRow() == null)
            {
                txtMaDDH.Text = "";
                dteNgayDat.Text = "";
                txtNhaCC.Text = "";
                cmbHoTen.Text = "";
                txtMaKho.Text = "";
                cmbTenKho.SelectedValue = "";

                cmbTenKho.Enabled = txtNhaCC.Enabled = false;
                txtMaDDH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVDDH.GetFocusedDataRow();
                txtMaDDH.Text = dtr[0].ToString();
                dteNgayDat.EditValue = dtr[1];
                txtNhaCC.Text = dtr[2].ToString();
                
                txtMaKho.Text = dtr[4].ToString();

                if (Program.crtRole == "CONGTY")
                {
                    in4CTDDHPanel_Reset();
                    return;
                }

                if (Program.userName.Trim() == txtMaNV.Text.Trim())
                {
                    cmbTenKho.Enabled = txtNhaCC.Enabled = true;
                    txtMaDDH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                    btnGhi.Enabled = btnXoa.Enabled = true;
                }

                else
                {
                    cmbTenKho.Enabled = txtNhaCC.Enabled = false;
                    txtMaDDH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                    btnGhi.Enabled = btnXoa.Enabled = false;
                }
            }
            in4CTDDHPanel_Reset();
        }

        private void in4CTDDHPanel_Reset()
        {
            if (gridVCTDDH.GetFocusedDataRow() == null)
            {
                txtMaVT.Text = "";
                cmbTenVT.SelectedValue = "";
                setSoLuong.Text = "";
                setDonGia.Text = "";

                cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = false;
                txtMaDDH.Enabled = txtMaVT.Enabled = false;
                //bật tắt nút lệnh
                ctmsCTDDH.Enabled = true;
                if (bdsDatHang.Count == 0) tsmiThem.Enabled = false;
                else tsmiThem.Enabled = true;
                tsmiGhi.Enabled = tsmiXoa.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVCTDDH.GetFocusedDataRow();
                txtMaVT.Text = dtr[1].ToString();
                setSoLuong.Text = dtr[2].ToString();
                setDonGia.Text = dtr[3].ToString();

                if (Program.crtRole == "CONGTY") return;

                if (Program.userName.Trim() == txtMaNV.Text.Trim())
                {
                    cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = true;
                    txtMaDDH1.Enabled = txtMaVT.Enabled = false;

                    //bật tắt nút lệnh
                    ctmsCTDDH.Enabled = true;

                    if (bdsCTDDH.Count == 0) tsmiXoa.Enabled = tsmiGhi.Enabled = false;
                    else tsmiXoa.Enabled = tsmiGhi.Enabled = true;
                }
                else
                {
                    cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = false;
                    txtMaDDH1.Enabled = txtMaVT.Enabled = false;
                    ctmsCTDDH.Enabled = false;
                    //bật tắt nút lệnh
                }
            }
        }
        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;

            this.vatTuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vatTuTableAdapter.Fill(this.DS.Vattu);

            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);

            this.DatHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.DatHangTableAdapter.Fill(this.DS.DatHang);

            this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTDDHTableAdapter.Fill(this.DS.CTDDH);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            this.HoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.HoTenNVTableAdapter.Fill(this.DS.HOTENNV);

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.crtBrand;

            if (Program.crtRole == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;

                cmbHoTen.Enabled = cmbTenKho.Enabled = false;
                txtMaDDH.Enabled = dteNgayDat.Enabled = txtNhaCC.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                cmbTenVT.Enabled = setSoLuong.Enabled = setDonGia.Enabled = false;
                txtMaDDH1.Enabled = txtMaVT.Enabled = false;

                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
                ctmsCTDDH.Enabled = false;
            }
            else cmbChiNhanh.Enabled = false;

            btnPhucHoi.Enabled = false;
            gridVDDH.OptionsBehavior.Editable = false;
            gridVCTDDH.OptionsBehavior.Editable = false;

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

                this.HoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.HoTenNVTableAdapter.Fill(this.DS.HOTENNV);

                this.DatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.DatHangTableAdapter.Fill(this.DS.DatHang);

                this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTDDHTableAdapter.Fill(this.DS.CTDDH);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbHoTen.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDownList;

                in4DDHPanel_Reset();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmbTenKho.SelectedIndex = -1;

            indexTHEM = bdsDatHang.Position;

            bdsDatHang.AddNew();

            dteNgayDat.EditValue = DateTime.Today;
            txtMaNV.Text = Program.userName;
            cmbHoTen.Text = Program.crtFullName;

            txtMaDDH.Enabled = txtNhaCC.Enabled = cmbTenKho.Enabled = true;

            gcDatHang.Enabled = false;
            gcCTDDH.Enabled = false;
            panelControl3.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaDDH.Text.Trim() == "")
            {
                MessageBox.Show("Mã đơn đặt hàng không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDDH.Focus();
                return;
            }

            if (Regex.IsMatch(txtMaDDH.Text.Trim(), @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã đơn đặt hàng chỉ chấp nhận chữ không dấu và số!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDDH.Focus();
                return;
            }

            if (txtMaDDH.Text.Length > 8)
            {
                MessageBox.Show("Mã đơn đặt hàng không thể lớn hơn 8 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDDH.Focus();
                return;
            }
            if (txtMaDDH.Text.Trim() != gridVDDH.GetFocusedDataRow()[0].ToString().Trim())
            {
                int check_MADDH = Program.alreadyExist_check("MASODDH", "'" + txtMaDDH.Text.Trim() + "'");
                if (check_MADDH == -1) return;
                else if (check_MADDH == 1)
                {
                    MessageBox.Show("Mã đơn đặt hàng đã tồn tại!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDDH.Focus();
                    return;
                }
            }

            if (txtNhaCC.Text.Trim() == "")
            {
                MessageBox.Show("Nhà cung cấp chưa được chọn!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenKho.Focus();
                return;
            }

            if (txtNhaCC.Text.Length > 100)
            {
                MessageBox.Show("Nhà cung cấp quá 100 ký tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenKho.Focus();
                return;
            }

            if (cmbTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn kho!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenKho.Focus();
                return;
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
                        updated_Values = gridVDDH.GetFocusedDataRow().ItemArray;
                    }

                    DataRow dtr = gridVDDH.GetFocusedDataRow();
                    dtr[0] = txtMaDDH.Text.Trim();
                    dtr[1] = dteNgayDat.DateTime;
                    dtr[2] = txtNhaCC.Text.Trim();
                    dtr[3] = txtMaNV.Text.Trim();
                    dtr[4] = txtMaKho.Text.Trim();
                    bdsDatHang.ResetCurrentItem();
                    this.DatHangTableAdapter.Update(this.DS.DatHang);

                    int index = DS.DatHang.Rows.IndexOf(dtr);
                    if (btnThem.Enabled == true) undoList.Push(updated_Values);

                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push("DDH");
                    in4DDHPanel_Reset();
                    //    cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;

                    gcDatHang.Enabled = true;
                    gcCTDDH.Enabled = true;
                    panelControl3.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đơn đặt hàng!\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa đơn đặt hàng này vì đã có CTDDH!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    object[] inserted_Values = gridVDDH.GetFocusedDataRow().ItemArray;
                    int index = DS.DatHang.Rows.IndexOf(gridVDDH.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsDatHang.RemoveCurrent();

                    this.DatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.DatHangTableAdapter.Update(this.DS.DatHang);

                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push("DDH");

                    in4DDHPanel_Reset();

                    //  cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu nhập. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DatHangTableAdapter.Fill(this.DS.DatHang);
                    return;
                }
            }
            if (bdsDatHang.Count == 0) btnXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                bdsDatHang.CancelEdit();
                bdsDatHang.Position = indexTHEM;

                in4DDHPanel_Reset();

                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsDatHang.Count > 0) btnXoa.Enabled = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                //    cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;
                panelControl1.Enabled = panelControl3.Enabled = gcDatHang.Enabled = gcCTDDH.Enabled = true;
                return;
            }
            string type = (string)undoList.Pop();

            if (type == "DDH")
            {
                DataRow dtr_tmp = Program.undo_Execute(undoList, DS.DatHang);
                if (dtr_tmp == null) gridVDDH.MoveLastVisible();
                else bdsDatHang.Position = DS.DatHang.Rows.IndexOf(dtr_tmp);
                this.DatHangTableAdapter.Update(this.DS.DatHang);
                in4DDHPanel_Reset();
                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsDatHang.Count > 0) btnXoa.Enabled = true;
                else btnXoa.Enabled = false;
            }
            else
            {
                DataRow dtr_DDH = (DataRow)undoList.Pop();
                DataRow dtr_CTDDH = Program.undo_Execute(undoList, DS.CTDDH);
                bdsDatHang.Position = DS.DatHang.Rows.IndexOf(dtr_DDH);
                this.CTDDHTableAdapter.Update(this.DS.CTDDH);
                if (dtr_CTDDH == null) gridVCTDDH.MoveLastVisible();
                else bdsCTDDH.Position = (int)undoList.Pop();
                in4DDHPanel_Reset();
                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsCTDDH.Count > 0) tsmiXoa.Enabled = true;
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

                this.HoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
                this.HoTenNVTableAdapter.Fill(this.DS.HOTENNV);

                this.DatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.DatHangTableAdapter.Fill(this.DS.DatHang);

                this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTDDHTableAdapter.Fill(this.DS.CTDDH);

                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbHoTen.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDownList;

                undoList.Clear();
                in4DDHPanel_Reset();

                btnPhucHoi.Enabled = false;
                if (bdsDatHang.Count == 0) btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                in4DDHPanel_Reset();
                MessageBox.Show("Lỗi Reload:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void tsmiThem_Click(object sender, EventArgs e)
        {
            if (barDockControlTop.Enabled == true)
            {
                indexTHEMSub = bdsDatHang.Position;

                bdsCTDDH.AddNew();

                if (bdsVATTU.Count > 0) cmbTenVT.SelectedIndex = 0;
                txtMaDDH1.Text = txtMaDDH.Text;
                setSoLuong.Text = "1";
                setDonGia.Text = "1";
                cmbTenKho.Enabled = setDonGia.Enabled = setSoLuong.Enabled = true;

                tsmiThem.Text = "Bỏ thêm";
                barDockControlTop.Enabled = false;
                gcDatHang.Enabled = false;
                gcCTDDH.Enabled = false;
                panelControl2.Enabled = false;

                tsmiXoa.Enabled = false;
                tsmiGhi.Enabled = tsmiThem.Enabled = true;
            }
            else
            {
                bdsCTDDH.CancelEdit();
                bdsCTDDH.Position = indexTHEMSub;

                in4CTDDHPanel_Reset();
                if (bdsCTDDH.Count > 0) btnXoa.Enabled = true;

                barDockControlTop.Enabled = panelControl2.Enabled = gcDatHang.Enabled = gcCTDDH.Enabled = true;
                tsmiThem.Text = "Thêm";
                return;
            }
        }

        private void tsmiGhi_Click(object sender, EventArgs e)
        {
            if (txtMaVT.Text.Trim() != gridVCTDDH.GetFocusedDataRow()[1].ToString().Trim())
            {
                int check_MAVT_MADDH = Program.alreadyExist_check("MAVT_MADDH", "'" + txtMaVT.Text.Trim() + "','" + txtMaDDH.Text.Trim() + "'");
                if (check_MAVT_MADDH == -1) return;
                else if (check_MAVT_MADDH == 1)
                {
                    MessageBox.Show("Đơn đặt hàng đã có vật tư này rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        updated_Values = gridVCTDDH.GetFocusedDataRow().ItemArray;
                    }

                    DataRow dtr = gridVCTDDH.GetFocusedDataRow();
                    dtr[1] = txtMaVT.Text.Trim();
                    dtr[2] = (int)setSoLuong.Value;
                    dtr[3] = (int)setDonGia.Value;


                    bdsCTDDH.ResetCurrentItem();
                    this.CTDDHTableAdapter.Update(this.DS.CTDDH);

                    int index = DS.CTDDH.Rows.IndexOf(dtr);
                    if (barDockControlTop.Enabled == true)
                    {
                        undoList.Push(bdsCTDDH.Position);
                        undoList.Push(updated_Values);
                    }
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push(gridVDDH.GetFocusedDataRow());
                    undoList.Push("CTDDH");
                    in4CTDDHPanel_Reset();

                    tsmiThem.Text = "Thêm";
                    barDockControlTop.Enabled = true;
                    gcDatHang.Enabled = true;
                    gcCTDDH.Enabled = true;
                    panelControl2.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi đơn đặt hàng!\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    object[] inserted_Values = gridVCTDDH.GetFocusedDataRow().ItemArray;
                    int index = DS.CTDDH.Rows.IndexOf(gridVCTDDH.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsCTDDH.RemoveCurrent();

                    this.CTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.CTDDHTableAdapter.Update(this.DS.CTDDH);
                    undoList.Push(bdsCTDDH.Position);
                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push(gridVDDH.GetFocusedDataRow());
                    undoList.Push("CTDDH");
                    in4DDHPanel_Reset();

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa CTDDH. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DatHangTableAdapter.Fill(this.DS.DatHang);
                    return;
                }
            }
            if (bdsCTDDH.Count == 0) tsmiXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }
        private void txtMaDDH_TextChanged(object sender, EventArgs e)
        {

        }


        private void gridDH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4DDHPanel_Reset();
        }

        private void gridVCTDDH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4CTDDHPanel_Reset();
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKho_TextChanged(object sender, EventArgs e)
        {
                cmbTenKho.SelectedValue = txtMaKho.Text;

        }

        private void txtMaVT_TextChanged(object sender, EventArgs e)
        {
            cmbTenVT.SelectedValue = txtMaVT.Text;
        }
    }
}
