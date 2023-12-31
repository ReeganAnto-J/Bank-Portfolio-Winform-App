﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankPortfolioWinForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreationForm creationForm = new CreationForm();
            this.Hide();
            creationForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (new FileInfo(Program.detailsCsvLocation).Length == 0) MessageBox.Show("No account exists");
            else
            {
                VerificationForm verificationForm = new VerificationForm(false);
                this.Hide();
                verificationForm.ShowDialog();
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (new FileInfo(Program.detailsCsvLocation).Length == 0) MessageBox.Show("No account exists");
            else
            {
                VerificationForm verificationForm = new VerificationForm(true);
                this.Hide();
                verificationForm.ShowDialog();
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
