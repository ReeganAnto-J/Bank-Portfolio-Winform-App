using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    abstract class InputProperties
    {
        private int amount;
        private string? name, password;
        private DateTime dateOfBirth;

        public string? Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new InvalidDataException("Name cannot be empty!");
                else if (value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c.Equals('.')) == false) throw new InvalidDataException("Name should only have letters, spaces or \'.\'");
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
                if (string.IsNullOrEmpty(value)) throw new InvalidDataException("Password cannot be empty!");
                else if (value.Length != 4) throw new InvalidDataException("Password must have 4 digits");
                else password = value;
            }
        }
        public bool DeleteConfirmation { get; set; }
        // By Reegan Anto.J // https://www.linkedin.com/in/reegan-anto-j
        public int Amount
        {
            get => amount;
            set
            {
                if (value < 0) throw new InvalidDataException("Amount cannot be negative");
                else amount = value;
            }
        }
        public int Index { get; set; }
    }
}
