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
            //ChooseForm choose = new ChooseForm();
            //var result = choose.ShowDialog();

            //    显示Splash窗体
            Splash.Show();
            Application.Run(new CheckInForm());
            //if (result == DialogResult.Yes)
            //{
            //    Application.Run(new CheckInForm());
            //}
            //if (result == DialogResult.No)
            //{
            //    Application.Run(new DrawLotteryForm());
            //}
            Splash.Close();
        }
    }
}
