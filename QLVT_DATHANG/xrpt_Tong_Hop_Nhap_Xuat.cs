using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DATHANG
{
    public partial class xrpt_Tong_Hop_Nhap_Xuat : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_Tong_Hop_Nhap_Xuat(DateTime DateFrom, DateTime DateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = DateFrom;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = DateTo;
            this.sqlDataSource1.Fill();
        }

    }
}
