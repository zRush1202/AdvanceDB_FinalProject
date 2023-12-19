using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class NHANVIEN : Form
    {
        private string username;
        public NHANVIEN(string username)
        {
            InitializeComponent();
            dtgv_CHYC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_CHYC.DataSource = LoadData_CHYC_BENHNHAN().Tables[0];
            this.username = username;
        }

        public NHANVIEN()
        {
            

        }


        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        private int testConnect()
        {
            // Kiểm tra các kết nối và lấy vị trí của connectionString mà kết nối thành công
            int connectResult = conn.TestConnectionsAndGetIndex();
            return connectResult;
        }

        private int GetNumConn()
        {
            if (!isNumConnInitialized) // Nếu numConn chưa được khởi tạo
            {
                numConn = testConnect(); // Gọi hàm testConnect() để lấy giá trị numConn
                isNumConnInitialized = true; // Đánh dấu là numConn đã được khởi tạo
            }
            return numConn;
        }
        DataSet LoadData_CHYC_BENHNHAN()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select ch.MaCHYC, bn.HoTenBN, bn.NgSinhBN, bn.GioiTinhBN, bn.DienThoaiBN, bn.EmailBN, " +
                            "ch.ThoiGianYC, ch.TinhTrangBenh from CH_YEUCAU ch, BENHNHAN bn where ch.MaBenhNhan = bn.MaBenhNhan";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            //sql dataAdapter
            return data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtgv_CHYC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_CHYC.DataSource = LoadData_CHYC_BENHNHAN().Tables[0];
            
        }

        

        private void btn_XoaYC_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.username);
        }
    }


}
