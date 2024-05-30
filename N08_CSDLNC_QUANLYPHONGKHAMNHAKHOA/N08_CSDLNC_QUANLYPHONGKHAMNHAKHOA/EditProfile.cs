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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class EditProfile : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        private int MaTaiKhoan;
        private string username;
        private string password;
        private string LoaiVT;
        
        public EditProfile()
        {
            InitializeComponent();
            //this.MaTaiKhoan = MaTK;
        }

        public EditProfile(int MaTK, string username, string password, string LoaiVT)
        {
            InitializeComponent();
            this.MaTaiKhoan = MaTK;
            this.username = username;
            this.password = password;
            this.LoaiVT = LoaiVT;
            LoadPerInfo();
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

        private void LoadPerInfo()
        {
            int nConn = GetNumConn();

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                string query = "";
                if(LoaiVT ==  "NV")
                    query = $"select HoTenNV, NgSinhNV, DiaChiNV, DienThoaiNV from NHANVIEN WHERE MaNhanVien={this.MaTaiKhoan}";
                else if (LoaiVT == "NS")
                    query = $"select HoTenNS, NgSinhNS, DiaChiNS, DienThoaiNS from NHASI WHERE MaNhaSi={this.MaTaiKhoan}";

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
                                tb_HoTen.Text = reader["HoTenNV"].ToString();
                                dateTimeBirth.Value = Convert.ToDateTime(reader["NgSinhNV"]);
                                tb_DienThoai.Text = reader["DienThoaiNV"].ToString();
                                tb_DiaChi.Text = reader["DiaChiNV"].ToString();
                            }
                        }
                    }
                }
                connection.Close();
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            NHANVIEN nHANVIEN = new NHANVIEN(this.username, this.password);
            this.Hide();
            nHANVIEN.ShowDialog();
            this.Close();
        }


        private bool isHoTenChanged = false;
        private void tb_HoTen_TextChanged(object sender, EventArgs e)
        {
            // Đánh dấu rằng Hoten đã thay đổi
            isHoTenChanged = true;
        }

        private bool isBirthChanged = false;
        private void dateTimeBirth_ValueChanged(object sender, EventArgs e)
        {
            isBirthChanged = true;
        }

        private bool isDienThoaiChanged = false;
        private void tb_DienThoai_TextChanged(object sender, EventArgs e)
        {
            isDienThoaiChanged = true;
        }

        private bool isDiaChiChanged = false;
        private void tb_DiaChi_TextChanged(object sender, EventArgs e)
        {
            isDiaChiChanged = true;
        }


        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                if (LoaiVT == "NV")
                {
                    if (isHoTenChanged)
                    {
                        string up_Name = $"update NHANVIEN set HoTenNV = N'{tb_HoTen.Text}' where MaNhanVien={this.MaTaiKhoan}";
                        using (SqlCommand command = new SqlCommand(up_Name, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    if (isBirthChanged)
                    {
                        string up_Birth = $"update NHANVIEN set NgSinhNV = '{dateTimeBirth.Value}' where MaNhanVien={this.MaTaiKhoan}";
                        using (SqlCommand command = new SqlCommand(up_Birth, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    if (isDienThoaiChanged)
                    {
                        this.username = tb_DienThoai.Text;
                        string up_Phone = $"update NHANVIEN set DienThoaiNV = '{tb_DienThoai.Text}' where MaNhanVien={this.MaTaiKhoan}";
                        using (SqlCommand command = new SqlCommand(up_Phone, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    if (isDiaChiChanged)
                    {
                        string up_Address = $"update NHANVIEN set DiaChiNV = N'{tb_DiaChi.Text}' where MaNhanVien={this.MaTaiKhoan}";
                        using (SqlCommand command = new SqlCommand(up_Address, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    NHANVIEN nHANVIEN = new NHANVIEN(this.username, this.password);
                    this.Hide();
                    nHANVIEN.ShowDialog();
                    this.Close();

                }
                else if (LoaiVT == "NS")
                {

                }    
            }
        }
    }
}
