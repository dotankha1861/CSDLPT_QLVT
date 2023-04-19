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
    public partial class frmPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        int indexTHEM;
      
        public static bool save = false;
        Stack undoList = new Stack();

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void in4PhieuNhapPanel_Reset() 
        {
            if (gridVPhieuNhap.GetFocusedDataRow() == null)
            {
                txtMaPN.Text = "";
                detNgay.Text = "";
                cmbHoTen.Text = "";
                cmbMaSoDDH.Text = "";
                txtMaKho.Text = "";
                //cmbMaSoDDH.SelectedValue = "";
                cmbTenKho.SelectedValue = "";

                cmbTenKho.Enabled = false;
                txtMaPN.Enabled = cmbMaSoDDH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVPhieuNhap.GetFocusedDataRow();
                txtMaPN.Text = dtr[0].ToString();
                detNgay.EditValue = dtr[1];            
                cmbMaSoDDH.Text = dtr[2].ToString();
                txtMaKho.Text = dtr[4].ToString();

                if(Program.crtRole == "CONGTY")
                {
                    in4CTPNPanel_Reset();
                    return;
                }

                if (Program.userName.Trim() == txtMaNV.Text.Trim())
                {
                    cmbTenKho.Enabled = true;
                    txtMaPN.Enabled = cmbMaSoDDH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;
                   
                    btnGhi.Enabled = btnXoa.Enabled = true;
                }

                else
                {
                    cmbTenKho.Enabled = false;
                    txtMaPN.Enabled = cmbMaSoDDH.Enabled = cmbHoTen.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;

                    btnGhi.Enabled = btnXoa.Enabled = false;
                }
            }
            in4CTPNPanel_Reset();
        }

        private void in4CTPNPanel_Reset()
        {
            if (gridVCTPN.GetFocusedDataRow() == null)
            {
                txtMaVT.Text = "";
                cmbTenVT.SelectedValue = "";
                setSoLuong.Text = "";
                setDonGia.Text = "";

                setSoLuong.Enabled = setDonGia.Enabled = false;
                txtMaPN1.Enabled = txtMaVT.Enabled = false;
                //bật tắt nút lệnh
                ctmsCTPN.Enabled = true;
                if (bdsPHIEUNHAP.Count == 0) tsmiThem.Enabled = false;
                else tsmiThem.Enabled = true;
                tsmiGhi.Enabled = tsmiXoa.Enabled = false;
            }
            else 
            {
                DataRow dtr = gridVCTPN.GetFocusedDataRow();
                txtMaVT.Text = dtr[1].ToString();
                setSoLuong.Text = dtr[2].ToString();
                setDonGia.Text = dtr[3].ToString();

                if (Program.crtRole == "CONGTY") return;

                if (Program.userName.Trim() == txtMaNV.Text.Trim())
                {
                    setSoLuong.Enabled = setDonGia.Enabled = true;
                    txtMaPN1.Enabled = txtMaVT.Enabled = false;

                    //bật tắt nút lệnh
                    ctmsCTPN.Enabled = true;

                    if (bdsCTPN.Count == 0) tsmiXoa.Enabled = tsmiGhi.Enabled = false;
                    else tsmiXoa.Enabled = tsmiGhi.Enabled = true;
                }
                else
                {
                    setSoLuong.Enabled = setDonGia.Enabled = false;
                    txtMaPN1.Enabled = txtMaVT.Enabled = false;
                    ctmsCTPN.Enabled = false;
                    //bật tắt nút lệnh
                }
            }
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;

            this.vatTuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vatTuTableAdapter.Fill(this.DS.Vattu);
        
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);
         
            this.hoTenNVTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hoTenNVTableAdapter.Fill(this.DS.HOTENNV);
            
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.CTPNTableAdapter.Fill(this.DS.CTPN);

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.crtBrand;

            if (Program.crtRole == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;

                cmbHoTen.Enabled = cmbMaSoDDH.Enabled = cmbTenKho.Enabled = false;
                txtMaPN.Enabled = txtMaNV.Enabled = txtMaKho.Enabled = false;
                
                setSoLuong.Enabled = setDonGia.Enabled = false;
                txtMaPN1.Enabled = txtMaVT.Enabled = false;
                
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
                ctmsCTPN.Enabled = false;
            }
            else cmbChiNhanh.Enabled = false;

            btnPhucHoi.Enabled = false;
            gridVPhieuNhap.OptionsBehavior.Editable = false;
            gridVCTPN.OptionsBehavior.Editable = false;
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

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
             
                this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTPNTableAdapter.Fill(this.DS.CTPN);

                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbHoTen.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDownList;

                in4PhieuNhapPanel_Reset();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_DON_HANG_CHUA_PHIEU_NHAP_1");
           
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có đơn hàng nào chưa có phiếu nhập!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cmbMaSoDDH.DataSource = dt;
            cmbMaSoDDH.DisplayMember = "MASODDH";
            cmbMaSoDDH.ValueMember = "MASODDH";
            cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbMaSoDDH.SelectedIndex = -1;
            cmbTenKho.SelectedIndex = -1;

            indexTHEM = bdsPHIEUNHAP.Position;

            bdsPHIEUNHAP.AddNew();

            detNgay.EditValue = DateTime.Today;
            txtMaNV.Text = Program.userName;
            cmbHoTen.Text = Program.crtFullName;
            //if (bdsKHO.Count > 0) cmbTenKho.SelectedIndex = 0;

            txtMaPN.Enabled = cmbMaSoDDH.Enabled = cmbTenKho.Enabled = true;

            phieuNhapGridControl.Enabled = false;
            cTPNGridControl.Enabled = false;
            panelControl3.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaPN.Text.Trim() == "")
            {
                MessageBox.Show("Mã phiếu nhập không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPN.Focus();
                return;
            }

            //Sửa lỗi lại ...
            if (Regex.IsMatch(txtMaPN.Text.Trim(), @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã phiếu chỉ chấp nhận chữ không dấu và số!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPN.Focus();
                return;
            }

            if (txtMaPN.Text.Length > 8)
            {
                MessageBox.Show("Mã phiếu nhập không thể lớn hơn 8 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPN.Focus();
                return;
            }
            if(txtMaPN.Text.Trim()!= gridVPhieuNhap.GetFocusedDataRow()[0].ToString().Trim())
            {
                int check_MAPN = Program.alreadyExist_check("MAPN", "'" + txtMaPN.Text.Trim() + "'");
                if (check_MAPN == -1) return;
                else if (check_MAPN == 1)
                {
                    MessageBox.Show("Mã phiếu nhập đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPN.Focus();
                    return;
                }
            }
            if (cmbMaSoDDH.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn mã đơn hàng!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaSoDDH.Focus();
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
                        updated_Values = gridVPhieuNhap.GetFocusedDataRow().ItemArray;
                    }

                    DataRow dtr = gridVPhieuNhap.GetFocusedDataRow();
                    dtr[0] = txtMaPN.Text.Trim();
                    dtr[1] = detNgay.DateTime;
                    dtr[2] = cmbMaSoDDH.Text.Trim();
                    dtr[3] = txtMaNV.Text.Trim();
                    dtr[4] = txtMaKho.Text.Trim();
                    bdsPHIEUNHAP.ResetCurrentItem();
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);
                    
                    int index = DS.PhieuNhap.Rows.IndexOf(dtr);
                    if (btnThem.Enabled == true) undoList.Push(updated_Values);
                    
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push("PN");
                    in4PhieuNhapPanel_Reset();
                    cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;

                    phieuNhapGridControl.Enabled = true;
                    cTPNGridControl.Enabled = true;
                    panelControl3.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu nhập!\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa phiếu nhập này vì đã có CTPN!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    object[] inserted_Values = gridVPhieuNhap.GetFocusedDataRow().ItemArray;
                    int index = DS.PhieuNhap.Rows.IndexOf(gridVPhieuNhap.GetFocusedDataRow());
                    string strlenh = "INSERT";
                    
                    bdsPHIEUNHAP.RemoveCurrent();
                    
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);
                   
                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push("PN");
                    
                    in4PhieuNhapPanel_Reset();
                    
                    cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa phiếu nhập. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
                    return;
                }
            }
            if (bdsPHIEUNHAP.Count == 0) btnXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                bdsPHIEUNHAP.CancelEdit();
                bdsPHIEUNHAP.Position = indexTHEM;

                in4PhieuNhapPanel_Reset();

                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsPHIEUNHAP.Count > 0) btnXoa.Enabled = true;
                btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
              
                cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;
                panelControl1.Enabled = panelControl3.Enabled = phieuNhapGridControl.Enabled = cTPNGridControl.Enabled = true;
            
                return;
            }
            string type = (string)undoList.Pop();
       
            if (type == "PN") 
            {
                DataRow dtr_tmp = Program.undo_Execute(undoList, DS.PhieuNhap);
                if (dtr_tmp == null) gridVPhieuNhap.MoveLastVisible();
                else bdsPHIEUNHAP.Position = DS.PhieuNhap.Rows.IndexOf(dtr_tmp);
                this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);
                in4PhieuNhapPanel_Reset();
                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsPHIEUNHAP.Count > 0) btnXoa.Enabled = true;
                else btnXoa.Enabled = false;
            }
            else // type = "CTPN"
            { 
                DataRow dtr_PN = (DataRow)undoList.Pop();
                DataRow dtr_CTPN = Program.undo_Execute(undoList, DS.CTPN);
                bdsPHIEUNHAP.Position = DS.PhieuNhap.Rows.IndexOf(dtr_PN);
                this.CTPNTableAdapter.Update(this.DS.CTPN);
                if (dtr_CTPN == null) gridVCTPN.MoveLastVisible();
                else bdsCTPN.Position = (int)undoList.Pop();
                in4PhieuNhapPanel_Reset();
                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                if (bdsCTPN.Count > 0) tsmiXoa.Enabled = true;
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

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

                this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.CTPNTableAdapter.Fill(this.DS.CTPN);

                cmbTenKho.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbHoTen.DropDownStyle = ComboBoxStyle.Simple;
                cmbTenVT.DropDownStyle = ComboBoxStyle.DropDownList;

                undoList.Clear();
                in4PhieuNhapPanel_Reset();
                
                btnPhucHoi.Enabled = false;
                if (bdsPHIEUNHAP.Count == 0) btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                in4PhieuNhapPanel_Reset();
                MessageBox.Show("Lỗi Reload:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void tsmiThem_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            dt = Program.ExecSqlDataTable("EXEC SP_LAY_DSVT_CHUA_CO_O_PHIEU_NHAP '" + cmbMaSoDDH.Text + "','" + txtMaPN.Text.Trim() + "'");
            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn vật tư nào có thể thêm!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            barDockControlTop.Enabled = false;
            phieuNhapGridControl.Enabled = false;
            cTPNGridControl.Enabled = false;
            panelControl2.Enabled = false;
            panelControl3.Enabled = false;
            tsmiXoa.Enabled = false;
            tsmiGhi.Enabled = tsmiThem.Enabled = true;
            
            Form f = this.CheckExists(typeof(frmVatTuChuaCoOPhieuNhap));

            if (f != null)
            {
                f.Activate();
            }
            else
            {
                frmVatTuChuaCoOPhieuNhap form = new frmVatTuChuaCoOPhieuNhap();

                form.dtgridV.DataSource = dt;
                DataGridViewCheckBoxColumn dgvcCheckBox = new DataGridViewCheckBoxColumn();
                dgvcCheckBox.HeaderText = "";
                form.dtgridV.Columns.Add(dgvcCheckBox);
                form.dtgridV.Columns[0].Width = 150;
                form.dtgridV.Columns[1].Width = 300;
                form.dtgridV.Columns[2].Width = 250;
                form.dtgridV.Columns[3].Width = 210;
                form.dtgridV.Columns[4].Width = 150;

                form.dtgridV.Columns[0].ReadOnly = true;
                form.dtgridV.Columns[1].ReadOnly = true;

                form.ShowDialog();
                if(save == true)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        object[] ars = null;
                        if (dt.Rows[i].RowState != DataRowState.Deleted)
                        {
                            ars = dt.Rows[i].ItemArray;
                            gridVCTPN.AddNewRow();
                            gridVCTPN.GetFocusedDataRow()[0] = txtMaPN.Text;
                            gridVCTPN.GetFocusedDataRow()[1] = ars[0];
                            gridVCTPN.GetFocusedDataRow()[2] = ars[2];
                            gridVCTPN.GetFocusedDataRow()[3] = ars[3];
                            bdsCTPN.EndEdit();

                            undoList.Push(DS.CTPN.Rows.IndexOf(gridVCTPN.GetFocusedDataRow()));
                            undoList.Push("DELETE");
                            undoList.Push(gridVPhieuNhap.GetFocusedDataRow());
                            undoList.Push("CTPN");
                        }
                    }
                    this.CTPNTableAdapter.Update(DS.CTPN);
                    save = false;
                }   
            }

        
            if (bdsPHIEUNHAP.Count > 0) btnXoa.Enabled = true;
            btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

            cmbMaSoDDH.DropDownStyle = ComboBoxStyle.DropDown;
            panelControl1.Enabled = panelControl3.Enabled = phieuNhapGridControl.Enabled = cTPNGridControl.Enabled = true;

            in4CTPNPanel_Reset();
            if (bdsCTPN.Count > 0) btnXoa.Enabled = true;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;

            barDockControlTop.Enabled = panelControl2.Enabled = phieuNhapGridControl.Enabled = cTPNGridControl.Enabled = true;
            return;
                
        }

        private void tsmiGhi_Click(object sender, EventArgs e)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC SP_LAY_SO_LUONG_VAT_TU_DA_DAT '" +cmbMaSoDDH.Text.Trim() + "','"+txtMaVT.Text.Trim()+"'");
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int soLuong = Program.myReader.GetInt32(0);
            Program.myReader.Close();
            if(soLuong==0)
            {
                MessageBox.Show("Đơn hàng đã đặt không có vật tư này!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTenVT.Focus();
                return;

            }
            if(soLuong < (int)setSoLuong.Value)
            {
                MessageBox.Show("Vật tư này chỉ được nhập tối đa "+ soLuong + " sp!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setSoLuong.Focus();
                return;
            }
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
            if (txtMaVT.Text.Trim() != gridVCTPN.GetFocusedDataRow()[1].ToString().Trim())
            {
                int check_MAVT_MAPN = Program.alreadyExist_check("MAVT_MAPN", "'" + txtMaVT.Text.Trim() + "','" + txtMaPN.Text.Trim() + "'");
                if (check_MAVT_MAPN == -1) return;
                else if(check_MAVT_MAPN == 1)
                {
                    MessageBox.Show("Phiếu nhập đã có vật tư này rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        updated_Values = gridVCTPN.GetFocusedDataRow().ItemArray;
                    }

                    DataRow dtr = gridVCTPN.GetFocusedDataRow();
                    dtr[1] = txtMaVT.Text.Trim();
                    dtr[2] = (int)setSoLuong.Value;
                    dtr[3] = (int)setDonGia.Value;


                    bdsCTPN.ResetCurrentItem();
                    this.CTPNTableAdapter.Update(this.DS.CTPN);

                    int index = DS.CTPN.Rows.IndexOf(dtr);
                    if (barDockControlTop.Enabled == true)
                    {
                        undoList.Push(bdsCTPN.Position);
                        undoList.Push(updated_Values);
                    }
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push(gridVPhieuNhap.GetFocusedDataRow());
                    undoList.Push("CTPN");
                    in4CTPNPanel_Reset();
                    
                    tsmiThem.Text = "Thêm";
                    barDockControlTop.Enabled = true;
                    phieuNhapGridControl.Enabled = true;
                    cTPNGridControl.Enabled = true;
                    panelControl2.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi phiếu nhập!\n\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    object[] inserted_Values = gridVCTPN.GetFocusedDataRow().ItemArray;
                    int index = DS.CTPN.Rows.IndexOf(gridVCTPN.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsCTPN.RemoveCurrent();

                    this.CTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.CTPNTableAdapter.Update(this.DS.CTPN);
                    undoList.Push(bdsCTPN.Position);
                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    undoList.Push(gridVPhieuNhap.GetFocusedDataRow());
                    undoList.Push("CTPN");
                    in4PhieuNhapPanel_Reset();

                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa CTPN. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
                    return;
                }
            }
            if (bdsCTPN.Count == 0) tsmiXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void gridPhieuNhap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4PhieuNhapPanel_Reset();
        }
       
        private void gridVCTPN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4CTPNPanel_Reset();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void cmbTenKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaKho.Text = cmbTenKho.SelectedValue.ToString();
            }
            catch (Exception){ }
        }
        private void cmbTenVT_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void setSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            if (setSoLuong.Value < 1) setSoLuong.Value = 1;
        }

        private void setSoLuong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }
    }
}