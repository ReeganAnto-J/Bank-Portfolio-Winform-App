using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPortfolioWinForm.Script
{
    class AccountManagementScript : InputProperties
    {
        public bool SaveOrDelete(bool delete)
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
                            if (delete)
                            {
                                if (line.Split(",")[0].Equals(Convert.ToString(Index)))
                                {
                                    writer.WriteLine("");
                                }
                                else
                                {
                                    writer.WriteLine(line);
                                }
                            }
                            else
                            {
                                if ((string.IsNullOrWhiteSpace(line) || line.Equals("")) && !replaced)
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
                        }
                        if (!replaced && !delete)
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

        public bool CheckDuplicateAccount()
        {
            string?[] splittedLine;
            string? line;
            using (StreamReader reader = new StreamReader(Program.detailsCsvLocation))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    splittedLine = line.Split(',');
                    if (!string.IsNullOrEmpty(splittedLine.FirstOrDefault()))
                    {
                        if (splittedLine[1].Equals(Name) && splittedLine[2].Equals(DateOfBirth.ToString("dd/M/yyyy")))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /* Note this entire app is built by Reegan Anto.J 
            If someone is stupid enough to copy my sorry app, I am really
            sorry for them*/

        public int ValidateAccount()
        {
            int index = -1;
            string? filePath = Program.detailsCsvLocation;
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
            Index = ValidateAccount();
            if (Index == -1) return false;
            SaveOrDelete(true);
            return true;
        }
    }
}
