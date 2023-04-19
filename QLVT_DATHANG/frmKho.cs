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
   
    public partial class frmKho : DevExpress.XtraEditors.XtraForm
    {
        private int indexTHEM = 0;
        Stack undoList = new Stack();
        public frmKho()
        {
            InitializeComponent();
        }
     
        void in4Panel_Reset()
        {
            if (gridVKho.GetFocusedDataRow() == null)
            {
                txtMaCN.Text = "";
                txtTenKho.Text = "";
                txtDiaChi.Text = "";
                txtMaCN.Text = "";

                txtMaKho.Enabled = txtTenKho.Enabled = txtDiaChi.Enabled = txtMaCN.Enabled = false;
                btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = false;
            }
            else
            {
                DataRow dtr = gridVKho.GetFocusedDataRow();
                txtMaKho.Text = dtr[0].ToString();
                txtTenKho.Text = dtr[1].ToString();
                txtDiaChi.Text = dtr[2].ToString();
                txtMaCN.Text = dtr[3].ToString();

                if (Program.crtRole == "CONGTY") return;

                txtMaKho.Enabled = txtMaCN.Enabled = false;
                txtTenKho.Enabled = txtDiaChi.Enabled = true;
                btnXoa.Enabled = btnGhi.Enabled = true;
            }
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
         
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);
           
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
        
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
          
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr; 
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            cmbChiNhanh.DataSource = Program.bds_Subscribers;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.crtBrand;

            if (Program.crtRole == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = false;
                txtTenKho.Enabled = txtDiaChi.Enabled = false;
            }
            else cmbChiNhanh.Enabled = false;

            btnPhucHoi.Enabled = false;
            gridVKho.OptionsBehavior.Editable = false;
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

            if (Program.database_Connect() == false)  MessageBox.Show("Xảy ra lỗi kết nối với chi nhánh hiện tại!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khoTableAdapter.Fill(this.DS.Kho);

                in4Panel_Reset();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            indexTHEM = bdsKHO.Position;
            bdsKHO.AddNew();

            txtMaKho.Enabled = true;
            txtMaCN.Text = "CN" + (Program.crtBrand + 1); ;

            gcKho.Enabled = false;
            pcChiTiet.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKho.Text.Trim() == "")
            {
                MessageBox.Show("Mã kho không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Sửa lỗi lại ...
            if (Regex.IsMatch(txtMaKho.Text.Trim(), @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã kho chỉ chấp nhận chữ không dấu và số!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKho.Focus();
                return;
            }

            if (txtMaKho.Text.Length > 4)
            {
                MessageBox.Show("Mã kho không thể lớn hơn 4 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKho.Focus();
                return;
            }

            if (txtTenKho.Text.Trim() == "")
            {
                MessageBox.Show("Tên kho không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKho.Focus();
                return;
            }
                              
            if (Regex.IsMatch(txtTenKho.Text.Trim(), @"^[a-zA-Z0-9áàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Tên Kho chỉ chấp nhận chữ cái, số và khoảng trắng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKho.Focus();
                return;
            }

            if (txtTenKho.Text.Length > 30)
            {
                MessageBox.Show("Tên kho không thể quá 30 kí tự", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKho.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ kho không được thiếu!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (Regex.IsMatch(txtDiaChi.Text.Trim(), @"^[a-zA-Z0-9,áàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ ]+$") == false)
            {
                MessageBox.Show("Địa chỉ chỉ gồm chữ cái, số, dấu phẩy và khoảng trắng", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            if (txtDiaChi.Text.Length > 100)
            {
                MessageBox.Show("Địa chỉ không quá 100 kí tự!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if(txtMaKho.Text.Trim()!= gridVKho.GetFocusedDataRow()[0].ToString().Trim()) 
            {
                int check_MAKHO = Program.alreadyExist_check("MAKHO", "'" + txtMaKho.Text.Trim() + "'");
                if (check_MAKHO == -1) return;
                else if (check_MAKHO == 1)
                {
                    MessageBox.Show("Mã kho đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKho.Focus();
                    return;
                }
            }
            if (txtTenKho.Text.Trim() != gridVKho.GetFocusedDataRow()[1].ToString().Trim())
            { 
                int check_TENKHO = Program.alreadyExist_check("TENKHO", "N'"+ txtTenKho.Text.Trim() + "'");
                if (check_TENKHO == -1) return;
                else if(check_TENKHO == 1)
                {
                    MessageBox.Show("Tên kho đã tồn tại rồi!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKho.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "QUESTION",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string strlenh = "";
                    object[] updated_Values = null;
                    if (btnThem.Enabled == false) strlenh = "DELETE";
                    else
                    {
                        strlenh = "UPDATE";
                        updated_Values = gridVKho.GetFocusedDataRow().ItemArray;
                    }
                    DataRow dtr = gridVKho.GetFocusedDataRow();
                    dtr[0] = txtMaKho.Text.Trim();
                    dtr[1] = txtTenKho.Text.Trim();
                    dtr[2] = txtDiaChi.Text.Trim();
                    dtr[3] = txtMaCN.Text.Trim();
                    bdsKHO.ResetCurrentItem();
                    this.khoTableAdapter.Update(this.DS.Kho);
                    
                    int index = DS.Kho.Rows.IndexOf(dtr);
                                        
                    if (btnThem.Enabled == true) undoList.Push(updated_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);

                    in4Panel_Reset();

                    gcKho.Enabled = true;

                    MessageBox.Show("Ghi thành công", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi kho!\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (undoList.Count > 0) btnPhucHoi.Enabled = true;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsDATHANG.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho hàng này vì đã lập đơn đặt hàng!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bdsPHIEUNHAP.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho hàng này vì đã lập phiếu nhập!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bdsPHIEUXUAT.Count > 0)
            {
                MessageBox.Show("Không thể xóa kho hàng này vì đã lập phiếu xuất!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    object[] inserted_Values = gridVKho.GetFocusedDataRow().ItemArray;
                    int index = DS.Kho.Rows.IndexOf(gridVKho.GetFocusedDataRow());
                    string strlenh = "INSERT";

                    bdsKHO.RemoveCurrent();

                    this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khoTableAdapter.Update(this.DS.Kho);
                    
                    undoList.Push(inserted_Values);
                    undoList.Push(index);
                    undoList.Push(strlenh);
                    
                    in4Panel_Reset();
                    
                    MessageBox.Show("Xóa thành công! ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Hãy thử lại\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.khoTableAdapter.Fill(this.DS.Kho);
                    return;
                }
            }
            if (bdsKHO.Count == 0) btnXoa.Enabled = false;
            if (undoList.Count > 0) btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if(btnThem.Enabled == false)
            {
                bdsKHO.CancelEdit();
                bdsKHO.Position = indexTHEM;
                in4Panel_Reset();

                if (undoList.Count == 0) btnPhucHoi.Enabled = false;
                btnThem.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = true;

                gcKho.Enabled = true;
                return;
            }
            DataRow dtr_tmp = Program.undo_Execute(undoList, DS.Kho);
            if (dtr_tmp == null) gridVKho.MoveLastVisible(); 
            else bdsKHO.Position = DS.Kho.Rows.IndexOf(dtr_tmp);

            this.khoTableAdapter.Update(this.DS.Kho);
            in4Panel_Reset();
            if (undoList.Count == 0) btnPhucHoi.Enabled = false;
            if (bdsKHO.Count > 0) btnXoa.Enabled = true;
            else btnXoa.Enabled = false;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khoTableAdapter.Fill(this.DS.Kho);

                undoList.Clear();

                in4Panel_Reset();

                btnPhucHoi.Enabled = false;
                if (bdsPHIEUNHAP.Count == 0) btnXoa.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi Reload:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void gridVKho_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            in4Panel_Reset();
        }

        private void pcChiTiet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void gcKho_Click(object sender, EventArgs e)
        {

        }
    }
}