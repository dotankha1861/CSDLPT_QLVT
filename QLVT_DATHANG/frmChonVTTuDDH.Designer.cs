
namespace QLVT_DATHANG
{
    partial class frmVatTuChuaCoOPhieuNhap
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtgridV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridV)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(1026, 82);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(83, 33);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = " All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(526, 439);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(109, 51);
            this.btnSAVE.TabIndex = 20;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(399, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(377, 37);
            this.label6.TabIndex = 19;
            this.label6.Text = "THÊM VẬT TƯ VÀO PHIẾU";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dtgridV
            // 
            this.dtgridV.AllowUserToAddRows = false;
            this.dtgridV.AllowUserToDeleteRows = false;
            this.dtgridV.AllowUserToResizeRows = false;
            this.dtgridV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgridV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridV.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dtgridV.Location = new System.Drawing.Point(0, 118);
            this.dtgridV.MultiSelect = false;
            this.dtgridV.Name = "dtgridV";
            this.dtgridV.RowHeadersWidth = 62;
            this.dtgridV.RowTemplate.Height = 28;
            this.dtgridV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgridV.Size = new System.Drawing.Size(1124, 287);
            this.dtgridV.TabIndex = 22;
            this.dtgridV.DataSourceChanged += new System.EventHandler(this.dtgridV_DataSourceChanged);
            this.dtgridV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridV_CellClick);
            this.dtgridV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridV_CellEndEdit);
            this.dtgridV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridV_CellEnter);
            this.dtgridV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridV_CellLeave);
            this.dtgridV.CurrentCellChanged += new System.EventHandler(this.dtgridV_CurrentCellChanged);
            this.dtgridV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgridV_DataError);
            // 
            // frmVatTuChuaCoOPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 518);
            this.Controls.Add(this.dtgridV);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmVatTuChuaCoOPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dtgridV;
    }
}