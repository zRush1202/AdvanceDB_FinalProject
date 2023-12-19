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
    public partial class NHANVIEN : Form
    {
        private string username;

        public NHANVIEN()
        {
            InitializeComponent();
        }

        public NHANVIEN(string username)
        {
            this.username = username;
        }
    }
}
