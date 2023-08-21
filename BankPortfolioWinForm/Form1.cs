namespace BankPortfolioWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Written, edited and refactored by Reegan Anto.J 
            // https://www.linkedin.com/in/reegan-anto-j
            // https://github.com/ReeganAnto-J
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yep, I would really appreciate your testing");
        }
    }
}