using BankPortfolioWinForm.Script;
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
            button6.Hide(); // Submit Button

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
                    textBox1.Clear();
                    label3.Show();
                    label3.Text = "DEPOSIT";
                    label2.Show();
                    textBox2.Show();
                    textBox2.Clear();
                    button6.Show();
                    break;
                case DriverMode.withdraw:
                    button4.Show();
                    label1.Show();
                    textBox1.Show();
                    textBox1.Clear();
                    label3.Show();
                    label3.Text = "WITHDRAW";
                    label2.Show();
                    textBox2.Show();
                    textBox2.Clear();
                    button6.Show();
                    break;
                case DriverMode.checkBalance:
                    button4.Show();
                    label1.Show();
                    textBox1.Show();
                    textBox1.Clear();
                    label3.Show();
                    label3.Text = "CHECK BALANCE";
                    label4.Show();
                    label5.Show();
                    label5.Text = "Enter your password!";
                    button6.Show();
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
            try
            {
                DriverScript driverScript = new DriverScript();
                driverScript.Index = index;
                driverScript.Password = textBox1.Text;
                if (driverScript.PasswordChecker())
                {
                    if (mode == DriverMode.deposit)
                    {
                        if (int.TryParse(textBox2.Text, out _))
                        {
                            driverScript.Amount = Convert.ToInt32(textBox2.Text);
                            if (driverScript.Deposit()) MessageBox.Show($"Amount {driverScript.Amount:c} has been deposited");
                            else throw new Exception($"Unable to deposit {driverScript.Amount:c}");
                            mode = DriverMode.selection;
                            ButtonShowOrHide();
                        }
                        else throw new InvalidDataException("Enter only numbers");
                    }
                    else if (mode == DriverMode.withdraw)
                    {
                        if (int.TryParse(textBox2.Text, out _))
                        {
                            driverScript.Amount = Convert.ToInt32(textBox2.Text);
                            driverScript.Amount = Convert.ToInt32(textBox2.Text);
                            if (driverScript.Deposit()) MessageBox.Show($"Amount {driverScript.Amount:c} has been withdrawn");
                            else throw new Exception($"Insufficient Balance!");
                            mode = DriverMode.selection;
                            ButtonShowOrHide();
                        }
                        else throw new InvalidDataException("Enter only numbers");
                    }
                    else
                    {
                        label5.Text = $"{driverScript.Balance():c}";
                    }
                }
                else throw new InvalidDataException("Password didn't match the account");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
