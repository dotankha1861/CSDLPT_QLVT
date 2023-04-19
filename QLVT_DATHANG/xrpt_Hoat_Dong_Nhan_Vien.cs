using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DATHANG
{
    public partial class xrpt_Hoat_Dong_Nhan_Vien : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_Hoat_Dong_Nhan_Vien(int MaNV, DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = MaNV;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = dateFrom;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dateTo;
            this.sqlDataSource1.Fill();
        }

    }
}
