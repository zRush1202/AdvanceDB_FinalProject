namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class HOME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOME));
            this.panel_cyan = new System.Windows.Forms.Panel();
            this.btn_DatLichHen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_phongkham = new System.Windows.Forms.Label();
            this.panel_home = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_cyan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_cyan
            // 
            this.panel_cyan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_cyan.Controls.Add(this.btn_DatLichHen);
            this.panel_cyan.Controls.Add(this.label1);
            this.panel_cyan.Controls.Add(this.lb_phongkham);
            this.panel_cyan.Controls.Add(this.pictureBox1);
            this.panel_cyan.Location = new System.Drawing.Point(4, 4);
            this.panel_cyan.Name = "panel_cyan";
            this.panel_cyan.Size = new System.Drawing.Size(814, 106);
            this.panel_cyan.TabIndex = 0;
            // 
            // btn_DatLichHen
            // 
            this.btn_DatLichHen.BackColor = System.Drawing.Color.Red;
            this.btn_DatLichHen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DatLichHen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DatLichHen.Location = new System.Drawing.Point(664, 26);
            this.btn_DatLichHen.Name = "btn_DatLichHen";
            this.btn_DatLichHen.Size = new System.Drawing.Size(129, 49);
            this.btn_DatLichHen.TabIndex = 1;
            this.btn_DatLichHen.Text = "ĐẶT HẸN";
            this.btn_DatLichHen.UseVisualStyleBackColor = false;
            this.btn_DatLichHen.Click += new System.EventHandler(this.btn_DatLichHen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nụ cười của bạn, trách nhiệm của chúng tôi";
            // 
            // lb_phongkham
            // 
            this.lb_phongkham.AutoSize = true;
            this.lb_phongkham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_phongkham.ForeColor = System.Drawing.Color.Red;
            this.lb_phongkham.Location = new System.Drawing.Point(110, 26);
            this.lb_phongkham.Name = "lb_phongkham";
            this.lb_phongkham.Size = new System.Drawing.Size(254, 20);
            this.lb_phongkham.TabIndex = 1;
            this.lb_phongkham.Text = "PHÒNG KHÁM RĂNG RỤT RÈ";
            // 
            // panel_home
            // 
            this.panel_home.BackColor = System.Drawing.Color.White;
            this.panel_home.Location = new System.Drawing.Point(99, 109);
            this.panel_home.Name = "panel_home";
            this.panel_home.Size = new System.Drawing.Size(628, 400);
            this.panel_home.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA.Properties.Resources.teeth_ava;
            this.pictureBox1.Location = new System.Drawing.Point(8, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 511);
            this.Controls.Add(this.panel_home);
            this.Controls.Add(this.panel_cyan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HOME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOME";
            this.panel_cyan.ResumeLayout(false);
            this.panel_cyan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_cyan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_DatLichHen;
        private System.Windows.Forms.Label lb_phongkham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_home;
    }
}