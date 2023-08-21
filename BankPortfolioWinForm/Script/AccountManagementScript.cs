using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class AccountManagementScript
    {
        private string? name, password;
        private bool deleteConfirmation;
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
       public bool DeleteConfirmation { get; set; }

        public int SaveToFile()
        {
            string? filePath, tempFilePath, line;
            bool replaced;
            int i;
            try
            {
                // Storing id number, name and DOB in Details.csv
                filePath = @"../../../Data/Details.csv";
                tempFilePath = Path.GetTempFileName();
                replaced = false;
                i = 0;
                using (StreamReader reader = new StreamReader(filePath))
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        if ((string.IsNullOrWhiteSpace(line) || line.Equals("DELETED") )&& !replaced)
                        {
                            writer.WriteLine($"{i},{Name},{DateOfBirth.ToString("dd/M/yyyy")}");
                            replaced = true;
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                    if (!replaced) { writer.WriteLine($"{i+1},{Name},{DateOfBirth.ToString("dd/M/yyyy")}"); }
                }
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);

                // Storing id number and password in Password.csv
                filePath = @"../../../Data/Password.csv";
                tempFilePath = Path.GetTempFileName();
                replaced = false;
                i = 0;
                using (StreamReader reader = new StreamReader(filePath))
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        if (string.IsNullOrWhiteSpace(line) || line.Equals("DELETED") && !replaced)
                        {
                            writer.WriteLine($"{i},{Password}");
                            replaced = true;
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                    if (!replaced) { writer.WriteLine($"{i + 1},{Password}"); }
                }
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);

                // Storing id number and setting balance as zero in Balance.csv
                filePath = @"../../../Data/Balance.csv";
                tempFilePath = Path.GetTempFileName();
                replaced = false;
                i = 0;
                using (StreamReader reader = new StreamReader(filePath))
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;
                        if (string.IsNullOrWhiteSpace(line) || line.Equals("DELETED") && !replaced)
                        {
                            writer.WriteLine($"{i},{0}");
                            replaced = true;
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                    if (!replaced) { writer.WriteLine($"{i + 1},{0}"); }
                }
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);

                // Indicating that the saving is successful!
                return 1;
            }
            catch (Exception)
            {
                return 0; 
            }
        }

        public int ValidateAccount()
        {
            int index = -1;
            string? filePath = @"../../../Data/Details.csv";
            string[] seperatedValues, fileReadValue;
            try
            {
                // To check if the value exists and to find the index
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        seperatedValues = reader.ReadLine().Split(',');
                        if (seperatedValues.Length > 2)
                        {
                            if (seperatedValues[1].Equals(Name) && seperatedValues[2].Equals(DateOfBirth.ToString("dd/M/yyyy")))
                            {
                                int.TryParse(seperatedValues[0], out index);
                                break;
                            }
                        }
                    }
                }
                if (index == -1) return -1; // Doesn't exist
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return index;
        }

        public bool DeleteAccount()
        {
            int index = -1;
            string? filePath = @"../../../Data/Details.csv";
            string[] seperatedValues, fileReadValue;
            try
            {
                // To check if the value exists and to find the index
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        seperatedValues = reader.ReadLine().Split(',');
                        if (seperatedValues.Length > 2)
                        {
                            if (seperatedValues[1].Equals(Name) && seperatedValues[2].Equals(DateOfBirth.ToString("dd/M/yyyy")))
                            {
                                int.TryParse(seperatedValues[0], out index);
                                break;
                            }
                        }
                    }
                }
                if (index == -1) return false; // Doesn't exist

                // To remove from Details.csv
                fileReadValue = File.ReadAllLines(filePath);
                fileReadValue[index - 1] = "DELETED";
                File.WriteAllLines(filePath, fileReadValue);

                // To remove from Password.csv
                filePath = @"../../../Data/Password.csv";
                fileReadValue = File.ReadAllLines(filePath);
                fileReadValue[index - 1] = "DELETED";
                File.WriteAllLines(filePath, fileReadValue);

                // To remove from Balance.csv
                filePath = @"../../../Data/Balance.csv";
                fileReadValue = File.ReadAllLines(filePath);
                fileReadValue[index - 1] = "DELETED";
                File.WriteAllLines(filePath, fileReadValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
    }
}
