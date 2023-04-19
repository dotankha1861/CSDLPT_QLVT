using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DATHANG
{
    public partial class xrpt_Bang_Ke_Chi_Tiet_Nhap_Xuat : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_Bang_Ke_Chi_Tiet_Nhap_Xuat(string role, string type, DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = role;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = type;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = dateFrom;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = dateTo;
            this.sqlDataSource1.Fill();
        }
    }
}
