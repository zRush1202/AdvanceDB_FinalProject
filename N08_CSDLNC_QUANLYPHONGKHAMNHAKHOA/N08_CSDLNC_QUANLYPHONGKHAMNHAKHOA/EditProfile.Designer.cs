namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class EditProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_title = new System.Windows.Forms.Label();
            this.lb_HoTen = new System.Windows.Forms.Label();
            this.tb_HoTen = new System.Windows.Forms.TextBox();
            this.lb_NgSinh = new System.Windows.Forms.Label();
            this.tb_DienThoai = new System.Windows.Forms.TextBox();
            this.lb_DienThoai = new System.Windows.Forms.Label();
            this.tb_DiaChi = new System.Windows.Forms.TextBox();
            this.lb_DiaChi = new System.Windows.Forms.Label();
            this.dateTimeBirth = new System.Windows.Forms.DateTimePicker();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.btn_QuayLai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title.Location = new System.Drawing.Point(108, 33);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(199, 25);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "Chỉnh sửa thông tin";
            // 
            // lb_HoTen
            // 
            this.lb_HoTen.AutoSize = true;
            this.lb_HoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_HoTen.Location = new System.Drawing.Point(62, 102);
            this.lb_HoTen.Name = "lb_HoTen";
            this.lb_HoTen.Size = new System.Drawing.Size(55, 16);
            this.lb_HoTen.TabIndex = 1;
            this.lb_HoTen.Text = "Họ Tên:";
            // 
            // tb_HoTen
            // 
            this.tb_HoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_HoTen.Location = new System.Drawing.Point(157, 99);
            this.tb_HoTen.Name = "tb_HoTen";
            this.tb_HoTen.Size = new System.Drawing.Size(200, 22);
            this.tb_HoTen.TabIndex = 2;
            this.tb_HoTen.TextChanged += new System.EventHandler(this.tb_HoTen_TextChanged);
            // 
            // lb_NgSinh
            // 
            this.lb_NgSinh.AutoSize = true;
            this.lb_NgSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgSinh.Location = new System.Drawing.Point(62, 147);
            this.lb_NgSinh.Name = "lb_NgSinh";
            this.lb_NgSinh.Size = new System.Drawing.Size(72, 16);
            this.lb_NgSinh.TabIndex = 3;
            this.lb_NgSinh.Text = "Ngày Sinh:";
            // 
            // tb_DienThoai
            // 
            this.tb_DienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DienThoai.Location = new System.Drawing.Point(157, 188);
            this.tb_DienThoai.Name = "tb_DienThoai";
            this.tb_DienThoai.Size = new System.Drawing.Size(200, 22);
            this.tb_DienThoai.TabIndex = 6;
            this.tb_DienThoai.TextChanged += new System.EventHandler(this.tb_DienThoai_TextChanged);
            // 
            // lb_DienThoai
            // 
            this.lb_DienThoai.AutoSize = true;
            this.lb_DienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DienThoai.Location = new System.Drawing.Point(62, 191);
            this.lb_DienThoai.Name = "lb_DienThoai";
            this.lb_DienThoai.Size = new System.Drawing.Size(75, 16);
            this.lb_DienThoai.TabIndex = 5;
            this.lb_DienThoai.Text = "Điện Thoại:";
            // 
            // tb_DiaChi
            // 
            this.tb_DiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DiaChi.Location = new System.Drawing.Point(157, 233);
            this.tb_DiaChi.Name = "tb_DiaChi";
            this.tb_DiaChi.Size = new System.Drawing.Size(200, 22);
            this.tb_DiaChi.TabIndex = 8;
            this.tb_DiaChi.TextChanged += new System.EventHandler(this.tb_DiaChi_TextChanged);
            // 
            // lb_DiaChi
            // 
            this.lb_DiaChi.AutoSize = true;
            this.lb_DiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DiaChi.Location = new System.Drawing.Point(62, 236);
            this.lb_DiaChi.Name = "lb_DiaChi";
            this.lb_DiaChi.Size = new System.Drawing.Size(52, 16);
            this.lb_DiaChi.TabIndex = 7;
            this.lb_DiaChi.Text = "Địa Chỉ:";
            // 
            // dateTimeBirth
            // 
            this.dateTimeBirth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeBirth.Location = new System.Drawing.Point(157, 147);
            this.dateTimeBirth.Name = "dateTimeBirth";
            this.dateTimeBirth.Size = new System.Drawing.Size(200, 20);
            this.dateTimeBirth.TabIndex = 9;
            this.dateTimeBirth.ValueChanged += new System.EventHandler(this.dateTimeBirth_ValueChanged);
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhat.Location = new System.Drawing.Point(210, 286);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(87, 28);
            this.btn_CapNhat.TabIndex = 10;
            this.btn_CapNhat.Text = "Cập Nhật";
            this.btn_CapNhat.UseVisualStyleBackColor = true;
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // btn_QuayLai
            // 
            this.btn_QuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuayLai.Location = new System.Drawing.Point(103, 286);
            this.btn_QuayLai.Name = "btn_QuayLai";
            this.btn_QuayLai.Size = new System.Drawing.Size(87, 28);
            this.btn_QuayLai.TabIndex = 11;
            this.btn_QuayLai.Text = "Quay Lại";
            this.btn_QuayLai.UseVisualStyleBackColor = true;
            this.btn_QuayLai.Click += new System.EventHandler(this.btn_QuayLai_Click);
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 378);
            this.Controls.Add(this.btn_QuayLai);
            this.Controls.Add(this.btn_CapNhat);
            this.Controls.Add(this.dateTimeBirth);
            this.Controls.Add(this.tb_DiaChi);
            this.Controls.Add(this.lb_DiaChi);
            this.Controls.Add(this.tb_DienThoai);
            this.Controls.Add(this.lb_DienThoai);
            this.Controls.Add(this.lb_NgSinh);
            this.Controls.Add(this.tb_HoTen);
            this.Controls.Add(this.lb_HoTen);
            this.Controls.Add(this.lb_title);
            this.Name = "EditProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditProfile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label lb_HoTen;
        private System.Windows.Forms.TextBox tb_HoTen;
        private System.Windows.Forms.Label lb_NgSinh;
        private System.Windows.Forms.TextBox tb_DienThoai;
        private System.Windows.Forms.Label lb_DienThoai;
        private System.Windows.Forms.TextBox tb_DiaChi;
        private System.Windows.Forms.Label lb_DiaChi;
        private System.Windows.Forms.DateTimePicker dateTimeBirth;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_QuayLai;
    }
}