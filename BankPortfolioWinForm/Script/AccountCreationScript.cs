using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class AccountCreationScript
    {
        private string? name, password;
        private DateTime dateOfBirth;

        public string? Name
        {
            get => name;
            set
            {
                if (value == null || value.Length == 0) throw new InvalidDataException("Name cannot be empty!");
                else if (value.All(Char.IsLetter) == false) throw new InvalidDataException("Name should only have letters");
                else name = value;
            }
        }
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                // Note to Reegan: Should check later
                if (DateTime.Today.Year - value.Year < 18) throw new InvalidDataException("Must be 18 or older!");
                else dateOfBirth = value;
            }
        }
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
    }
}
