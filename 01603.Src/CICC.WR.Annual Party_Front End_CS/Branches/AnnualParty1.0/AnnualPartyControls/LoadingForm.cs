using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace CICC.WR.AnnualPartyControls
{
    public partial class LoadingForm : Form
    {
        private ILog log = LogManager.GetLogger(typeof(LoadingForm));
        private string _StatusInfo = "";
        public LoadingForm()
        {
            InitializeComponent();
        }
        public string StatusInfo
        {
            set
            {
                _StatusInfo = value;
                ChangeStatusText();
            }
            get
            {
                return _StatusInfo;
            }
        }

        public void ChangeStatusText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.ChangeStatusText));
                    return;
                }

                this.lbMessage.Text = _StatusInfo;
            }
            catch (Exception e)
            {
                //    异常处理
                log.Error("修改状态字符串时发生异常", e);
            }
        }
    }
}
