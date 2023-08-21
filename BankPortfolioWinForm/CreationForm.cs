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
    public partial class CreationForm : Form
    {
        public CreationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }// Ignore

        // Submit
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Script.AccountManagementScript createAccount = new Script.AccountManagementScript();
                createAccount.Name = textBox1.Text;
                createAccount.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);
                if (createAccount.CheckDuplicateAccount()) throw new InvalidDataException("Account already exists!");
                if (!textBox2.Text.All(Char.IsDigit)) throw new InvalidDataException("Password should only have numbers");
                if (textBox2.Text.Equals(textBox3.Text) == false) throw new InvalidOperationException("Passwords didn't match");
                else createAccount.Password = textBox2.Text;
                if (createAccount.SaveOrDelete(false))
                {
                    MessageBox.Show("Contents were saved successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to save the files properly");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recheck your input!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } // Ignore

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
