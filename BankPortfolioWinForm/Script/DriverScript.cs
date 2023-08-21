using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class DriverScript
    {
        private string? password;
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
        public bool PasswordChecker()
        {
            return false;
        }

    }
}
