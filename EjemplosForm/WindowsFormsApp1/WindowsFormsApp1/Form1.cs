using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int sumar;
        public Form1()
        {
            sumar = 0;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sumar++;
            label1.Text = Convert.ToString(sumar);
        }

        private void color_Click(object sender, EventArgs e)
        {

            if (sumar == 0)
            {
                BackColor = Color.Azure;
            }
            else if (sumar==1)
            {
                BackColor = Color.Blue;
            }
        }
    }
}
