
namespace QLVT_DATHANG
{
    partial class frm_Bang_Ke_Chi_Tiet_Nhap_Xuat
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLoaiPhieu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.detFrom = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.detTo = new DevExpress.XtraEditors.DateEdit();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Loại Phiếu";
            // 
            // cmbLoaiPhieu
            // 
            this.cmbLoaiPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiPhieu.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiPhieu.FormattingEnabled = true;
            this.cmbLoaiPhieu.Items.AddRange(new object[] {
            "Nhập",
            "Xuất"});
            this.cmbLoaiPhieu.Location = new System.Drawing.Point(295, 117);
            this.cmbLoaiPhieu.Name = "cmbLoaiPhieu";
            this.cmbLoaiPhieu.Size = new System.Drawing.Size(230, 37);
            this.cmbLoaiPhieu.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày";
            // 
            // detFrom
            // 
            this.detFrom.EditValue = new System.DateTime(2010, 1, 1, 22, 22, 15, 0);
            this.detFrom.Location = new System.Drawing.Point(295, 185);
            this.detFrom.Margin = new System.Windows.Forms.Padding(4);
            this.detFrom.Name = "detFrom";
            this.detFrom.Properties.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detFrom.Properties.Appearance.Options.UseFont = true;
            this.detFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.detFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.detFrom.Size = new System.Drawing.Size(230, 38);
            this.detFrom.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(588, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đến Ngày";
            // 
            // detTo
            // 
            this.detTo.EditValue = new System.DateTime(2022, 5, 13, 22, 22, 50, 839);
            this.detTo.Location = new System.Drawing.Point(726, 185);
            this.detTo.Margin = new System.Windows.Forms.Padding(4);
            this.detTo.Name = "detTo";
            this.detTo.Properties.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detTo.Properties.Appearance.Options.UseFont = true;
            this.detTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detTo.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.detTo.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.detTo.Size = new System.Drawing.Size(221, 38);
            this.detTo.TabIndex = 18;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(334, 281);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(191, 42);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Text = "Xem Trước";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(372, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 38);
            this.label5.TabIndex = 20;
            this.label5.Text = "THÔNG TIN BẢNG KÊ";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Location = new System.Drawing.Point(593, 281);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(212, 42);
            this.btnXuat.TabIndex = 21;
            this.btnXuat.Text = "Xuất PDF";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // frm_Bang_Ke_Chi_Tiet_Nhap_Xuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 402);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.detTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.detFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLoaiPhieu);
            this.Controls.Add(this.label2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_Bang_Ke_Chi_Tiet_Nhap_Xuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Bang_Ke_Chi_Tiet_Nhap_Xuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detTo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLoaiPhieu;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit detFrom;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit detTo;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXuat;
    }
}