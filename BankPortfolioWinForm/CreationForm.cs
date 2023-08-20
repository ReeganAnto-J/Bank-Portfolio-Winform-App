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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valuesAreSavedWithoutIssue = false;
            try
            {
                Script.AccountCreationScript createAccount = new Script.AccountCreationScript();
                createAccount.Name = textBox1.Text;
                createAccount.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);
                if (textBox2.Text.Equals(textBox3.Text) == false) throw new InvalidOperationException("Passwords didn't match");
                else createAccount.Password = textBox2.Text;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Recheck your input!");
            }
        }
    }
}
