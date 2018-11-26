using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeChartNotify
{
    public partial class FormRealComputerInfo : Form
    {
        public FormRealComputerInfo()
        {
            InitializeComponent();
        }

        private void Computet_Usage_EnentTicker(object sender, EventArgs e)
        {
            this.timer1.Stop();

            this.textBox_CPU.Text = ComputerInfomation.getCPUUsage();
            this.textBox_RM.Text = ComputerInfomation.get_StorageInfo().dwMemoryLoad.ToString();

            this.timer1.Start();
        }
    }
}
