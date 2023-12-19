using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class DATLICHHEN : Form
    {
        public DATLICHHEN()
        {
            InitializeComponent();
        }

        // Biến kiểm tra nhập text box
        private bool allTBFilled = false;

        // Xử lý sự kiện nhập của từng text box
        private void tb_hoten_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_dienthoai_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_diachi_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_email_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_tinhtrang_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private bool radiocheck = false;

        private void rb_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_nam.Checked && !this.rb_nu.Checked)
            {
                radiocheck = true;
                ValidateFields();
            }
        }

        private void rb_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_nu.Checked && !this.rb_nam.Checked)
            {
                radiocheck = true;
                ValidateFields();
            }
        }

        private bool datepickercheck = false;

        private void dp_birth_ValueChanged(object sender, EventArgs e)
        {
            if (this.dp_birth.Value < DateTime.Today && this.dp_appointment.Value.Date > DateTime.Today.Date)
            {
                datepickercheck = true;
                ValidateFields();
            }
            else
            {
                datepickercheck = false;
                ValidateFields();
            }
        }

        private void dp_appointment_ValueChanged(object sender, EventArgs e)
        {
            if (this.dp_birth.Value < DateTime.Today && this.dp_appointment.Value.Date > DateTime.Today.Date)
            {
                datepickercheck = true;
                ValidateFields();
            }
            else
            {
                datepickercheck = false;
                ValidateFields();
            }
        }
      
        private void ValidateFields()
        {
            if (!String.IsNullOrEmpty(tb_hoten.Text) &&
                !String.IsNullOrEmpty(tb_dienthoai.Text) &&
                !String.IsNullOrEmpty(tb_diachi.Text) &&
                !String.IsNullOrEmpty(tb_email.Text) &&
                !String.IsNullOrEmpty(tb_tinhtrang.Text))
            {
                allTBFilled = true;
            }
            else
            {
                allTBFilled = false;
            }


            if (allTBFilled && radiocheck && datepickercheck)
            {
                this.b_datlich.Enabled = allTBFilled;
                this.b_datlich.BackColor = System.Drawing.Color.Red;
                this.b_datlich.Cursor = System.Windows.Forms.Cursors.Default;
                this.b_datlich.Enabled = true;
            }
            else
            {
                this.b_datlich.Enabled = allTBFilled;
                this.b_datlich.BackColor = System.Drawing.SystemColors.AppWorkspace;
                this.b_datlich.Cursor = System.Windows.Forms.Cursors.No;
                this.b_datlich.Enabled = false;
            }

        }


        private void b_datlich_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ĐẶT LỊCH HẸN THÀNH CÔNG");
            this.Hide();
            HOME h = new HOME();
            h.ShowDialog();
            this.Close();
        }

        private void b_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME h = new HOME();
            h.ShowDialog();
            this.Close();
        }

    }
}
