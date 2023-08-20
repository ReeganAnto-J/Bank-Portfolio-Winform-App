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
            using StreamWriter passwordFileCreator = new StreamWriter(@"../../../Data/Password.csv", true);
            passwordFileCreator.Close();
            using StreamWriter detailsFileCreator = new StreamWriter(@"../../../Data/Details.csv", true);
            detailsFileCreator.Close();
            using StreamWriter balanceFileCreator = new StreamWriter(@"../../../Data/Balance.csv", true);
            balanceFileCreator.Close();
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