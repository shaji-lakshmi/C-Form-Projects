using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LShajiFactorial
{
    public partial class ShajiFactorialCalculator : Form
    {
        
        public ShajiFactorialCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int userInput = Convert.ToInt32(txtNumber.Text);
            Int64 factorial =1; 

            for (int i = 1; i <= userInput; i++) {
                factorial *= i; 

            }

            txtFactorial.Text = factorial.ToString("N0"); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
