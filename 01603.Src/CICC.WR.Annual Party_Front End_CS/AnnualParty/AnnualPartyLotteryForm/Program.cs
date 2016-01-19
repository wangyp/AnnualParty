using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CICC.WR.AnnualPartyControls;

namespace CICC.WR.AnnualParty
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

            Splash.Show();
            Application.Run(new DrawLotteryForm());
            Splash.Close();
        }
    }
}
