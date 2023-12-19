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
    public partial class QUANTRIVIEN : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public QUANTRIVIEN()
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

        DataSet LoadData_NhaSi()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from NHASI where MaNhaSi < 200";
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

        DataSet LoadData_Thuoc()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from THUOC";
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

        DataSet LoadData_NhanVien()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from NHANVIEN where MaNhanVien < 200";
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

        DataSet LoadData_DieuTri()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from DIEUTRI";
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


        private void QUANTRIVIEN_Load(object sender, EventArgs e)
        {
            dgv_DSNhaSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_DSNhaSi.DataSource = LoadData_NhaSi().Tables[0];
            dgv_DSThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSThuoc.DataSource = LoadData_Thuoc().Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = LoadData_NhanVien().Tables[0];
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = LoadData_DieuTri().Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv_DSThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSThuoc.DataSource = LoadData_Thuoc().Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapNhatSLTK cnSltk = new CapNhatSLTK();
            cnSltk.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThemThuoc tt = new ThemThuoc();
            tt.ShowDialog();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            h.ShowDialog();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            DataSet data = new DataSet();
            if (tbxTenThuoc.Text == "" && tbxMaThuoc.Text == "") {
                MessageBox.Show("Cần nhập thông tin đề tìm kiếm!");
                return;
            }
            if (tbxTenThuoc.Text == "" && tbxMaThuoc.Text != "")
            {
                query = $"select* from THUOC where MaThuoc = {int.Parse(tbxMaThuoc.Text)}";
            }
            if (tbxTenThuoc.Text != "" && tbxMaThuoc.Text == "")
            {
                query = $"select* from THUOC where TenThuoc LIKE N'{tbxTenThuoc.Text}'";
            }
            if (tbxTenThuoc.Text != "" && tbxMaThuoc.Text != "")
            {
                query = $"select* from THUOC where TenThuoc = N'{tbxTenThuoc.Text}' and MaThuoc = {int.Parse(tbxMaThuoc.Text)}";
            }
            //MessageBox.Show(query);
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                //connection.InfoMessage += Connection_InfoMessage;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            dgv_DSThuoc.AutoGenerateColumns = true;
            dgv_DSThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSThuoc.DataSource = data.Tables[0];
            dgv_DSThuoc.Refresh();
        }
    }
}
