using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000;
            int num;
            Random random = new Random();
            int[] numbers = new int[SIZE];
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            if(int.TryParse(textBox1.Text, out num))
            {
                int count = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (num == numbers[i])
                    {
                        count++;
                    }
                }
                MessageBox.Show("The number " + num + " appears " + count + " times.");
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
            
                                 
        }

    }
}
