﻿using System;
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
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void btn_DatLichHen_Click(object sender, EventArgs e)
        {
            DATLICHHEN dlh = new DATLICHHEN();
            this.Hide();
            dlh.ShowDialog();
            this.Close();
        }
    }
}