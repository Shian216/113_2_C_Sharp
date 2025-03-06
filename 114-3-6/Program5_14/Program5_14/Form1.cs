using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inputFile; //宣告物件
            int sum = 0; //宣告變數sum，用來存放總和
            int count = 0; //宣告變數count，用來存放資料筆數
            int temp; //宣告變數temp，用來存放讀到的資料

            try
            {
                inputFile = File.OpenText("NUMBERS.txt"); //開啟檔案
                while (!inputFile.EndOfStream) //當沒有讀到檔案結尾時
                {
                    count++; //資料筆數+1
                    temp = int.Parse(inputFile.ReadLine());
                    sum += temp;
                    listBox11.Items.Add(temp);
                   
                }
                listBox11.Items.Add("總共有"+count+"個數字\n總和:"+sum);
                listBox11.Items.Add("總和為" + count + "個數字\n總和:" + sum);
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
