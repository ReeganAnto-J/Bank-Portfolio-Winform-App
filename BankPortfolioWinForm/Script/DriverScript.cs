using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class DriverScript
    {
        private string? password;
        private int amount;
        public string? Password
        {
            get => password;
            set
            {
                if (value == null || value.Length == 0) throw new InvalidDataException("Password cannot be empty!");
                else if (value.Length != 4) throw new InvalidDataException("Password must have 4 digits");
                else if (!value.All(Char.IsDigit)) throw new InvalidDataException("Password should only have numbers");
                else password = value;
            }
        }
        public int Amount { get; set; }
        public int Index { get; set; }

        public bool PasswordChecker()
        {
            string[] credentialFromIndex;
            using (StreamReader reader = new StreamReader(@"../../../Data/Password.csv"))
            {
                for (int i = 0; i < Index; i++)
                {
                    credentialFromIndex = reader.ReadLine().Split(',');
                    if (credentialFromIndex[0].Equals(Convert.ToString(Index)))
                    {
                        if (credentialFromIndex[1].Equals(Password))
                        { return true; }
                    }
                }
            }
            return false;
        }

        public bool Deposit() 
        {
            return false;
        }

        public bool Withdraw()
        {
            return false;
        }

        public int Balance()
        {
            return 0;
        }
    }
}
