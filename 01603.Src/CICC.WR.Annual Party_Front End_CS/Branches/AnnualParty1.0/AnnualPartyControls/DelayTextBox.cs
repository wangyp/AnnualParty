using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace CICC.WR.AnnualPartyControls
{
    public partial class DelayTextBox : TextBox
    {
        public DelayTextBox()
        {
            InitializeComponent();
            this.TextChanged += new EventHandler(DelayTextBox_TextChanged);
        }
        private DateTime startTime;
        void DelayTextBox_TextChanged(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            done = false;
            Thread thread = new Thread(new ThreadStart(DelayDone));
            thread.Start();
        }
        private bool done = false;
        private Mutex mutex = new Mutex();
        private void DelayDone()
        {
            while (true)
            {
                mutex.WaitOne();
                if (done)
                {
                    mutex.ReleaseMutex();
                    break;
                }
                if (DateTime.Now >= startTime.AddMilliseconds(delayMillisecond))
                {

                    done = true;
                    mutex.ReleaseMutex();
                    this.Invoke(DelayTextChanged);

                    break;
                }
                mutex.ReleaseMutex();
            }
        }
        public event EventHandler DelayTextChanged;
        private int delayMillisecond = 1000;

        public int DelayMillisecond
        {
            get { return delayMillisecond; }
            set { delayMillisecond = value; }
        }
    }
}
