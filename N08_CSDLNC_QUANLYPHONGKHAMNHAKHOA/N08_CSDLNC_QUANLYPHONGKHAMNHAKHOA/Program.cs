using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< Updated upstream
            Application.Run(new QUANTRIVIEN());
=======
            Application.Run(new TOATHUOC("1"));

            //Application.Run(new NHASI("0752717429"));
>>>>>>> Stashed changes
        }
    }
}
