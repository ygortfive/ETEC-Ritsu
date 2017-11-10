using RITSU.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RITSU
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoginEmail le = new LoginEmail();            
            le.ShowDialog();
            //GetSetLogin gsl = new GetSetLogin();
                Application.Run(new Ritsu());           
        }
    }
}
