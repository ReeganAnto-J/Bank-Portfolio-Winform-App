using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class DriverScript : InputProperties
    {
        public bool PasswordChecker()
        {
            string[] credentialFromIndex;
            using (StreamReader reader = new StreamReader(Program.passwordCsvLocation))
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

        public void BalanceUpdatation(int newBalance)
        {
            string filePath = Program.balanceCsvLocation;
            string tempFilePath = Path.GetTempFileName(), line;
            using (StreamReader reader = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Split(',')[0].Equals(Convert.ToString(Index)))
                    {
                        writer.WriteLine($"{Index},{newBalance}");
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public bool Deposit() 
        {
            int balance = Balance();
            try
            {
                checked { balance = balance + Amount; }
                BalanceUpdatation(balance);
                return true;
            }
            catch (OverflowException)
            {
                throw new InvalidDataException($"Bank account has a limit of {int.MaxValue:c}");
            }
        }

        public bool Withdraw()
        {
            int balance = Balance();
            if (balance - Amount < 0)
            {
                throw new InvalidDataException("Insufficient Balance");
            }
            else
            {
                balance -= Amount;
                BalanceUpdatation(balance);
                return true;
            }
        }
        // By Reegan Anto.J  https://www.linkedin.com/in/reegan-anto-j
        public int Balance()
        {
            try
            {
                string[] credentialFromIndex;
                using (StreamReader reader = new StreamReader(Program.balanceCsvLocation))
                {
                    for (int i = 0; i < Index; i++)
                    {
                        credentialFromIndex = reader.ReadLine().Split(',');
                        if (credentialFromIndex[0].Equals(Convert.ToString(Index)))
                        {
                            return Convert.ToInt32(credentialFromIndex[1]);
                        }
                    }
                }
                return -1;
            }
            catch (Exception) { return -1; }
        }
    }
}
