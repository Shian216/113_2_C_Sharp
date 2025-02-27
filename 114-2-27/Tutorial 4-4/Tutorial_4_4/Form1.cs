using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial_4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCount_Click(object sender, EventArgs e)
        {
            double distance, gas, average;

            if (double.TryParse(TxtKm.Text, out distance))
            {
                if (double.TryParse(TxtL.Text, out gas))
                {
                    average = distance/gas;
                    LblShow.Text = "平均油耗"+average.ToString("f2")+"公里/公升";
                }
                else
                {
                    MessageBox.Show("請輸入數字");
                    TxtL.Focus();//將滑鼠游標移至TxtL
                    TxtL.Text = "";//清空TextBox
                }
            }
            else
            {
                MessageBox.Show("請輸入數字");
                TxtKm.Focus();//將滑鼠游標移至TxtKm
                TxtKm.Text = ""; //清空TextBox
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
