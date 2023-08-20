using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankPortfolioWinForm
{
    public partial class VerificationForm : Form
    {
        private bool deleteConfirmationMode;
        public VerificationForm(bool delConfirm)
        {
            deleteConfirmationMode = delConfirm;
            InitializeComponent();
            if (!deleteConfirmationMode)
            {
                label2.Hide();
                textBox2.Hide();
                label3.Hide();
                textBox3.Hide();
                label5.Text = "Account Verification";
            }
        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {

        }//Ignore

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Ignore

        private void button1_Click(object sender, EventArgs e) // Submit Button
        {
            if (deleteConfirmationMode)
            {
                try
                {
                    Script.AccountManagementScript deleteAccount = new Script.AccountManagementScript();
                    deleteAccount.Name = textBox1.Text;
                    deleteAccount.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);
                    deleteAccount.Password = textBox2.Text;
                    if (textBox3.Text.Equals("DELETE")) deleteAccount.DeleteConfirmation = true;
                    else throw new InvalidDataException("Input doesn't match \"DELETE\"");

                    if (deleteAccount.DeleteAccount()) MessageBox.Show("Account deleted successfully!");
                    else throw new InvalidExpressionException("Account doesn't exist!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Recheck your input!");
                }
            }
            /* I will check after completing deletion :)
            else
            {
                try
                {
                    Script.AccountManagementScript createAccount = new Script.AccountManagementScript();
                    createAccount.Name = textBox1.Text;
                    createAccount.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);
                    if (textBox2.Text.Equals(textBox3.Text) == false) throw new InvalidOperationException("Passwords didn't match");
                    else createAccount.Password = textBox2.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Recheck your input!");
                }
            }*/
        }
    }
}
