using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class frmConversions : Form
    {
        public frmConversions()
        {
            InitializeComponent();
        }

        string[,] conversionTable = {
            {"Miles to kilometers", "Miles", "Kilometers", "1.6093"},
            {"Kilometers to miles", "Kilometers", "Miles", "0.6214"},
            {"Feet to meters", "Feet", "Meters", "0.3048"},
            {"Meters to feet", "Meters", "Feet", "3.2808"},
            {"Inches to centimeters", "Inches", "Centimeters", "2.54"},
            {"Centimeters to inches", "Centimeters", "Inches", "0.3937"}
        };


        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool isDecimal(TextBox textBox, string userInput)
        {
            if (Decimal.TryParse(textBox.Text, out Decimal result))
            {
                return true;
            }
            else
            {
                MessageBox.Show(userInput + " is invalid. Please enter a valid decimal value.");
                return false;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDecimal(txtLength, "User input"))
                {
                    int indexOfInterest = cboConversions.SelectedIndex;
                    decimal userInput = Convert.ToDecimal(txtLength.Text);
                    decimal conversionfactor = Convert.ToDecimal(conversionTable[indexOfInterest, 3]);
                    decimal convertedValue = userInput * conversionfactor;

                    txtCalculatedLength.Text = String.Format("{0:n}", convertedValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, "Exception");
            }
        }

        private void frmConversions_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                cboConversions.SelectedItem = conversionTable[0, 0];
                cboConversions.Items.Add(conversionTable[i, 0]);
            }
        }

        private void cboConversions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexOfInterest = cboConversions.SelectedIndex;
            lblFromLength.Text = conversionTable[indexOfInterest, 1];
            lblToLength.Text = conversionTable[indexOfInterest, 2];
            txtCalculatedLength.Text = "";
            txtLength.Text = "";
            txtLength.Focus();
        }
    }
}