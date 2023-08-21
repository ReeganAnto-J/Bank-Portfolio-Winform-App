using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankPortfolioWinForm
{
    public partial class DriverForm : Form
    {
        enum DriverMode
        {
            selection,
            deposit,
            withdraw,
            checkBalance
        }

        DriverMode mode = DriverMode.selection;

        private int index;
        public DriverForm(int i)
        {
            InitializeComponent();
            index = i;
        }

        private void ButtonShowOrHide()
        {
            button1.Hide(); // Deposit
            button2.Hide(); // Withdraw
            button3.Hide(); // Check Balance
            button4.Hide(); // Back
            label1.Hide(); // Password: Label
            textBox1.Hide(); // Password: Text box
            label2.Hide(); // DepositOrWithdraw
            textBox2.Hide(); // Amount box
            label3.Hide(); // MODE
            label4.Hide(); // Balance: text
            label5.Hide(); // Balance: value
            switch (mode)
            {
                case DriverMode.selection:
                    button1.Show();
                    button2.Show();
                    button3.Show();
                    break;
                case DriverMode.deposit:
                    button4.Show();
                    label1.Show();
                    textBox1.Show();
                    label3.Show();
                    label3.Text = "DEPOSIT";
                    label2.Show();
                    textBox2.Show();
                    break;
                case DriverMode.withdraw:
                    button4.Show();
                    label1.Show();
                    textBox1.Show();
                    label3.Show();
                    label3.Text = "WITHDRAW";
                    label2.Show();
                    textBox2.Show();
                    break;
                case DriverMode.checkBalance:
                    button4.Show();
                    label1.Show();
                    textBox1.Show();
                    label3.Show();
                    label3.Text = "CHECK BALANCE";
                    label4.Show();
                    label5.Show();
                    label5.Text = "Enter your password!";
                    break;
            }
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] credentialFromIndex;
                using (StreamReader reader = new StreamReader(@"../../../Data/Details.csv"))
                {
                    for (int i = 0; i < index; i++)
                    {
                        credentialFromIndex = reader.ReadLine().Split(',');
                        if (credentialFromIndex[1] != null) { this.Text = credentialFromIndex[1]; }
                    }
                }
                ButtonShowOrHide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Back
        {
            mode = DriverMode.selection;
            ButtonShowOrHide();
        }

        private void button5_Click(object sender, EventArgs e) // Log Out
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        } // Ignore

        private void button1_Click(object sender, EventArgs e)
        {
            mode = DriverMode.deposit;
            ButtonShowOrHide();
        } // Deposit

        private void button2_Click(object sender, EventArgs e)
        {
            mode = DriverMode.withdraw;
            ButtonShowOrHide();
        }// Withdraw

        private void button3_Click(object sender, EventArgs e) // Check Balance
        {
            mode = DriverMode.checkBalance;
            ButtonShowOrHide();
        }

        // Submit button, very important
        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
