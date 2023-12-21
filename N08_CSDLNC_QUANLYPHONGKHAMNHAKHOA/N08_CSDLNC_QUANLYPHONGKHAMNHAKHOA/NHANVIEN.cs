using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class NHANVIEN : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        private string username;
        private string password;

        public NHANVIEN(string username, string password)
        {
            InitializeComponent();
            dtgv_CHYC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_CHYC.DataSource = LoadData_CHYC_BENHNHAN().Tables[0];
            this.username = username;
            this.password = password;

            int nConn = GetNumConn();
            string query = $"select HoTenNV, NgSinhNV, DiaChiNV, DienThoaiNV from TAIKHOAN, NHANVIEN WHERE DienThoaiNV='{username}'";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu không
                        if (reader.HasRows)
                        {
                            // Đọc dữ liệu từ SqlDataReader
                            while (reader.Read())
                            {
                                string hoTenNV = reader["HoTenNV"].ToString();
                                DateTime ngSinhNV = Convert.ToDateTime(reader["NgSinhNV"]);
                                string diaChiNV = reader["DiaChiNV"].ToString();
                                string dienThoaiNV = reader["DienThoaiNV"].ToString();

                                // Sử dụng dữ liệu như mong muốn (ví dụ: hiển thị lên các controls trên form)
                                textBox3.Text = hoTenNV;
                                textBox4.Text = ngSinhNV.ToShortDateString();
                                textBox5.Text = diaChiNV;
                                textBox6.Text = dienThoaiNV;
                            }
                        }
                    }
                }
                connection.Close();

            }

        }

        public NHANVIEN()
        {

            InitializeComponent();

        }



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
            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                string query = $"exec sp_XoaCHYC {int.Parse(textBox2.Text)}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TaoLichHenBenhNhan taoLichHenBenhNhan = new TaoLichHenBenhNhan();
            taoLichHenBenhNhan.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.username, this.password);
            changePassword.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HOME hOME = new HOME();
            this.Hide();
            hOME.ShowDialog();
            this.Close();
        }
    }


}
