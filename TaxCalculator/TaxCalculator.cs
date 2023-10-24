using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxCalculator
{
    public partial class TaxCalculator : Form
    {
        public TaxCalculator()
        {
            InitializeComponent();
        }

        //Exit button functionality
        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clear button functionality
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); //Clears Sales Amount textbox
        }

        //Submit button functionality
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string salesText = textBox1.Text; //put textbox1's text into a string
                decimal sales = Convert.ToDecimal(salesText); //convert salesText string to decimal
                decimal taxPercent = numericUpDown1.Value; //put numericUpDown1's value into a decimal
                decimal taxPercentDiv = taxPercent / 100; //divide taxPercent by 100
                decimal taxValue = sales * taxPercentDiv; //multiply sales by taxPercent
                decimal total = sales + taxValue; //add taxValue to sales and put in a variable

                MessageBox.Show("Tax on R" + sales + " at " + taxPercent + "% is R" + taxValue + ".\nThe total is R" + total + "."); //Popup message when clicking on submit button


                string filePathForTotals = @"C:\Users\brett\Documents\Coding\CTU\FA\PRG\FA3\totals.txt"; //Define the path to the text file where you want to save the messages
                using (StreamWriter writer = new StreamWriter(filePathForTotals, true)) //Write the message to the text file
                {
                    writer.WriteLine(DateTime.Now.ToString() + ": " + total); //Write the message
                }
            }
            catch (Exception ex) //catch exception
            {
                string errorMessage = "An error occurred: " + ex.Message; //define the error message

                //Define the path to the text file where you want to save the messages
                string filePathForExceptions = @"C:\Users\brett\Documents\Coding\CTU\FA\PRG\FA3\exceptions.txt";

                //Write the exception message to the text file
                using (StreamWriter writer = new StreamWriter(filePathForExceptions, true))
                {
                    writer.WriteLine(DateTime.Now.ToString() + ": " + errorMessage);
                }

                //Display the message box
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        }

        //Allow only numbers in textbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
