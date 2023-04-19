using DevExpress.XtraEditors;
using System;
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
    public partial class frmVatTuChuaCoOPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        int[] ars;
        public frmVatTuChuaCoOPhieuNhap()
        {
            InitializeComponent();
        }   

        private void frm1_Load(object sender, EventArgs e)
        {
         
        }

        private void cTDDHGridControl_Click(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < dtgridV.Rows.Count; i++) dtgridV.Rows[i].Cells[0].Value = true;
            } 
            else
            {
                for (int i = 0; i < dtgridV.Rows.Count; i++) dtgridV.Rows[i].Cells[0].Value = false;
            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

            for (int i = dtgridV.Rows.Count-1; i >= 0 ; i--)
            {
                if (dtgridV.Rows[i].Cells[0].Value == null) dtgridV.Rows.RemoveAt(i);
                else if ((Boolean)dtgridV.Rows[i].Cells[0].Value == false)
                {
                    dtgridV.Rows.RemoveAt(i);
                }
            }
            dtgridV.DataSource = null;
            frmPhieuNhap.save = true;
            Close();
        }

        private void dtgridV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       private void dtgridV_CellEnter(object sender, DataGridViewCellEventArgs e)
       {
         
       }

        private void dtgridV_CurrentCellChanged(object sender, EventArgs e)
        {
           // row = dtgridV.CurrentCell.RowIndex;
          //  col = dtgridV.CurrentCell.ColumnIndex;
        }

        private void dtgridV_DataSourceChanged(object sender, EventArgs e)
        {
            ars = new int[dtgridV.Rows.Count];
            for (int i = 0; i < dtgridV.Rows.Count; i++) 
            {
                ars[i] = int.Parse(dtgridV.Rows[i].Cells[2].Value.ToString());
            }
        }
        
        private void dtgridV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Lỗi dữ liệu ô vừa nhập!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dtgridV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = dtgridV.CurrentCell.RowIndex;
            int col = dtgridV.CurrentCell.ColumnIndex;
            if (col == 3)
            {

                if (int.Parse(dtgridV.Rows[row].Cells[col].Value.ToString()) > ars[row])
                {
                    dtgridV.Rows[row].Cells[col].Value = ars[row];

                    MessageBox.Show("Số lượng không vượt quá " + ars[row], "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            else if (col == 4)
            {
                if (Regex.IsMatch(dtgridV.Rows[row].Cells[col].Value.ToString().Trim(), @"^[0-9]+$") == false)
                {
                    dtgridV.Rows[row].Cells[col].Value = ars[row];

                    MessageBox.Show("Đơn giá chỉ chứa số", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                    return;
                }
                else if (int.Parse(dtgridV.Rows[row].Cells[col].Value.ToString()) > 999999999)
                {
                    dtgridV.Rows[row].Cells[col].Value = ars[row];

                    MessageBox.Show("Đơn giá không vượt quá " + 999999999, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                    return;
                }
            }
        }

        private void dtgridV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}