
namespace QLVT_DATHANG
{
    partial class frm_Tong_Hop_Nhap_Xuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.btnXemTruoc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.detTo = new DevExpress.XtraEditors.DateEdit();
            this.detFrom = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(214, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(677, 38);
            this.label6.TabIndex = 23;
            this.label6.Text = "THÔNG TIN CẦN XEM TỔNG HỢP NHẬP XUẤT";
            // 
            // btnXemTruoc
            // 
            this.btnXemTruoc.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTruoc.Location = new System.Drawing.Point(335, 284);
            this.btnXemTruoc.Name = "btnXemTruoc";
            this.btnXemTruoc.Size = new System.Drawing.Size(185, 48);
            this.btnXemTruoc.TabIndex = 22;
            this.btnXemTruoc.Text = "Xem trước";
            this.btnXemTruoc.UseVisualStyleBackColor = true;
            this.btnXemTruoc.Click += new System.EventHandler(this.btnXemTruoc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(660, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "Đến Ngày:";
            // 
            // detTo
            // 
            this.detTo.EditValue = new System.DateTime(2022, 5, 12, 23, 33, 49, 0);
            this.detTo.Location = new System.Drawing.Point(794, 189);
            this.detTo.Name = "detTo";
            this.detTo.Properties.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detTo.Properties.Appearance.Options.UseFont = true;
            this.detTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detTo.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.detTo.Properties.EditFormat.FormatString = "\"dd - MM - yyyy\"";
            this.detTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.detTo.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.detTo.Size = new System.Drawing.Size(195, 38);
            this.detTo.TabIndex = 20;
            // 
            // detFrom
            // 
            this.detFrom.EditValue = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.detFrom.Location = new System.Drawing.Point(256, 189);
            this.detFrom.Name = "detFrom";
            this.detFrom.Properties.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detFrom.Properties.Appearance.Options.UseFont = true;
            this.detFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.detFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.detFrom.Size = new System.Drawing.Size(206, 38);
            this.detFrom.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(122, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 29);
            this.label4.TabIndex = 18;
            this.label4.Text = "Từ Ngày:";
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanh.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(200, 102);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(261, 37);
            this.cmbChiNhanh.TabIndex = 13;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Chi Nhánh:";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Location = new System.Drawing.Point(566, 284);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(212, 48);
            this.btnXuat.TabIndex = 24;
            this.btnXuat.Text = "Xuất PDF";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // frm_Tong_Hop_Nhap_Xuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 373);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnXemTruoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.detTo);
            this.Controls.Add(this.detFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbChiNhanh);
            this.Controls.Add(this.label1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_Tong_Hop_Nhap_Xuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Tong_Hop_Nhap_Xuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXemTruoc;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit detTo;
        private DevExpress.XtraEditors.DateEdit detFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuat;
    }
}