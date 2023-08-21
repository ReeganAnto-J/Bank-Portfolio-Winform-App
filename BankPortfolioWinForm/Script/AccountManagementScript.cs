using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class AccountManagementScript : InputProperties
    {
        public bool SaveToFile()
        {
            string[] filePaths = new string[3] { Program.detailsCsvLocation, Program.passwordCsvLocation, Program.balanceCsvLocation };
            string line, tempFilePath; 
            int i; 
            bool replaced;
            try
            {
                foreach (string path in filePaths)
                {
                    tempFilePath = Path.GetTempFileName();
                    replaced = false; i = 0;
                    using (StreamReader reader  = new StreamReader(path))
                    using (StreamWriter writer = new StreamWriter(tempFilePath))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            i++;
                            if ((string.IsNullOrWhiteSpace(line) || line.Equals("DELETED")) && !replaced)
                            {
                                if (path.Equals(Program.detailsCsvLocation))
                                {
                                    writer.WriteLine($"{i},{Name},{DateOfBirth.ToString("dd/M/yyyy")}");
                                    replaced = true;
                                }
                                else if (path.Equals(Program.passwordCsvLocation))
                                {
                                    writer.WriteLine($"{i},{Password}");
                                    replaced = true;
                                }
                                else
                                {
                                    writer.WriteLine($"{i},{0}");
                                    replaced = true;
                                }
                            }
                            else
                            {
                                writer.WriteLine(line);
                            }
                        }
                        if (!replaced) 
                        {  
                            if (path.Equals(Program.detailsCsvLocation)) writer.WriteLine($"{i + 1},{Name},{DateOfBirth.ToString("dd/M/yyyy")}");
                            else if (path.Equals(Program.passwordCsvLocation)) writer.WriteLine($"{i + 1},{Password}");
                            else writer.WriteLine($"{i + 1},{0}");
                        }
                    }
                    File.Delete(path);
                    File.Move(tempFilePath, path);
                }
                return true;
            }
            catch
            {
                return false;
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
