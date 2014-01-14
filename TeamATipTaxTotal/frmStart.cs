using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamATipTaxTotal
{
    //Team A In Class Excercise Week 1
    //Tip, Tax, Total App
    //Version 1
    //William Mitchell, Auric Beihl, Dennis Chapman
    //December 19, 2013
    //POS_409
    //Dr Brad Purdy

    public partial class frmStart : Form
    {
        //declares constant values for tax and tip percentages
        public const double TAX_PERCENTAGE = .07;
        public const double TIP_PERCENTAGE = .15;
        
        
        public frmStart()
        {
            InitializeComponent();
        }

        //exits app
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //resets form
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbFoodCharge.Clear();
            this.tbTax.Clear();
            this.tbTip.Clear();
            this.tbTotal.Clear();
            this.tbFoodCharge.Focus();

        }

        //calculates the amounts
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.tbTax.Clear();
            this.tbTip.Clear();
            this.tbTotal.Clear();
            decimal decimalFoodCharge; 
            decimal decimalTipCharge;
            decimal decimalTaxCharge;
            decimal decimalTotal;

            //conditional test for parsibility
            if (decimal.TryParse(this.tbFoodCharge.Text, out decimalFoodCharge))
            {
                decimalTaxCharge = decimalFoodCharge * (decimal)TAX_PERCENTAGE;
                decimalTipCharge = decimalFoodCharge * (decimal)TIP_PERCENTAGE;
                decimalTotal = decimalFoodCharge + decimalTipCharge + decimalTaxCharge;
                this.tbTax.Text = decimalTaxCharge.ToString("C");
                this.tbTip.Text = decimalTipCharge.ToString("C");
                this.tbTotal.Text = decimalTotal.ToString("C");
                
            }
                //diplays error
            else
            {
                MessageBox.Show("Please Enter A Numeric Value for The Food Charge", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sets tool tip on form load
        private void frmStart_Load(object sender, EventArgs e)
        {
            this.ttInfo.SetToolTip(this.tbFoodCharge, "Enter The Food Charge Amount");
            this.ttInfo.SetToolTip(this.btnExit, "Exit Application");
            this.ttInfo.SetToolTip(this.btnCalculate, "Calculate the Tax, Tip, and Total");
            this.ttInfo.SetToolTip(this.btnReset, "Reset the form");
            this.ttInfo.SetToolTip(this.tbTax, "Displays the Tax Total");
            this.ttInfo.SetToolTip(this.tbTip, "Displays the Tip Total");
            this.ttInfo.SetToolTip(this.tbTotal, "Displays the Total");

        }
    }
}
