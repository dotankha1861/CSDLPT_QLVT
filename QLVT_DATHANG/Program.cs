using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    static class Program
    {
        //public static string TV = "áàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄóòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ";
        public static SqlDataReader myReader;
        public static SqlConnection conn = new SqlConnection();
        public static String database = "QLVT_DATHANG";
        public static String connstrPublisher = "Data Source=DTAHK;Initial Catalog=QLVT_DATHANG;Integrated Security=true";
        public static String connstr = "";
        
        public static String serverName = "";
         public static String serverNameLeft = "";
        public static String userName = "";
        
        public static String loginName = "";
        public static String loginPwd = "";

        public static String rmeLoginName = "HTKN";
        public static String rmeLoginPwd = "180601";

        public static String crtLoginName = "";
        public static String crtLoginPwd = "";
        public static String crtRole = "";
        public static String crtFullName = "";
        public static int crtBrand = 0;

        public static BindingSource bds_Subscribers = new BindingSource();
        public static frmMain frm_Main;

        public static bool database_Connect()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.serverName + ";Initial Catalog=" +
                                   Program.database + ";User ID=" +
                                   Program.loginName + ";password=" + Program.loginPwd;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!\nXem lại tài khoản và mật khẩu.\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static SqlDataReader ExecSqlDataReader(string statement)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(statement, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show("Lỗi thực thi!" + ex.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); 
                conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                 else
                MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State;

            }
        }
        

        // Kiểm tra trùng khóa chính
        public static int alreadyExist_check(string IDColName, string param)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC SP_KIEM_TRA_TRUNG_" + IDColName + " " + param);
            if (Program.myReader == null) return -1; // lỗi
            Program.myReader.Read();
            if (Program.myReader.GetInt32(0) == 1)
            {
                Program.myReader.Close();
                return 1; // trùng
            }
            Program.myReader.Close();
            return 0;
        }
        // Thực thi undo, trả về DataRow bị tác động hoặc null nếu delete
        public static DataRow undo_Execute(Stack undoList, DataTable dt)
        {
            string strlenh = (string) undoList.Pop();
            int index = (int)undoList.Pop();
            DataRow dr = null;
            if (strlenh == "INSERT")
            {
                dr = dt.NewRow();
                dr.ItemArray = (object[])(undoList.Pop());
                dt.Rows.InsertAt(dr, index);
            }
            else if (strlenh == "DELETE") dt.Rows[index].Delete(); 
            else // strlenh = UPDATE
            { 
                dr = dt.Rows[index];
                dr.ItemArray = (object[])(undoList.Pop());
            }
            return dr;
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm_Main = new frmMain();
            Application.Run(frm_Main);
        }
    }
}
