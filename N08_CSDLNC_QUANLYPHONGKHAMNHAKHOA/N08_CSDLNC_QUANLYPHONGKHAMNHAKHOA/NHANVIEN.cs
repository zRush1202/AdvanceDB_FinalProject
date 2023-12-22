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
        private int MaNVQL;

        public NHANVIEN(string username, string password)
        {
            InitializeComponent();
            dtgv_CHYC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_CHYC.DataSource = LoadData_CHYC_BENHNHAN().Tables[0];
            dtgv_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_BenhNhan.DataSource = Load_HoSoBenhNhan("*").Tables[0];
            dtgv_DanhSachBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_DanhSachBenhNhan.DataSource = Load_DSBenhNhan("*").Tables[0];
            this.username = username;
            this.password = password;

            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                string query = $"select HoTenNV, NgSinhNV, DiaChiNV, DienThoaiNV from TAIKHOAN, NHANVIEN WHERE DienThoaiNV='{username}'";
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
                                //DateTime ngSinhNV = Convert.ToDateTime(reader["NgSinhNV"]);
                                string ngSinhNV = reader["NgSinhNV"].ToString();

                                string diaChiNV = reader["DiaChiNV"].ToString();
                                string dienThoaiNV = reader["DienThoaiNV"].ToString();

                                // Sử dụng dữ liệu như mong muốn (ví dụ: hiển thị lên các controls trên form)
                                int viTriKhoangTrang = ngSinhNV.IndexOf(' ');

                                textBox3.Text = hoTenNV;
                                textBox4.Text = ngSinhNV.Substring(0, viTriKhoangTrang);
                                textBox5.Text = diaChiNV;
                                textBox6.Text = dienThoaiNV;
                            }
                        }
                    }
                }

                string query_TimMaNVQL = $"select MaNhanVien from NHANVIEN where DienThoaiNV = '{username}'";
                using (SqlCommand command = new SqlCommand(query_TimMaNVQL, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu không
                        if (reader.HasRows)
                        {
                            // Đọc dữ liệu từ SqlDataReader
                            while (reader.Read())
                            {
                                this.MaNVQL = int.Parse(reader["MaNhanVien"].ToString());
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

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Xử lý thông điệp được in ra từ SQL Server (bằng PRINT)
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message); // Hiển thị thông điệp trong MessageBox
            }
        }


        private void btn_XoaYC_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            if(textBox2.Text != "")
            {
                int machyc = int.Parse(textBox2.Text);
                    string query = $"exec sp_XoaCHYC {machyc}";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void btn_DuyetYC_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            if (textBox2.Text != "")
            {
                int machyc = int.Parse(textBox2.Text);
                string query = $"exec sp_DuyetCHYC {machyc}, {this.MaNVQL}";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
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

        private void btn_RefreshQLHSBN_Click(object sender, EventArgs e)
        {
            dtgv_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_BenhNhan.DataSource = Load_HoSoBenhNhan("*").Tables[0];
        }

        private void btn_TimKiemQLHSBN_Click(object sender, EventArgs e)
        {
            if(tb_SDT_QLHSBN.Text != "")
            {
                dtgv_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgv_BenhNhan.DataSource = Load_HoSoBenhNhan(tb_SDT_QLHSBN.Text).Tables[0];
            }    
        }

        DataSet Load_HoSoBenhNhan(string type)
        {
            int numConn = testConnect();
            DataSet data = new DataSet();
            if (type == "*")
            {
                string query = "select top 100 * from HOSOBENHNHAN";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }   
            else
            {
                string query = $"select bn.HoTenBN, hs.* from HOSOBENHNHAN hs, BENHNHAN bn WHERE bn.MaBenhNhan = hs.MaBenhNhan and bn.DienThoaiBN = N'{type}'";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            return data;
        }

        private void btn_Refresh_DSBN_Click(object sender, EventArgs e)
        {
            dtgv_DanhSachBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_DanhSachBenhNhan.DataSource = Load_DSBenhNhan("*").Tables[0];
        }

        private void btn_TimKiem_DSBN_Click(object sender, EventArgs e)
        {
            if (tb_SDT_QLBN.Text != "")
            {
                dtgv_DanhSachBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgv_DanhSachBenhNhan.DataSource = Load_DSBenhNhan(tb_SDT_QLBN.Text).Tables[0];
            }
        }

        DataSet Load_DSBenhNhan(string type)
        {
            int numConn = testConnect();
            DataSet data = new DataSet();
            if (type == "*")
            {
                string query = "select top 200 * from BENHNHAN";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            else
            {
                string query = $"select * from BENHNHAN WHERE DienThoaiBN = N'{type}'";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            return data;
        }



        /// KIÊN: THANH TOÁN

        private void txt_SDT_BN_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null)
            {
                var text = textBox.Text;
                bool isPhoneNumber = System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d+$");
                if (!isPhoneNumber)
                {
                    timKiem_KHDT.Enabled = false;
                }
                else
                {
                    timKiem_KHDT.Enabled = true;
                }
            }
        }


        DataSet LoadData_KHDT_BENHNHAN(string phone)
        {
            int numConn = testConnect();
            DataSet data = new DataSet();

            //sql connection
            string query = $"select khdt.mabenhan, khdt.marangkham, tt.*" +
                $"from thanhtoan tt, kehoachdieutri khdt, hosobenhnhan hsbn, benhnhan bn " +
                $"where bn.dienthoaibn = '{phone}' and bn.mabenhnhan = hsbn.mabenhnhan and hsbn.mabenhan = khdt.mabenhan and khdt.mathanhtoan = tt.mathanhtoan";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            //sql dataAdapter
            return data;
        }

        private string phoneNumber;
        private void timKiem_KHDT_Click(object sender, EventArgs e)
        {
            phoneNumber = txt_SDT_BN.Text;
            ThanhToan_KHDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ThanhToan_KHDT.DataSource = LoadData_KHDT_BENHNHAN(phoneNumber).Tables[0];
        }
        private int mathanhtoan;
        private void ThanhToan_KHDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < this.ThanhToan_KHDT.Rows.Count) // Make sure user select at least 1 row 
            {
                DataGridViewRow row = this.ThanhToan_KHDT.Rows[e.RowIndex];
                if (row.Cells["NgayGiaoDich"].Value is DBNull)
                {
                    date_NgayGiaoDich.Value = DateTime.Today;
                }
                else
                {
                    date_NgayGiaoDich.Value = (DateTime)row.Cells["NgayGiaoDich"].Value;
                }
                mathanhtoan = (int)row.Cells["MaThanhToan"].Value;
                txt_TienCanTT.Text = row.Cells["TienCanThanhToan"].Value.ToString(); // Replace "ColumnName" with the column name you want to access
                txt_tienThoi.Text = row.Cells["TienThoi"].Value.ToString();
            }
        }

        private void buton_XuatHD_Click(object sender, EventArgs e)
        {

            string date = date_NgayGiaoDich.Value.ToString("yyyy-MM-dd");
            string tienDaTra = txt_TienDaTra.Text;
            string tienThoi = txt_tienThoi.Text;
            string loaiThanhToan = null;

            if (radio_credit.Checked)
            {
                loaiThanhToan = "credit";
            }
            else if (radio_cas.Checked)
            {
                loaiThanhToan = "cash";
            }
            string query = $"update thanhtoan set ngaygiaodich = '{date}', tiendatra = '{tienDaTra}', tienthoi = '{tienThoi}', loaithanhtoan = '{loaiThanhToan}' where mathanhtoan = '{mathanhtoan}'";
            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            ThanhToan_KHDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ThanhToan_KHDT.DataSource = LoadData_KHDT_BENHNHAN(phoneNumber).Tables[0];
        }

        
    }


}
